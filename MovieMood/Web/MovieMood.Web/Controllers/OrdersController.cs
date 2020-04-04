namespace MovieMood.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MovieMood.Data.Models;
    using MovieMood.Services.Data.Orders;
    using MovieMood.Web.ViewModels.Orders.Users.InputModels;

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
            this.TempData["projection"] = projectionId;
            return this.View();
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

            return this.Redirect("/");
        }
    }
}
