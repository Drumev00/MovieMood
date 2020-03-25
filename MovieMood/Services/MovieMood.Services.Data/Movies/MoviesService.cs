namespace MovieMood.Services.Data.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MovieMood.Data.Common.Repositories;
    using MovieMood.Data.Models;
    using MovieMood.Services.Data.MovieGenres;
    using MovieMood.Services.Mapping;
    using MovieMood.Web.ViewModels.Movies.Administration.InputModels;

    public class MoviesService : IMoviesService
    {
        private readonly IDeletableEntityRepository<Movie> moviesRepository;
        private readonly IMovieGenresService movieGenresService;

        public MoviesService(
            IDeletableEntityRepository<Movie> moviesRepository,
            IMovieGenresService movieGenresService)
        {
            this.moviesRepository = moviesRepository;
            this.movieGenresService = movieGenresService;
        }

        public IEnumerable<T> All<T>()
        {
            var movies = this.moviesRepository.AllAsNoTracking()
                .To<T>()
                .ToList();

            return movies;
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

        public T GetDetailsById<T>(string id)
        {
            var movie = this.moviesRepository.All()
                .Where(m => m.Id == id)
                .To<T>()
                .FirstOrDefault();

            return movie;
        }
    }
}
