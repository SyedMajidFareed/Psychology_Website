using Microsoft.AspNetCore.Mvc;
using Website.Models.Interfaces;
using Website.Models;

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
            string path = Path.Combine(wwwPath, "TUploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in postedFiles)
            {
                var fileName = Path.GetFileName(file.FileName);
                var pathWithFileName = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                    ViewBag.Message = "file uploaded successfully";
                }
                //C:\Users\MajidFareed\source\repos\Website\Website\wwwroot\Uploads\IMG_20220219_182841-01-resize.jpeg
            }
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
                TherapistLogin tempUser = new TherapistLogin();
                tempUser = Itherapist.GetTherapistLogin(tuser);

                //to check if the user was authenticated (from DB)
                if (tempUser != null)
                {
                    ViewBag.Status = "Success!";
                    ViewBag.Name = tuser.TUsername;

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
