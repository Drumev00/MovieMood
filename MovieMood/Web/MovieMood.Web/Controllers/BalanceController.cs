namespace MovieMood.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MovieMood.Data.Models;
    using MovieMood.Services.Data.Users;
    using MovieMood.Web.ViewModels.Balance.Users.InputModels;

    [Authorize]
    public class BalanceController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUsersService usersService;

        public BalanceController(UserManager<ApplicationUser> userManager, IUsersService usersService)
        {
            this.userManager = userManager;
            this.usersService = usersService;
        }

        public IActionResult Deposit()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(DepositMoneyInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = this.userManager.GetUserAsync(this.User).Result;
            var claim = this.userManager.GetClaimsAsync(user).Result.FirstOrDefault(x => x.Type == "Balance");
            var users = await this.userManager.GetUsersForClaimAsync(claim);
            await this.usersService.GetClaim(user, users, model);

            return this.Redirect("/");
        }
    }
}
