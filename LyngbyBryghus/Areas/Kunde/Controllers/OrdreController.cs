using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LyngbyBryghus.Areas.Kunde.Controllers
{
    public class OrdreController : Controller
    {
        // GET: Kunde/Ordre
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult KundeDetaljer()
        {
            return View();
        }
        public ActionResult KundeOrdre()
        {
            return View();
        }
    }
}