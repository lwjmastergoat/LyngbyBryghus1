using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LyngbyBryghus.Areas.Kunde.Controllers
{
    public class HomeController : Controller
    {
        int Kunde = 2;
        int AbonnentType = 1;
        int AbonnementType = 0;
        // GET: Kunde/Home
        public ActionResult Index()
        {
            if (Session["abonnent"] == null || (int)Session["abonnent"] < AbonnementType)
            {
                return Redirect("/KundeLogin");
            }

            return View();
        }
    }
}