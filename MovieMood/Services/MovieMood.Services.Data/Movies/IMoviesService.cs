﻿namespace MovieMood.Services.Data.Movies
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MovieMood.Web.ViewModels.Movies.Administration.InputModels;
    using MovieMood.Web.ViewModels.Movies.Administration.ViewModels;

    public interface IMoviesService
    {
        Task CreateAsync(CreateMovieInputModel model);

        IEnumerable<T> All<T>();

        T GetDetailsById<T>(string id);

        Task SoftDeleteAsync(string movieId);

        Task EditAsync(EditMovieViewModel model);
    }
}
