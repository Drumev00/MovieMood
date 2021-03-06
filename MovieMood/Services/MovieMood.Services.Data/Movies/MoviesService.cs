﻿namespace MovieMood.Services.Data.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MovieMood.Data.Common.Repositories;
    using MovieMood.Data.Models;
    using MovieMood.Services.Data.MovieGenres;
    using MovieMood.Services.Mapping;
    using MovieMood.Web.ViewModels.Movies.Administration.InputModels;
    using MovieMood.Web.ViewModels.Movies.Administration.ViewModels;

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

        public IEnumerable<T> All<T>(int? take = null, int skip = 0)
        {
            var movies = this.moviesRepository.All()
                .OrderByDescending(m => m.CreatedOn)
                .Skip(skip);
            if (take.HasValue)
            {
                movies = movies.Take(take.Value);
            }

            return movies.To<T>().ToList();
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
                Trailer = model.Trailer,
            };

            await this.moviesRepository.AddAsync(movie);
            await this.moviesRepository.SaveChangesAsync();

            foreach (var item in model.AreChecked)
            {
                await this.movieGenresService.CreateMappingAsync(movie.Id, item);
            }
        }

        public async Task EditAsync(EditMovieViewModel model)
        {
            var movieFromBase = this.moviesRepository.All()
                .Where(m => m.Id == model.Id)
                .FirstOrDefault();

            movieFromBase.Name = model.Name;
            movieFromBase.Resume = model.Resume;
            movieFromBase.ImagePath = model.ImagePath;
            movieFromBase.Duration = model.Duration;
            movieFromBase.Cast = model.Cast;
            movieFromBase.Director = model.Director;
            movieFromBase.Trailer = model.Trailer;

            this.moviesRepository.Update(movieFromBase);
            await this.moviesRepository.SaveChangesAsync();
        }

        public string GetIdByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Parameter \"name\" cannot be null");
            }

            var movie = this.moviesRepository.AllAsNoTracking()
                .Where(m => m.Name.ToLower() == name.ToLower())
                .Select(m => m.Id)
                .FirstOrDefault();

            return movie;
        }

        public T GetDetailsById<T>(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Parameter \"id\" cannot be null");
            }

            var movie = this.moviesRepository.All()
                .Where(m => m.Id == id)
                .To<T>()
                .FirstOrDefault();

            return movie;
        }

        public async Task SoftDeleteAsync(string movieId)
        {
            if (movieId == null)
            {
                throw new ArgumentNullException("Parameter \"movieId\" cannot be null");
            }

            var movie = this.moviesRepository.All()
                .Where(m => m.Id == movieId)
                .FirstOrDefault();

            await this.movieGenresService.SoftDeleteGenresAsync(movie.Id);
            this.moviesRepository.Delete(movie);
            await this.moviesRepository.SaveChangesAsync();
        }

        public int GetMoviesCount()
        {
            return this.moviesRepository.AllAsNoTracking().Count();
        }

        public IList<T> GetMoviesByChosenGenre<T>(IList<string> genres)
        {
            var movieIds = this.movieGenresService.GetMovieIdsByGenres(genres);
            var movies = new List<T>();

            for (int i = 0; i < movieIds.Count; i++)
            {
                var movieFromBase = this.moviesRepository.AllAsNoTracking()
                    .Where(m => m.Id == movieIds[i])
                    .To<T>()
                    .FirstOrDefault();

                movies.Add(movieFromBase);
            }

            return movies;
        }
    }
}
