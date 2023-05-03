 using Microsoft.AspNetCore.Mvc;

namespace ProgrammersBlog.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
