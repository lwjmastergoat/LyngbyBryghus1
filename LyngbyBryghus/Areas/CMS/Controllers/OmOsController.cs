using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using LyngbyBrygRepo;
using LyngbyBrygRepo.Factories;
using LyngbyBrygRepo.Models;
using LyngbyBryghus.Helpers;

namespace LyngbyBryghus.Areas.CMS.Controllers
{
    public class OmOsController : Controller
    {

        int Admin = 2;
        int Editor = 1;

        OmFac of = new OmFac();
        FileTools ft = new FileTools();
        // GET: CMS/OmOs
        public ActionResult Index()
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/Login");
            }
            return View(of.GetAll());
        }

        public ActionResult Edit(int ID)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS/OmOs");
            }

            return View(of.Get(ID));
        }

        [HttpPost]
        public ActionResult Edit(OmTabel input)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS/OmOs");
            }


            of.Update(input);


            return Redirect("/CMS/OmOs");
        }
    }
}