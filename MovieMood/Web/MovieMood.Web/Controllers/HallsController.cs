namespace MovieMood.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MovieMood.Services.Data.Halls;
    using MovieMood.Web.ViewModels.Halls.InputModels;
    using MovieMood.Web.ViewModels.Halls.ViewModels;

    public class HallsController : BaseController
    {
        private readonly IHallsService hallsService;

        public HallsController(IHallsService hallsService)
        {
            this.hallsService = hallsService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateHallInputModel input)
        {
            // TODO: Check Model state!
            await this.hallsService.CreateAsync(input.Name);

            return this.Redirect("/Home/Index");
        }

        [HttpGet("/Halls")]
        public IActionResult Choose()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult All()
        {
            var hallList = new HallListingViewModel
            {
                Halls = this.hallsService.All(),
            };

            return this.View(hallList);
        }

        [Authorize]
        public IActionResult Details(int hallId)
        {
            var viewModel = this.hallsService.GetDetailsById(hallId);

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int hallId)
        {
           await this.hallsService.SoftDelete(hallId);

           return this.Redirect("/Halls/All");
        }
    }
}
