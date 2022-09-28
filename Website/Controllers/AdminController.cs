using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Website.Models;
using Website.Models.Interfaces;

namespace Website.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IWebHostEnvironment Environment;
        private readonly IAdmin Iadmin;

        public AdminController(ILogger<AdminController> logger, IAdmin adminlogin, IWebHostEnvironment environment)
        {
            Iadmin= adminlogin;
            _logger = logger;
            Environment = environment;
        }
        //when information is not recieved from user
        [HttpGet]
        public ViewResult AdminLogin()
        {
            return View();
        }

        //when information is recieved from user
        [HttpPost]
        public ViewResult AdminLogin(Admin user)
        {
            if (ModelState.IsValid)
            {
                Admin tempUser = new Admin();
                tempUser = Iadmin.login(user);

                //to check if the user was authenticated (from DB)
                if (tempUser != null)
                {
                    ViewBag.Status = "Success!";
                    ViewBag.Name = user.Name;

                }
                else
                {
                    ViewBag.Status = "Failure!";

                }
                return View("AdminView");

            }
            else
            {
                return View();
            }


        }
        public IActionResult DeleteUser(int id)
        {
            
            Iadmin.deleteUser(id);
            return View("AdminView");
        }
        public IActionResult DeleteTherapist(int id)
        {

            Iadmin.deleteTherapist(id);
            return View("AdminView");
        }
        public IActionResult DeleteContent(int id)
        {

            Iadmin.deleteContent(id);
            return View("AdminView");
        }
    }
}
