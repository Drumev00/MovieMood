namespace MovieMood.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using MovieMood.Data.Common.Models;

    public class Seat : BaseDeletableModel<int>
    {
        [Required]
        public int Row { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public bool IsReserved { get; set; }

        // Nav props:
        public virtual int HallId { get; set; }

        public virtual Hall Hall { get; set; }
    }
}
