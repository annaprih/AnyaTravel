using Microsoft.AspNetCore.Mvc;

namespace AnyaTravel.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}