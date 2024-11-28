using Microsoft.AspNetCore.Mvc;

namespace Otlob.Areas.Restaurants.Controllers
{
    [Area("Restaurants")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
