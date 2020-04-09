namespace MovieMood.Services.Data.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MovieMood.Data.Models;
    using MovieMood.Web.ViewModels.Balance.Users.InputModels;

    public interface IUsersService
    {
        Task ModifyClaim(ApplicationUser user, IList<ApplicationUser> users, DepositMoneyInputModel model);

        Task Pay(ApplicationUser user, IList<ApplicationUser> users, decimal price);
    }
}
