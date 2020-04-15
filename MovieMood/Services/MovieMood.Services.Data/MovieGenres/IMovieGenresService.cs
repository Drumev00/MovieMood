namespace MovieMood.Services.Data.MovieGenres
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMovieGenresService
    {
        Task CreateMappingAsync(string movieId, string genre);

        IEnumerable<string> GetGenresByMovieId(string movieId);

        Task SoftDeleteGenresAsync(string movieId);

        IList<string> GetMovieIdsByGenres(IList<string> genres);

        IList<string> GetAllGenres();
    }
}
