namespace MovieMood.Services.Data.Users
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using MovieMood.Data.Models;
    using MovieMood.Web.ViewModels.Balance.Users.InputModels;

    public interface IUsersService
    {
        Task GetClaim(ApplicationUser user, IList<ApplicationUser> users, DepositMoneyInputModel model);
    }
}
