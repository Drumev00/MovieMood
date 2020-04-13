﻿namespace MovieMood.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MovieMood.Services.Data.MovieGenres;
    using MovieMood.Services.Data.Movies;
    using MovieMood.Web.ViewModels.Movies.Users.ViewModels;
    using MovieMood.Common;
    using System;

    [Authorize]
    public class MoviesController : BaseController
    {
        private readonly IMoviesService moviesService;
        private readonly IMovieGenresService movieGenresService;

        public MoviesController(
            IMoviesService moviesService,
            IMovieGenresService movieGenresService)
        {
            this.moviesService = moviesService;
            this.movieGenresService = movieGenresService;
        }

        public IActionResult All(int page = 1)
        {
            var count = this.moviesService.GetMoviesCount();
            var viewModel = new MoviesListingViewModel()
            {
                Movies = this.moviesService.All<MovieInfoViewModel>(GlobalConstants.MoviesCountPerPage, (page - 1) * GlobalConstants.MoviesCountPerPage),
                PagesCount = (int)Math.Ceiling((double)count / GlobalConstants.MoviesCountPerPage),
                CurrentPage = page,
            };

            return this.View(viewModel);
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.moviesService.GetDetailsById<MovieDetailsViewModel>(id);
            viewModel.Genres = this.movieGenresService.GetGenres(id);

            return this.View(viewModel);
        }
    }
}
