namespace MovieMood.Services.Data.MovieGenres
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MovieMood.Data.Common.Repositories;
    using MovieMood.Data.Models;
    using MovieMood.Data.Models.Enums;

    public class MovieGenresService : IMovieGenresService
    {
        private readonly IDeletableEntityRepository<MovieGenres> movieGenresRepository;

        public MovieGenresService(IDeletableEntityRepository<MovieGenres> movieGenresRepository)
        {
            this.movieGenresRepository = movieGenresRepository;
        }

        public async Task CreateMappingAsync(string movieId, string genre)
        {
            var movieGenres = new MovieGenres
            {
                MovieId = movieId,
                Genre = (Genre)Enum.Parse(typeof(Genre), genre),
            };

            await this.movieGenresRepository.AddAsync(movieGenres);
            await this.movieGenresRepository.SaveChangesAsync();
        }

        public IEnumerable<string> GetGenres(string movieId)
        {
            var genres = this.movieGenresRepository.All()
                .Where(g => g.MovieId == movieId)
                .Select(g => g.Genre.ToString())
                .ToList();

            return genres;
        }

        public async Task SoftDeleteGenresAsync(string movieId)
        {
            var movieGenres = this.movieGenresRepository.All()
                .Where(mg => mg.MovieId == movieId)
                .ToList();

            for (int i = 0; i < movieGenres.Count; i++)
            {
                this.movieGenresRepository.Delete(movieGenres[i]);
            }

            await this.movieGenresRepository.SaveChangesAsync();
        }
    }
}
