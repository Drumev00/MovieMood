namespace MovieMood.Web.ViewModels.Orders.Users.InputModels
{
    using MovieMood.Data.Models;
    using MovieMood.Services.Mapping;

    public class OrderInfoViewModel : IMapFrom<Order>
    {
        public string Id { get; set; }

        public int TicketQuantity { get; set; }
    }
}
