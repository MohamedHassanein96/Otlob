using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Otlob.Core.IUnitOfWorkRepository;
using Otlob.Core.ViewModel;
using RepositoryPatternWithUOW.Core.Models;
using Utility;

namespace Otlob.Areas.Restaurants.Controllers
{
    [Area("Restaurants")]
    public class RestaurantController : Controller
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        public RestaurantController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create( )
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantVM restaurantVM)
        {
            if (ModelState.IsValid)
            {
                Restaurant restaurant = new Restaurant
                {
                    Id = 0,
                    Name = restaurantVM.Name,
                    Email = restaurantVM.Email,
                    Phone = restaurantVM.Phone,
                    Address = restaurantVM.Address,
                    Descriptions = restaurantVM.Descriptions,
                    DeliveryFee = restaurantVM.DeliveryFee,
                    DeliveryDuration = restaurantVM.DeliveryDuration
                };
                if (restaurantVM.Logo != null)
                {
                    var LogoFileName = Methods.UploadImg(restaurantVM.Logo);
                    restaurant.Logo = LogoFileName;
                    _unitOfWorkRepository.Restaurants.Create(restaurant);
                    _unitOfWorkRepository.SaveChanges();
                    return View("Indexx");
                }
                else
                {
                    ModelState.AddModelError("Logo", "Logo is required.");
                    return View(restaurantVM); 
                }
            }
            else
            {
                return View(restaurantVM);
            }
        }

    }
}
