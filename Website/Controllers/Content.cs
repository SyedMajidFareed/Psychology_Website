using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
    public class Content : Controller
    {
        public IActionResult Latest()
        {
            return View();
        }
        public IActionResult Quranic()
        {
            return View();
        }
        public IActionResult Modern()
        {
            return View();
        }
    }
}
