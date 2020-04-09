namespace MovieMood.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MovieMood.Data.Models;
    using MovieMood.Services.Data.Orders;
    using MovieMood.Services.Data.Projections;
    using MovieMood.Services.Data.Seats;
    using MovieMood.Services.Data.Tickets;
    using MovieMood.Services.Data.Users;
    using MovieMood.Web.ViewModels.Projections.Users.ViewModels;
    using MovieMood.Web.ViewModels.Tickets.Users.InputModels;

    [Authorize]
    public class TicketsController : BaseController
    {
        private readonly ISeatsService seatsService;
        private readonly IOrdersService ordersService;
        private readonly IProjectionsService projectionsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUsersService usersService;
        private readonly ITicketsService ticketsService;

        public TicketsController(
            ISeatsService seatsService,
            IOrdersService ordersService,
            IProjectionsService projectionsService,
            UserManager<ApplicationUser> userManager,
            IUsersService usersService,
            ITicketsService ticketsService)
        {
            this.seatsService = seatsService;
            this.ordersService = ordersService;
            this.projectionsService = projectionsService;
            this.userManager = userManager;
            this.usersService = usersService;
            this.ticketsService = ticketsService;
        }

        public IActionResult Buy(string orderId, int q)
        {
            var hallId = this.ordersService.GetHallId(orderId);
            var projectionId = this.ordersService.GetProjectionId(orderId);

            var viewModel = new BuyTicketsInputModel
            {
                TicketsCount = q,
                HallId = hallId,
                OrderId = orderId,
                Projection = this.projectionsService.GetById<ProjectionsTicketInfoViewModel>(projectionId),
                Rows = this.seatsService.NotReservedRows(hallId),
                Numbers = this.seatsService.NotReservedNumbers(hallId),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Buy(BuyTicketsInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = this.userManager.GetUserAsync(this.User).Result;
            var claim = this.userManager.GetClaimsAsync(user).Result.FirstOrDefault(x => x.Type == "Balance");
            var users = await this.userManager.GetUsersForClaimAsync(claim);
            if (model.Price > decimal.Parse(claim.Value))
            {
                this.TempData["infoMessage"] = $"You don't have enough money for {model.TicketsCount} tickets. Add some to your balance.";
                await this.ordersService.DeleteAsync(model.OrderId);
                return this.Redirect("/Balance/Deposit");
            }

            for (int i = 0; i < model.TicketsCount; i++)
            {
                if (this.seatsService.IsReserved(model.ActualRows[i], model.ActualNumbers[i], model.HallId))
                {
                    model.Rows = this.seatsService.NotReservedRows(model.HallId);
                    model.Numbers = this.seatsService.NotReservedNumbers(model.HallId);
                    this.TempData["reservedSeatMessage"] = $"Seat: Row-{model.ActualRows[i]} and Number-{model.ActualNumbers[i]} is already taken.";
                    return this.View(model);
                }
            }

            await this.usersService.Pay(user, users, model.Price);
            bool sameSeatCondition = await this.ticketsService.GenerateTicketsAsync(model);
            if (sameSeatCondition)
            {
                this.TempData["sameSeat"] = "You cannot choose same seat in the hall twice";
                model.Rows = this.seatsService.NotReservedRows(model.HallId);
                model.Numbers = this.seatsService.NotReservedNumbers(model.HallId);
                return this.View(model);
            }

            return this.Redirect("/");
        }
    }
}
