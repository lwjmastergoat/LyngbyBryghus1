using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Duser;
using LyngbyBrygRepo.Factories;
using LyngbyBrygRepo.Models;

namespace LyngbyBryghus.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        KontaktFac kf = new KontaktFac();
        public ActionResult Index()
        {
            return View();
        }

        ProduktFac Pf = new ProduktFac();

        public ActionResult Produkter()
        {
            return View(Pf.GetProducts());
        }

        public ActionResult Kontakt()
        {
            return View(kf.Get(1));
        }






















    }
}