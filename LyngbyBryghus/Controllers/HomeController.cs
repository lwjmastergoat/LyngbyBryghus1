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
        Forsiden Forsiden = new Forsiden();
        ProduktKategoriJoinFac pkjf = new ProduktKategoriJoinFac();
        ProduktDetaljerFac pdf = new ProduktDetaljerFac();


        public ActionResult Index()
        {
            Forsiden.Nyheder = nf.GetAll();
            Forsiden.Overskrift = Of.Get(1).Overskrift;
            Forsiden.Indhold = Of.Get(1).Indhold;

            return View(Forsiden);
        }

        public ActionResult Produkter()
        {
            return View(pkjf.GetProducts());
        }

        public ActionResult Bestilling()
        {
            return View(pkjf.GetProducts());
        }

        public ActionResult Kontakt()
        {
            return View(kf.Get(1));
        }

        public ActionResult ProduktDetaljer(int ID)
        {
            if(ID != 0)
            {
                try
                {
                    return View(pdf.GetDetails(ID));
                }

                catch
                {
                    return Redirect("/Home/Index/");
                }
            }

            else
            {
                return Redirect("/Home/Index/");
            }
        }



    }
}