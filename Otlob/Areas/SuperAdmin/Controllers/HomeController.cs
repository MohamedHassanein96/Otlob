using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace Otlob.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    [Authorize(Roles = SD.superAdminRole)]
    public class HomeController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }        
    }
}
