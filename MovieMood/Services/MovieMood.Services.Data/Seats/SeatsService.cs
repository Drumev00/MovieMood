namespace MovieMood.Services.Data.Seats
{
    using System;
    using System.Threading.Tasks;

    using MovieMood.Data.Common.Repositories;
    using MovieMood.Data.Models;

    public class SeatsService : ISeatsService
    {
        private readonly IDeletableEntityRepository<Seat> entityRepository;

        public SeatsService(IDeletableEntityRepository<Seat> entityRepository)
        {
            this.entityRepository = entityRepository;
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

            await this.entityRepository.AddAsync(seat);
            await this.entityRepository.SaveChangesAsync();
        }
    }
}
