﻿using Microsoft.AspNetCore.Mvc;
using Website.Models.Interfaces;
using Website.Models;

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
    }
}
