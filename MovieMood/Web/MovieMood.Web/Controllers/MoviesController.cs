namespace MovieMood.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MovieMood.Services.Cloudinary;

    public class MoviesController : BaseController
    {
        private readonly ICloudinaryService cloudinary;

        public MoviesController(ICloudinaryService cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public IActionResult Create()
        {
            return this.View();
        }


    }
}
