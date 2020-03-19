namespace MovieMood.Data.Models
{
    using MovieMood.Data.Models.Enums;

    public class MovieGenres
    {
        public string MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public Genre Genre { get; set; }
    }
}
