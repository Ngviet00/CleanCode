using Microsoft.AspNetCore.Mvc;

namespace Clean_Code.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {}

        public IActionResult Index()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = Path.Combine(baseDirectory, "FileSetting", "setting.json");

            ViewBag.RelativePath = relativePath;

            return View();
        }
    }
}
