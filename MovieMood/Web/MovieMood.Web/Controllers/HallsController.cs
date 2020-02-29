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
    }
}
