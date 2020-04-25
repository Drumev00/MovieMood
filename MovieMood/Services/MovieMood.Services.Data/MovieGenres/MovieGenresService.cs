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
            if (movieId == null || genre == null)
            {
                throw new ArgumentNullException("Both parameters should have value other than null");
            }

            var movieGenres = new MovieGenres
            {
                MovieId = movieId,
                Genre = (Genre)Enum.Parse(typeof(Genre), genre),
            };

            await this.movieGenresRepository.AddAsync(movieGenres);
            await this.movieGenresRepository.SaveChangesAsync();
        }

        public IList<string> GetMovieIdsByGenres(IList<string> genres)
        {
            var chosenMovies = new List<string>();
            for (int i = 0; i < genres.Count(); i++)
            {
                // This throws EF exception
                //var movies = this.movieGenresRepository.All()
                //    .Where(m => m.Genre.ToString() == genres[i])
                //    .Select(m => m.MovieId)
                //    .ToList();
                var movies = this.movieGenresRepository.All()
                    .ToList();
                movies = movies.Where(m => m.Genre.ToString() == genres[i])
                    .ToList();

                chosenMovies.AddRange(movies.Select(g => g.MovieId));
            }

            return chosenMovies;
        }

        public IEnumerable<string> GetGenresByMovieId(string movieId)
        {
            if (movieId == null)
            {
                throw new ArgumentNullException("Parameter \"movieId\" must have value other than null");
            }

            var genres = this.movieGenresRepository.All()
                .Where(g => g.MovieId == movieId)
                .Select(g => g.Genre.ToString())
                .ToList();

            return genres;
        }

        public async Task SoftDeleteGenresAsync(string movieId)
        {
            if (movieId == null)
            {
                throw new ArgumentNullException("Parameter \"movieId\" must have value other than null");
            }

            var movieGenres = this.movieGenresRepository.All()
                .Where(mg => mg.MovieId == movieId)
                .ToList();

            for (int i = 0; i < movieGenres.Count; i++)
            {
                this.movieGenresRepository.Delete(movieGenres[i]);
            }

            await this.movieGenresRepository.SaveChangesAsync();
        }

        public IList<string> GetAllGenres()
        {
            var genres = this.movieGenresRepository.AllAsNoTracking()
                .Select(g => g.Genre.ToString())
                .ToList();

            return genres;
        }
    }
}
