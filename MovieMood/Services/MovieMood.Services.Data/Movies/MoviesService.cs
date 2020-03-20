namespace MovieMood.Services.Data.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MovieMood.Data.Common.Repositories;
    using MovieMood.Data.Models;
    using MovieMood.Services.Cloudinary;
    using MovieMood.Services.Data.MovieGenres;
    using MovieMood.Web.ViewModels.Movies.InputModels;

    public class MoviesService : IMoviesService
    {
        private readonly IDeletableEntityRepository<Movie> moviesRepository;
        private readonly IMovieGenresService movieGenresService;
        private readonly ICloudinaryService cloudinary;

        public MoviesService(
            IDeletableEntityRepository<Movie> moviesRepository,
            IMovieGenresService movieGenresService,
            ICloudinaryService cloudinary)
        {
            this.moviesRepository = moviesRepository;
            this.movieGenresService = movieGenresService;
            this.cloudinary = cloudinary;
        }

        public async Task CreateAsync(CreateMovieInputModel model)
        {
            var movie = new Movie
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                ImagePath = model.ImagePath,
                Resume = model.Resume,
                Duration = model.Duration,
                Cast = model.Cast,
                Director = model.Director,
                CreatedOn = DateTime.UtcNow,
            };

            await this.moviesRepository.AddAsync(movie);
            await this.moviesRepository.SaveChangesAsync();

            foreach (var item in model.AreChecked)
            {
                await this.movieGenresService.CreateMappingAsync(movie.Id, item);
            }
        }
    }
}
