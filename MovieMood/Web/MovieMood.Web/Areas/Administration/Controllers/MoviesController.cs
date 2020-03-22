namespace MovieMood.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MovieMood.Services.Data.Movies;
    using MovieMood.Web.ViewModels.Movies.InputModels;

    public class MoviesController : AdministrationController
    {
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.moviesService.CreateAsync(input);

            return this.Redirect("/");
        }
    }
}
