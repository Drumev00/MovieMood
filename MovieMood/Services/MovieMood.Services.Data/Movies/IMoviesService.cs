namespace MovieMood.Services.Data.Movies
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MovieMood.Web.ViewModels.Movies.Administration.InputModels;

    public interface IMoviesService
    {
        Task CreateAsync(CreateMovieInputModel model);

        IEnumerable<T> All<T>();

        T GetDetailsById<T>(string id);
    }
}
