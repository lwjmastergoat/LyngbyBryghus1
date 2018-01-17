using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LyngbyBrygRepo.Models;
using LyngbyBrygRepo.Factories;
using LyngbyBrygRepo;


namespace LyngbyBryghus.Areas.CMS.Controllers
{
    public class AdminController : Controller
    {

        int Admin = 2;
        int Writer = 1;


        AdminFac af = new AdminFac();


        // GET: CMS/Admin
        public ActionResult Index()
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Admin)
            {
                return Redirect("/CMS/Admin");
            }

            return View(af.GetAll());
        }
    }
}