﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace Otlob.Areas.ResturantAdmin.Controllers
{
    public class HomeController : Controller
    {
        [Area("ResturantAdmin")]
        [Authorize(Roles = SD.resturanrAdmin)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
