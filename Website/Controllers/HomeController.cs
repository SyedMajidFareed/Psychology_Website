using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Website.Models;
using Website.Models.Interfaces;

namespace Website.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IContentData Icontent;

        public HomeController(ILogger<HomeController> logger, IContentData Icontentdata)
        {
            Icontent = Icontentdata;
            _logger = logger;
        }
        public ViewResult index()
        {
            return View();
        }
    }
}