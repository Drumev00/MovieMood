namespace MovieMood.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using MovieMood.Data.Common.Models;

    public class Ticket : BaseDeletableModel<string>
    {
        [Required]
        public decimal Price { get; set; }

        // Nav props:
        public int SeatId { get; set; }

        public virtual Seat Seat { get; set; }

        public string ProjectionId { get; set; }

        public virtual Projection Projection { get; set; }

        public string OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
