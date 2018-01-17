using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Duser;
using LyngbyBrygRepo.Factories;
using LyngbyBrygRepo.Models;
using LyngbyBrygRepo;
using LyngbyBryghus.ViewModels;

namespace LyngbyBryghus.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        OmFac Of = new OmFac();
        ProduktFac Pf = new ProduktFac();
        KontaktFac kf = new KontaktFac();
        NyhedsFac nf = new NyhedsFac();

        public ActionResult Index()
        {
            Forsiden Forsiden = new Forsiden();
            Forsiden.Nyheder = nf.GetAll();
            
            return View(Forsiden);
        }

        // Der skal være en Partial view (sandsynligvis), hvor nyhederne kan være, da der ikke kan være 2 return.


        

        public ActionResult Produkter()
        {
            return View(Pf.GetProducts());
        }

        public ActionResult Bestilling()
        {
            return View();
        }

        public ActionResult Kontakt()
        {
            return View(kf.Get(1));
        }






















    }
}