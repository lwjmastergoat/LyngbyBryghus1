using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LyngbyBrygRepo.Factories;

namespace LyngbyBryghus.Controllers
{
    public class HomeController : Controller
    {
        KontaktFac kf = new KontaktFac();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Kontakt()
        {
            return View(kf.Get(1));
        }

        public ActionResult Bestilling()
        {
            return View();
        }
    }
}