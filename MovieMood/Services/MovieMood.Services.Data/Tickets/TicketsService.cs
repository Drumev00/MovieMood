namespace MovieMood.Services.Data.Tickets
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MovieMood.Data.Common.Repositories;
    using MovieMood.Data.Models;
    using MovieMood.Services.Data.Seats;
    using MovieMood.Web.ViewModels.Tickets.Users.InputModels;

    public class TicketsService : ITicketsService
    {
        private readonly IDeletableEntityRepository<Ticket> ticketsRepository;
        private readonly ISeatsService seatsService;

        public TicketsService(
            IDeletableEntityRepository<Ticket> ticketsRepository,
            ISeatsService seatsService)
        {
            this.ticketsRepository = ticketsRepository;
            this.seatsService = seatsService;
        }

        public async Task<bool> GenerateTicketsAsync(BuyTicketsInputModel model)
        {
            if (this.SameSeatCondition(model.ActualRows, model.ActualNumbers))
            {
                return true;
            }
            else
            {
                for (int i = 0; i < model.TicketsCount; i++)
                {
                    var orderedSeat = this.seatsService.FindSeat(model.ActualRows[i], model.ActualNumbers[i], model.HallId);
                    if (!orderedSeat.IsReserved)
                    {
                        var ticket = new Ticket
                        {
                            Id = Guid.NewGuid().ToString(),
                            CreatedOn = DateTime.UtcNow,
                            OrderId = model.OrderId,
                            ProjectionId = model.Projection.Id,
                            Price = model.Price / model.TicketsCount,
                            SeatId = orderedSeat.Id,
                        };
                        orderedSeat.IsReserved = true;
                        await this.seatsService.ModifySeatState(orderedSeat);
                        await this.ticketsRepository.AddAsync(ticket);
                    }
                }

                await this.ticketsRepository.SaveChangesAsync();
                return false;
            }

        }

        public bool SameSeatCondition(IList<int> rows, IList<int> numbers)
        {
            for (int i = 0; i < rows.Count - 1; i++)
            {
                for (int j = i; j < numbers.Count - 1; j++)
                {
                    if (rows[i] == rows[j + 1] && numbers[i] == numbers[j + 1])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
