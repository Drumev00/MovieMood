namespace MovieMood.Web.ViewModels.Orders.Users.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using MovieMood.Data.Models;
    using MovieMood.Services.Mapping;

    public class OrderTicketsInputModel : IMapTo<Order>
    {
        [Required]
        public int TicketQuantity { get; set; }

        [Required]
        public string ProjectionId { get; set; }

        public string UserId { get; set; }
    }
}
