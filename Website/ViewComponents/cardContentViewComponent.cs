using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Website.Models;
using Website.Models.Interfaces;
namespace Website.ViewComponents
{
    public class cardContentViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
