namespace MovieMood.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MovieMood.Data.Models;
    using MovieMood.Services.Data.Orders;
    using MovieMood.Web.ViewModels.Orders.Users.InputModels;

    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly IOrdersService ordersService;
        private readonly UserManager<ApplicationUser> userManager;

        public OrdersController(
            IOrdersService ordersService,
            UserManager<ApplicationUser> userManager)
        {
            this.ordersService = ordersService;
            this.userManager = userManager;
        }

        public IActionResult Buy(string projectionId)
        {
            var viewModel = new OrderTicketsInputModel
            {
                ProjectionId = projectionId,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Buy(OrderTicketsInputModel model)
        {
            model.UserId = this.userManager.GetUserId(this.User);

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.ordersService.BuyAsync(model);
            var order = this.ordersService.GetOrder<OrderInfoViewModel>(model.ProjectionId, model.UserId, model.TicketQuantity);

            return this.Redirect($"/Tickets/Buy?orderId={order.Id}&q={order.TicketQuantity}");
        }
    }
}
