namespace MovieMood.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MovieMood.Services.Data.Movies;
    using MovieMood.Web.ViewModels.Movies.Users.ViewModels;

    [Authorize]
    public class MoviesController : BaseController
    {
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        public IActionResult All()
        {
            var viewModel = new MoviesListingViewModel()
            {
                Movies = this.moviesService.All<MovieInfoViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
