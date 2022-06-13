using Microsoft.AspNetCore.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class UserController : Controller
    {
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
        public ViewResult UserForm(UserTable user)
        {
            if (ModelState.IsValid)
            {
                UserRepository.addUserEF(user);
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
        public ViewResult LogIn(UserTable user)
        {





            //modelvalidation needs to be checked





            if (!ModelState.IsValid)
            {
                UserTable tempUser = new UserTable();
                tempUser = UserRepository.GetUserEF(user);

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
            return View(UserRepository.getAllUsersEF());
        }
        public ViewResult UserDetails(UserTable User)
        {
            
            return View(User);
        }
    }
}
