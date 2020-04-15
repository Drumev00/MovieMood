namespace MovieMood.Services.Data.Movies
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MovieMood.Web.ViewModels.Movies.Administration.InputModels;
    using MovieMood.Web.ViewModels.Movies.Administration.ViewModels;

    public interface IMoviesService
    {
        Task CreateAsync(CreateMovieInputModel model);

        IEnumerable<T> All<T>(int? take = null, int skip = 0);

        T GetDetailsById<T>(string id);

        string GetIdByName(string name);

        Task SoftDeleteAsync(string movieId);

        Task EditAsync(EditMovieViewModel model);

        int GetMoviesCount();

        IList<T> GetMoviesByChosenGenre<T>(IList<string> genres);
    }
}
