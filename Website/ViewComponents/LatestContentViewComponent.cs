using Microsoft.AspNetCore.Mvc;
using Website.Models.Repositories;
using Website.Models;

namespace Website.ViewComponents
{
    public class LatestContentViewComponent : ViewComponent
    {
        private readonly ContentDataRepository Icontent = new ContentDataRepository();

        public IViewComponentResult Invoke()
        {
            List<ContentData> list = new List<ContentData>();
            list = Icontent.GetLatestContent();
            return View(list);
        }
    }
}
