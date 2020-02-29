namespace MovieMood.Services.Data.Seats
{
    using System.Threading.Tasks;

    public interface ISeatsService
    {
        Task CreateAsync(int row, int number, int hallId);
    }
}
