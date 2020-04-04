namespace MovieMood.Services.Data.Orders
{
    using System;
    using System.Threading.Tasks;

    using MovieMood.Data.Common.Repositories;
    using MovieMood.Data.Models;
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
    }
}
