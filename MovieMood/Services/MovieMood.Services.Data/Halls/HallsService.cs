namespace MovieMood.Services.Data.Halls
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MovieMood.Common;
    using MovieMood.Data.Common.Repositories;
    using MovieMood.Data.Models;
    using MovieMood.Services.Data.Seats;

    public class HallsService : IHallsService
    {
        private readonly IDeletableEntityRepository<Hall> entityRepository;
        private readonly ISeatsService seatsService;

        public HallsService(IDeletableEntityRepository<Hall> entityRepository, ISeatsService seatsService)
        {
            this.entityRepository = entityRepository;
            this.seatsService = seatsService;
        }

        // TODO: Probably add mapping table
        public async Task CreateAsync(string name)
        {
            var hall = new Hall
            {
                CreatedOn = DateTime.UtcNow,
                Name = name,
            };

            await this.entityRepository.AddAsync(hall);
            await this.entityRepository.SaveChangesAsync();

            for (int i = 1; i <= GlobalConstants.SeatsRow; i++)
            {
                for (int j = 1; j <= GlobalConstants.SeatsCol; j++)
                {
                    await this.seatsService.CreateAsync(i, j, hall.Id);
                }
            }
        }
    }
}
