using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using Website.Models;
using Website.Models.Interfaces;
using Website.Models.VIewModels;

namespace Website.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IWebHostEnvironment Environment;
        private readonly IMapper _mapper;
        private readonly IUserLogin Iuser;

        public UserController(ILogger<UserController> logger, IUserLogin Userlogin, IMapper mapper, IWebHostEnvironment environment)
        {
            Iuser = Userlogin;
            _mapper = mapper;
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
        public ViewResult UserForm()
        {
            return View();
        }
        //when information is recieved from user
        [HttpPost]
        public ViewResult UserForm(List<IFormFile> postedFiles, UserTable user)
        {
            string wwwPath = this.Environment.WebRootPath;
            Iuser.FileUploads(postedFiles,wwwPath);

            if (ModelState.IsValid)
            {
                Iuser.addUserEF(user);
                return View("LogIn");
            }
            else
            {
                //ModelState.AddModelError(string.Empty, "DO NOT LEAVE FIELDS BLANK");
                return View();
            }
           
        }

        //when information is not recieved from user
        [HttpGet]
        public ViewResult LogIn()
        {
            return View();
        }

        //when information is recieved from user
        [HttpPost]
        public ViewResult LogIn(UserLogin user)
        {
           
            if (ModelState.IsValid)
            {
                UserTable tempUser = new UserTable();
                tempUser = Iuser.GetUserLoginEF(user);

                //to check if the user was authenticated (from DB)
                if (tempUser != null)
                {
                    ViewBag.Status = "Success!";
                    ViewBag.Name = user.Username;

                    //cookie code
                    //CookieOptions opts = new CookieOptions();
                    //opts.Expires = System.DateTime.Now.AddMinutes(15);
                    //HttpContext.Response.Cookies.Append("id", user.Id.ToString(), opts);
                    //HttpContext.Response.Cookies.Append("Name", user.Username, opts);

                    //session code
                    HttpContext.Session.SetString("Name", user.Username);

                    //calling another function to save user id for audit columns
                    Iuser.setUserID(tempUser);

                }
                else
                {
                    ViewBag.Status = "Failure!";
                    
                }
                return View("Message");

            }
            else
            {
                return View();
            }
            

        }

        //when information is recieved from user
        [HttpPost]
        public ViewResult MapperLogIn(UserTable user)
        {
            if (ModelState.IsValid)
            {
                UserViewModel tempUser = new UserViewModel();
                UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);
                tempUser = Iuser.GetUserLoginMapper(userViewModel);

                //to check if the user was authenticated (from DB)
                if (tempUser != null)
                {
                    ViewBag.Status = "Success!";
                    ViewBag.Name = user.Username;

                }
                else
                {
                    ViewBag.Status = "Failure!";

                }
                return View("Message");

            }
            else
            {
                return View();
            }


        }
        //passing info of all the users in database
        public ViewResult Home()
        {
            return View(Iuser.getAllUsersEF());
        }
        public ViewResult UserDetails(UserTable User)
        {
            
            return View(User);
        }
        
    }
}
