namespace MovieMood.Web.ViewModels.Movies.Users.ViewModels
{
    using MovieMood.Data.Models;
    using MovieMood.Services.Mapping;

    public class MovieProjectionViewModel : IMapFrom<Movie>
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }
    }
}
