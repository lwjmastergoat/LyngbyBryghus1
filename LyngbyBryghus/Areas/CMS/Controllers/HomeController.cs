using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LyngbyBrygRepo.Factories;
using LyngbyBrygRepo.Models;
using LyngbyBrygRepo;

namespace LyngbyBryghus.Areas.CMS.Controllers
{
    public class HomeController : Controller
    {

        int Admin = 2;
        int Writer = 1;
        // GET: CMS/Home
        public ActionResult Index()
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Writer)
            {
                return Redirect("/Login");
            }

            return View();
        }
    }
}