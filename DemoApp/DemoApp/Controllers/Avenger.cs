using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class Avenger : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
