namespace MovieMood.Services.Data.Tickets
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MovieMood.Web.ViewModels.Tickets.Users.InputModels;

    public interface ITicketsService
    {
        Task<bool> GenerateTicketsAsync(BuyTicketsInputModel model);

        bool SameSeatCondition(IList<int> rows, IList<int> numbers);
    }
}
