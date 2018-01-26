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
using LyngbyBrygRepo.Models;
using LyngbyBrygRepo.Models.R_Models;

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
        OrdreDetaljerTabelFac ordreDetaljerFactory = new OrdreDetaljerTabelFac();
        KundeFac kundeFac = new KundeFac();
        KategoriOrdreTabelFac kotf = new KategoriOrdreTabelFac();
        ProduktOrdreFac pof = new ProduktOrdreFac();


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
            ViewBag.AlleProdukter = pkjf.GetProducts();
            return View();
        }

        [HttpPost]
        public ActionResult OrdreKategorier(OrdreDetaljerTabel_R ordreDetaljer)
        {
            KundeTabel nyKunde = new KundeTabel();
            nyKunde.Adresse = ordreDetaljer.Address;
            nyKunde.Mail = ordreDetaljer.Email;
            nyKunde.Navn = ordreDetaljer.Navn;
            nyKunde.Mobil = int.Parse(ordreDetaljer.Phone);
            nyKunde.Password = "1234"; // Generér eventuelt et random password. Husk at sende til ny brugers email.
            nyKunde.Abonnent = Convert.ToInt32(ordreDetaljer.AbonnementID);
            nyKunde.ByNavn = ordreDetaljer.ByNavn;
            nyKunde.PostNummer = Convert.ToInt32(ordreDetaljer.PostNummer);
            int nyKundeID = kundeFac.Insert(nyKunde);

            OrdreDetaljerTabel ordre = new OrdreDetaljerTabel();
            ordre.BrugerID = nyKundeID;
            ordre.Dato = DateTime.Now;
            ordre.AbonnementID = ordreDetaljer.AbonnementID;
            int ordreID = ordreDetaljerFactory.Insert(ordre);

            foreach (int kategoriID in ordreDetaljer.KategoriID)
            {
                KategoriOrdreTabel kot = new KategoriOrdreTabel();
                kot.KategoriID = kategoriID;
                kot.OrdreDetaljerID = ordreID;
                kotf.Insert(kot);
            }

            foreach (int produktID in ordreDetaljer.ProduktID)
            {
                ProduktOrdreTabel pot = new ProduktOrdreTabel();
                pot.OrdreDetaljerID = ordreID;
                pot.ProduktID = produktID;
                pof.Insert(pot);
            }


            return RedirectToAction("OrderConfirmation");
        }

        public ActionResult OrderConfirmation()
        {
            return View();
        }




        public ActionResult Kontakt()
        {
            return View(kf.Get(1));
        }

        public ActionResult ProduktDetaljer(int ID)
        {
            if (ID != 0)
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