namespace MovieMood.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MovieMood.Services.Data.Movies;
    using MovieMood.Web.ViewModels.Movies.Administration.InputModels;
    using MovieMood.Web.ViewModels.Movies.Administration.ViewModels;

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

            return this.Redirect("/Movies/All");
        }

        public IActionResult Edit(string movieId)
        {
            var viewModel = this.moviesService.GetDetailsById<EditMovieViewModel>(movieId);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditMovieViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.moviesService.EditAsync(model);

            return this.Redirect($"/Movies/Details?id={model.Id}");
        }

        public async Task<IActionResult> Delete(string movieId)
        {
            await this.moviesService.SoftDeleteAsync(movieId);

            return this.Redirect("/Movies/All");
        }
    }
}
