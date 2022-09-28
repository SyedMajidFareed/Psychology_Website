using Microsoft.AspNetCore.Mvc;
using Website.Models.Interfaces;
using Website.Models;
using System.Collections.Generic;

namespace Website.Controllers
{
    public class TherapistController : Controller
    {
        private readonly ILogger<TherapistController> _logger;
        private readonly IWebHostEnvironment Environment;
        private readonly ITherapist Itherapist;

        public TherapistController(ILogger<TherapistController> logger, ITherapist TUserlogin, IWebHostEnvironment environment)
        {
            Itherapist = TUserlogin;
            _logger = logger;
            Environment = environment;
        }
        //this is the default view
        public ViewResult Index()
        {
            return View();
        }

        //when information is not recieved from user
        [HttpGet]
        public ViewResult TSignup()
        {
            return View();
        }
        //when information is recieved from user
        [HttpPost]
        public ViewResult TSignup(List<IFormFile> postedFiles, Therapist tuser)
        {
            string wwwPath = this.Environment.WebRootPath;
            Itherapist.FileUploads(postedFiles, wwwPath);
            if (ModelState.IsValid)
            {
                Itherapist.addTherapistEF(tuser);
                return View("TLogin");
            }
            else
            {
                //ModelState.AddModelError(string.Empty, "DO NOT LEAVE FIELDS BLANK");
                return View();
            }

        }

        //when information is not recieved from user
        [HttpGet]
        public ViewResult TLogin()
        {
            return View();
        }

        //when information is recieved from user
        [HttpPost]
        public ViewResult TLogin(TherapistLogin tuser)
        {
            if (ModelState.IsValid)
            {
                Therapist tempUser = new Therapist();
                tempUser = Itherapist.GetTherapistLogin(tuser);

                //to check if the user was authenticated (from DB)
                if (tempUser != null)
                {
                    ViewBag.Status = "Success!";
                    ViewBag.Name = tuser.TUsername;
                    ////cookie code
                    //CookieOptions opts = new CookieOptions();
                    //opts.Expires = System.DateTime.Now.AddMinutes(15);
                    ////HttpContext.Response.Cookies.Append("id", user.Id.ToString(), opts);
                    //HttpContext.Response.Cookies.Append("TName", tuser.TUsername, opts);

                    //session code
                    HttpContext.Session.SetString("Name", tuser.TUsername);
                    
                    //calling another function to save therapist id for audit columns
                    Itherapist.setTherapistID(tempUser);


                }
                else
                {
                    ViewBag.Status = "Failure!";

                }
                return View("TProfile");

            }
            else
            {
                return View();
            }


        }
    }
}
