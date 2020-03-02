namespace MovieMood.Services.Data.Halls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MovieMood.Common;
    using MovieMood.Data.Common.Repositories;
    using MovieMood.Data.Models;
    using MovieMood.Services.Data.Seats;
    using MovieMood.Services.Mapping;
    using MovieMood.Web.ViewModels.Halls.ViewModels;

    public class HallsService : IHallsService
    {
        private readonly IDeletableEntityRepository<Hall> entityRepository;
        private readonly ISeatsService seatsService;

        public HallsService(IDeletableEntityRepository<Hall> entityRepository, ISeatsService seatsService)
        {
            this.entityRepository = entityRepository;
            this.seatsService = seatsService;
        }

        public IEnumerable<HallInfoViewModel> All()
        {
            var hallList = this.entityRepository.AllAsNoTracking()
                .OrderBy(h => h.Id)
                .Select(h => new HallInfoViewModel
                {
                    Id = h.Id,
                    Name = h.Name,
                    CreatedOn = h.CreatedOn.ToString(),
                    MaxSeats = h.Seats.Count,
                    FreeSeats = h.Seats.Count(s => !s.IsReserved),
                })
                .ToList();

            return hallList;
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

        public HallDetailsViewModel GetDetailsById(int id)
        {
            var hall = this.entityRepository.All()
                .FirstOrDefault(h => h.Id == id);

            var details = new HallDetailsViewModel
            {
                Id = hall.Id,
                Name = hall.Name,
                CreatedOn = hall.CreatedOn.ToString(),
            };

            return details;
        }

        public async Task SoftDelete(int hallId)
        {
            var hall = this.entityRepository.All().FirstOrDefault(h => h.Id == hallId);

            this.entityRepository.Delete(hall);

            await this.entityRepository.SaveChangesAsync();
        }
    }
}
