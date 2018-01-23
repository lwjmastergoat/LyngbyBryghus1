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
    public class KundeController : Controller
    {
        int Admin = 2;
        int Editor = 1;

        KundeFac kf = new KundeFac();
        FileTools ft = new FileTools();
        // GET: CMS/Kunde
        public ActionResult Index()
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/Login");
            }

            return View(kf.GetAll());
        }

        public ActionResult AddNew()
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddNew(KundeTabel input)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS");
            }


            kf.Insert(input);

            return Redirect("/CMS/Kunde");
        }

        public ActionResult Delete(int ID)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS/Kunde");
            }



            kf.Delete(ID);

            return Redirect("/CMS/Kunde");
        }

        public ActionResult Edit(int ID)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS/Kunde");
            }

            return View(kf.Get(ID));
        }

        [HttpPost]
        public ActionResult Edit(KundeTabel input)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS/Kunde");
            }
            kf.Update(input);


            return Redirect("/CMS/Kunde");
        }
    }
}