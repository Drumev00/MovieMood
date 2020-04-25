namespace MovieMood.Services.Data.Halls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MovieMood.Common;
    using MovieMood.Data.Common.Repositories;
    using MovieMood.Data.Models;
    using MovieMood.Services.Data.Seats;
    using MovieMood.Services.Mapping;

    public class HallsService : IHallsService
    {
        private readonly IDeletableEntityRepository<Hall> hallsRepository;
        private readonly ISeatsService seatsService;

        public HallsService(IDeletableEntityRepository<Hall> hallsRepository, ISeatsService seatsService)
        {
            this.hallsRepository = hallsRepository;
            this.seatsService = seatsService;
        }

        public IEnumerable<T> All<T>()
        {
            var hallList = this.hallsRepository.All()
                .OrderBy(h => h.Name)
                .To<T>()
                .ToList();

            return hallList;
        }

        public async Task CreateAsync(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(name);
            }

            var hall = new Hall
            {
                CreatedOn = DateTime.UtcNow,
                Name = name,
            };

            await this.hallsRepository.AddAsync(hall);
            await this.hallsRepository.SaveChangesAsync();

            for (int i = 1; i <= GlobalConstants.SeatsRow; i++)
            {
                for (int j = 1; j <= GlobalConstants.SeatsCol; j++)
                {
                    await this.seatsService.CreateAsync(i, j, hall.Id);
                }
            }
        }

        public T GetDetailsById<T>(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Parameter id should be positive number");
            }

            var hall = this.hallsRepository.All()
                .Where(h => h.Id == id)
                .To<T>()
                .FirstOrDefault();

            return hall;
        }

        public async Task SoftDeleteHallAsync(int hallId)
        {
            var hall = this.hallsRepository.All().FirstOrDefault(h => h.Id == hallId);

            if (hall == null)
            {
                throw new ArgumentNullException("Not such hall has been found");
            }

            this.hallsRepository.Delete(hall);

            for (int i = 0; i < GlobalConstants.SeatsRow; i++)
            {
                for (int j = 0; j < GlobalConstants.SeatsCol; j++)
                {
                    await this.seatsService.DeleteAsync(hallId);
                }
            }
        }
    }
}
