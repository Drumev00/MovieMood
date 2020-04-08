namespace MovieMood.Services.Data.Orders
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MovieMood.Data.Common.Repositories;
    using MovieMood.Data.Models;
    using MovieMood.Services.Mapping;
    using MovieMood.Web.ViewModels.Orders.Users.InputModels;

    public class OrdersService : IOrdersService
    {
        private readonly IDeletableEntityRepository<Order> ordersRepository;

        public OrdersService(IDeletableEntityRepository<Order> ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public async Task BuyAsync(OrderTicketsInputModel model)
        {
            var order = new Order
            {
                Id = Guid.NewGuid().ToString(),
                PurchaseDate = DateTime.UtcNow,
                TicketQuantity = model.TicketQuantity,
                UserId = model.UserId,
                ProjectionId = model.ProjectionId,
            };

            await this.ordersRepository.AddAsync(order);
            await this.ordersRepository.SaveChangesAsync();
        }

        public int GetHallId(string orderId)
        {
            var order = this.ordersRepository.AllAsNoTracking()
                .Where(s => s.Id == orderId)
                .Select(s => s.Projection.HallId)
                .FirstOrDefault();

            return order;
        }

        public T GetOrder<T>(string projectionId, string userId, int ticketsCount)
        {
            var order = this.ordersRepository.AllAsNoTracking()
                .Where(
                o => o.ProjectionId == projectionId &&
                o.UserId == userId &&
                o.TicketQuantity == ticketsCount)
                .To<T>()
                .FirstOrDefault();
            return order;
        }

        public string GetProjectionId(string orderId)
        {
            var order = this.ordersRepository.AllAsNoTracking()
                .FirstOrDefault(o => o.Id == orderId);

            return order.ProjectionId;
        }
    }
}
