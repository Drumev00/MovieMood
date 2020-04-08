namespace MovieMood.Services.Data.Seats
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MovieMood.Data.Common.Repositories;
    using MovieMood.Data.Models;
    using MovieMood.Services.Mapping;

    public class SeatsService : ISeatsService
    {
        private readonly IDeletableEntityRepository<Seat> seatsRepository;

        public SeatsService(IDeletableEntityRepository<Seat> seatsRepository)
        {
            this.seatsRepository = seatsRepository;
        }

        public IEnumerable<int> NotReservedRows(int hallId)
        {
            var seats = this.seatsRepository.AllAsNoTracking()
                .Where(s => !s.IsReserved &&
                s.HallId == hallId)
                .Select(s => s.Row)
                .Distinct()
                .ToList();

            return seats;
        }

        public IEnumerable<int> NotReservedNumbers(int hallId)
        {
            var seats = this.seatsRepository.AllAsNoTracking()
                .Where(
                s => !s.IsReserved &&
                s.HallId == hallId)
                .Select(s => s.Number)
                .Distinct()
                .ToList();

            return seats;
        }

        public async Task CreateAsync(int row, int number, int hallId)
        {
            var seat = new Seat
            {
                CreatedOn = DateTime.UtcNow,
                IsReserved = false,
                Row = row,
                Number = number,
                HallId = hallId,
            };

            await this.seatsRepository.AddAsync(seat);
            await this.seatsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int hallId)
        {
            var seat = this.seatsRepository.All()
                .Where(s => s.HallId == hallId)
                .FirstOrDefault();

            this.seatsRepository.Delete(seat);
            await this.seatsRepository.SaveChangesAsync();
        }

    }
}
