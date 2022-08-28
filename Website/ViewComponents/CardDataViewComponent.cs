using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Website.Models;
using Website.Models.Interfaces;
namespace Website.ViewComponents
{
    public class CardDataViewComponent : ViewComponent
    {
        private readonly UserRepository Iuser = new UserRepository();
        public IViewComponentResult Invoke()
        {
            List<UserTable> list = new List<UserTable>();
            list = Iuser.getAllUsersEF();
            return View(list);
        }
    }
}
