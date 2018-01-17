using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Duser;
using LyngbyBrygRepo.Factories;
using LyngbyBrygRepo.Models;
using LyngbyBrygRepo;

namespace LyngbyBryghus.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        OmFac Of = new OmFac();

        public ActionResult Index()
        {
            return View(Of.GetAll());
        }

        // Der skal være en Partial view (sandsynligvis), hvor nyhederne kan være, da der ikke kan være 2 return.


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