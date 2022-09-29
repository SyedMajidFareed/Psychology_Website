using Microsoft.AspNetCore.Mvc;
using Website.Models.Interfaces;
using Website.Models;
using System.Web.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;

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
        public IActionResult AddData([FromBody] ContentData data)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "DO NOT LEAVE FIELDS BLANK");
                return BadRequest("Enter required fields");

            }
            //Insert code;
            else
            {
                Icontent.addContent(data);
                return this.Ok($"Data received!");
            }
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
        public IActionResult ContentList()
        {
            return View(Icontent.GetContent());
        }
        public IActionResult search(string SearchBy, string SearchValue)
        {
            //ContentData temp = new ContentData();
            //temp = Icontent.searchContent(SearchBy);
            //if(temp!=null)
            //{
            //    ViewBag.x = "success";
            //    return View(temp);
            //}
            //else
            //{
            //    ViewBag.x = "failure";
            //    return View();
            //}
            return Json(Icontent.searchContent(SearchBy), JsonRequestBehavior.AllowGet);
        }
    }
}
