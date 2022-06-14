using Microsoft.AspNetCore.Mvc;
using Website.Models;
namespace Website.ViewComponents
{
    public class CardDataViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<UserTable> list = new List<UserTable>();
            list = UserRepository.getAllUsersEF();
            return View(list);
        }
    }
}
