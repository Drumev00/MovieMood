namespace MovieMood.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MovieMood.Services.Cloudinary;
    using MovieMood.Services.Data.Movies;
    using MovieMood.Web.ViewModels.Movies.InputModels;

    public class MoviesController : BaseController
    {
        private readonly IMoviesService moviesService;
        private readonly ICloudinaryService cloudinary;

        public MoviesController(IMoviesService moviesService, ICloudinaryService cloudinary)
        {
            this.moviesService = moviesService;
            this.cloudinary = cloudinary;
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

        public IActionResult Upload()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(UploadImageInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.cloudinary.UploadAsync(input.ImagePath);

            return this.Redirect("/Movies/Create");
        }
    }
}
