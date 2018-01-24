using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LyngbyBrygRepo.Models;
using LyngbyBrygRepo.Factories;
using LyngbyBrygRepo;

namespace LyngbyBryghus.Controllers
{
    public class KundeLoginController : Controller
    {
        KundeFac kf = new KundeFac();
        // GET: KundeLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Navn, string Password)
        {
            KundeTabel kunde = kf.Login(Navn, Password);

            if (kunde.Navn != null)
            {
                Session["id"] = kunde.ID;
                Session["abonnent"] = kunde.Abonnent;
                return Redirect("/Kunde/");
            }
            else
            {
                ViewBag.Msg = "<b>Forkert login</b>";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("id");
            Session.Remove("abonnent");
            return Redirect("/Home/Index");
        }
    }
}