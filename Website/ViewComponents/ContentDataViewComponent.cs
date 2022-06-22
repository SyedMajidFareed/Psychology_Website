using Microsoft.AspNetCore.Mvc;

namespace Website.ViewComponents
{
    public class ContentDataViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
