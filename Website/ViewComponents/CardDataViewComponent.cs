using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Website.Models;
using Website.Models.Interfaces;
using Website.Models.Repositories;

namespace Website.ViewComponents
{
    public class CardDataViewComponent : ViewComponent
    {
        private readonly TherapistRepository Itherapist = new TherapistRepository();
        public IViewComponentResult Invoke()
        {
            List<Therapist> list = new List<Therapist>();
            list = Itherapist.getAllTherapistEF();
            return View(list);
        }
    }
}
