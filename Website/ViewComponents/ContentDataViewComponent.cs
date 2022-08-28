using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Website.Models;
using Website.Models.Repositories;

namespace Website.ViewComponents
{
    public class ContentDataViewComponent : ViewComponent
    {
        private readonly ContentDataRepository Icontent = new ContentDataRepository();

        public IViewComponentResult Invoke()
        {
            List<ContentData> list = new List<ContentData>();
            list = Icontent.GetContent();
            return View(list);
        }
    }
}
