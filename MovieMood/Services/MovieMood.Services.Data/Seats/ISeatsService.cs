namespace MovieMood.Services.Data.Seats
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MovieMood.Data.Models;

    public interface ISeatsService
    {
        Task CreateAsync(int row, int number, int hallId);

        Task DeleteAsync(int hallId);

        Seat FindSeat(int row, int number, int hallId);

        Task ModifySeatState(Seat seat);

        IEnumerable<int> NotReservedRows(int hallId);

        IEnumerable<int> NotReservedNumbers(int hallId);

        bool IsReserved(int row, int number, int hallId);

        void FreeTheSeats(int hallId);
    }
}
