namespace MovieMood.Services.Data.Seats
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISeatsService
    {
        Task CreateAsync(int row, int number, int hallId);

        Task DeleteAsync(int hallId);

        IEnumerable<int> NotReservedRows(int hallId);

        IEnumerable<int> NotReservedNumbers(int hallId);
    }
}
