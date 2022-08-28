using Microsoft.AspNetCore.Mvc;
using Website.Models.Interfaces;

namespace Website.Controllers
{
    public class ContentController : Controller
    {
        private readonly ILogger<ContentController> _logger;
        private readonly IContentData Icontent;

        public ContentController(ILogger<ContentController> logger, IContentData Icontentdata)
        {
            Icontent = Icontentdata;
            _logger = logger;
        }
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
