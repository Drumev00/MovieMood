namespace MovieMood.Web.ViewModels.Movies.Users.ViewModels
{
    using System.Collections.Generic;

    public class MoviesListingViewModel
    {
        public IEnumerable<MovieInfoViewModel> Movies { get; set; }
    }
}
