namespace MovieMood.Web.ViewModels.Movies.Users.ViewModels
{
    using System.Collections.Generic;

    public class MoviesListingViewModel
    {
        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public IEnumerable<MovieInfoViewModel> Movies { get; set; }
    }
}
