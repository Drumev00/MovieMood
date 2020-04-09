namespace MovieMood.Web.ViewModels.Tickets.Users.InputModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MovieMood.Web.ViewModels.Projections.Users.ViewModels;

    public class BuyTicketsInputModel
    {
        [Required]
        public int TicketsCount { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ProjectionsTicketInfoViewModel Projection { get; set; }

        [Required]
        public string OrderId { get; set; }

        [Required]
        public int HallId { get; set; }

        [Required]
        public int SeatRow { get; set; }

        public IList<int> ActualRows { get; set; }

        public IEnumerable<int> Rows { get; set; }

        [Required]
        public int SeatNumber { get; set; }

        public IList<int> ActualNumbers { get; set; }

        public IEnumerable<int> Numbers { get; set; }
    }
}
