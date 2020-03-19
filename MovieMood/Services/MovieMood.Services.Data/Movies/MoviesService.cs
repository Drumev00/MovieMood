namespace MovieMood.Services.Data.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MovieMood.Data.Common.Repositories;
    using MovieMood.Data.Models;
    using MovieMood.Web.ViewModels.Movies.InputModels;

    public class MoviesService : IMoviesService
    {
        private readonly IDeletableEntityRepository<Movie> moviesRepository;

        public MoviesService(IDeletableEntityRepository<Movie> moviesRepository)
        {
            this.moviesRepository = moviesRepository;
        }

        public async Task CreateAsync(CreateMovieInputModel model)
        {
            var movie = new Movie
            {
                Name = model.Name,
                ImagePath = model.ImagePath,
                Resume = model.Resume,
                Duration = model.Duration,
                Cast = model.Cast,
                Director = model.Director,
            };

            await this.moviesRepository.AddAsync(movie);
            await this.moviesRepository.SaveChangesAsync();
        }
    }
}
