using CleanCode.Common;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Code.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        { }

        public IActionResult Index()
        {
            Log.Info("test log");
            return View();
        }
    }
}
