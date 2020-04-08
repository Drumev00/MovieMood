namespace MovieMood.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MovieMood.Services.Data.Orders;
    using MovieMood.Services.Data.Projections;
    using MovieMood.Services.Data.Seats;
    using MovieMood.Web.ViewModels.Projections.Users.ViewModels;
    using MovieMood.Web.ViewModels.Tickets.Users.InputModels;

    [Authorize]
    public class TicketsController : BaseController
    {
        private readonly ISeatsService seatsService;
        private readonly IOrdersService ordersService;
        private readonly IProjectionsService projectionsService;

        public TicketsController(
            ISeatsService seatsService,
            IOrdersService ordersService,
            IProjectionsService projectionsService)
        {
            this.seatsService = seatsService;
            this.ordersService = ordersService;
            this.projectionsService = projectionsService;
        }

        public IActionResult Buy(string orderId, int q)
        {
            var hallId = this.ordersService.GetHallId(orderId);
            var projectionId = this.ordersService.GetProjectionId(orderId);

            var viewModel = new BuyTicketsInputModel
            {
                TicketsCount = q,
                Projection = this.projectionsService.GetById<ProjectionsTicketInfoViewModel>(projectionId),
                Rows = this.seatsService.NotReservedRows(hallId),
                Numbers = this.seatsService.NotReservedNumbers(hallId),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Buy(BuyTicketsInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            return this.Redirect("/");
        }
    }
}
