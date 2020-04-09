namespace MovieMood.Services.Data.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MovieMood.Data.Common.Repositories;
    using MovieMood.Data.Models;
    using MovieMood.Web.ViewModels.Balance.Users.InputModels;

    public class UsersService : IUsersService
    {
        private readonly IRepository<ApplicationUser> usersRepository;

        public UsersService(IRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task ModifyClaim(ApplicationUser user, IList<ApplicationUser> users, DepositMoneyInputModel model)
        {
            var userFromBase = this.usersRepository.All()
                .FirstOrDefault(u => u.Id == user.Id);

            var claim = users.Select(u => u.Claims.Where(c => c.ClaimType == "Balance" && c.UserId == user.Id).FirstOrDefault()).FirstOrDefault();

            claim.ClaimValue = (decimal.Parse(claim.ClaimValue) + model.Money).ToString();

            this.usersRepository.Update(userFromBase);
            await this.usersRepository.SaveChangesAsync();
        }

        public async Task Pay(ApplicationUser user, IList<ApplicationUser> users, decimal price)
        {
            var userFromBase = this.usersRepository.All()
                .FirstOrDefault(u => u.Id == user.Id);

            var claim = users.Select(u => u.Claims.Where(c => c.ClaimType == "Balance" && c.UserId == user.Id).FirstOrDefault()).FirstOrDefault();

            claim.ClaimValue = (decimal.Parse(claim.ClaimValue) - price).ToString();

            this.usersRepository.Update(userFromBase);
            await this.usersRepository.SaveChangesAsync();
        }
    }
}
