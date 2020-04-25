namespace MovieMood.Services.Data.Seats
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MovieMood.Common;
    using MovieMood.Data.Common.Repositories;
    using MovieMood.Data.Models;

    public class SeatsService : ISeatsService
    {
        private readonly IDeletableEntityRepository<Seat> seatsRepository;

        public SeatsService(IDeletableEntityRepository<Seat> seatsRepository)
        {
            this.seatsRepository = seatsRepository;
        }

        public IEnumerable<int> NotReservedRows(int hallId)
        {
            if (hallId <= 0)
            {
                throw new ArgumentException("Parameter \"hallId\" must be positive number");
            }

            var seats = this.seatsRepository.All()
                .Where(s => !s.IsReserved &&
                s.HallId == hallId)
                .Select(s => s.Row)
                .Distinct()
                .ToList();

            return seats;
        }

        public IEnumerable<int> NotReservedNumbers(int hallId)
        {
            if (hallId <= 0)
            {
                throw new ArgumentException("Parameter \"hallId\" must be positive number");
            }

            var seats = this.seatsRepository.All()
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
            if (row > GlobalConstants.SeatsRow || row <= 0 || number > GlobalConstants.SeatsCol || number <= 0 || hallId <= 0)
            {
                throw new ArgumentException
                    ("Parameter \"row\" should be between 1 and 10. Parameter \"number\" should be between 1 and 18 and \"hallId\" must be positive number");
            }

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
            if (hallId <= 0)
            {
                throw new ArgumentException("Parameter \"hallId\" must be positive number");
            }

            var seat = this.seatsRepository.All()
                .Where(s => s.HallId == hallId)
                .FirstOrDefault();

            this.seatsRepository.Delete(seat);
            await this.seatsRepository.SaveChangesAsync();
        }

        public Seat FindSeat(int row, int number, int hallId)
        {
            if (row > GlobalConstants.SeatsRow || row <= 0 || number > GlobalConstants.SeatsCol || number <= 0 || hallId <= 0)
            {
                throw new ArgumentException
                    ("Parameter \"row\" should be between 1 and 10. Parameter \"number\" should be between 1 and 18 and \"hallId\" must be positive number");
            }

            var seat = this.seatsRepository.All()
                .Where(s => s.Row == row &&
                s.Number == number &&
                s.HallId == hallId)
                .FirstOrDefault();

            return seat;
        }

        public async Task ModifySeatState(Seat seat)
        {
            this.seatsRepository.Update(seat);
            await this.seatsRepository.SaveChangesAsync();
        }

        public bool IsReserved(int row, int number, int hallId)
        {
            if (row > GlobalConstants.SeatsRow || row <= 0 || number > GlobalConstants.SeatsCol || number <= 0 || hallId <= 0)
            {
                throw new ArgumentException
                    ("Parameter \"row\" should be between 1 and 10. Parameter \"number\" should be between 1 and 18 and \"hallId\" must be positive number");
            }

            var seat = this.seatsRepository.All()
                .FirstOrDefault(s => s.HallId == hallId &&
                s.Row == row &&
                s.Number == number);

            return seat.IsReserved;
        }

        public void FreeTheSeats(int hallId)
        {
            if (hallId <= 0)
            {
                throw new ArgumentException("Parameter \"hallId\" must be positive number");
            }

            var seats = this.seatsRepository.All()
                .Where(s => s.HallId == hallId)
                .ToList();

            foreach (var seat in seats)
            {
                if (seat.IsReserved)
                {
                    seat.IsReserved = false;
                    this.seatsRepository.Update(seat);
                    this.seatsRepository.SaveChangesAsync();
                }
            }
        }
    }
}
