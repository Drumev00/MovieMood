namespace MovieMood.Web.ViewModels.Movies.Administration.ViewModels
{
    using System.Collections.Generic;

    public class AdminMoviesListingViewModel
    {
        public IEnumerable<AdminMovieInfoViewModel> Movies { get; set; }

    }
}
