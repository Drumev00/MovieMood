﻿namespace MovieMood.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MovieMood.Services.Data.Halls;
    using MovieMood.Services.Data.Seats;
    using MovieMood.Web.ViewModels.Halls.Administration.InputModels;
    using MovieMood.Web.ViewModels.Halls.Administration.ViewModels;

    public class HallsController : AdministrationController
    {
        private readonly IHallsService hallsService;
        private readonly ISeatsService seatsService;

        public HallsController(
            IHallsService hallsService,
            ISeatsService seatsService)
        {
            this.hallsService = hallsService;
            this.seatsService = seatsService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHallInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.hallsService.CreateAsync(input.Name);

            return this.RedirectToAction("All");
        }

        public IActionResult Choose()
        {
            return this.View();
        }

        public IActionResult All()
        {
            var hallList = new HallListingViewModel
            {
                Halls = this.hallsService.All<HallInfoViewModel>(),
            };

            return this.View(hallList);
        }

        public IActionResult Details(int hallId)
        {
            var viewModel = this.hallsService.GetDetailsById<HallDetailsViewModel>(hallId);

            return this.View(viewModel);
        }

        public IActionResult Free(int hallId)
        {
            this.seatsService.FreeTheSeats(hallId);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Delete(int hallId)
        {
            await this.hallsService.SoftDeleteHallAsync(hallId);

            return this.RedirectToAction("All");
        }
    }
}
