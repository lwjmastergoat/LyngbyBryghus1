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
    public class KontaktController : Controller
    {

        int Admin = 2;
        int Editor = 1;

        KontaktFac kf = new KontaktFac();
        FileTools ft = new FileTools();
        // GET: CMS/Kontakt
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
        public ActionResult AddNew(KontaktTabel input, HttpPostedFileBase Photo)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS");
            }


            input.Billede = null;

            if (Photo != null)
            {
                string imagePath = Request.PhysicalApplicationPath + "/Content/Images/Kontakt/";
                input.Billede = ft.ImageUpload(Photo, imagePath);
            }


            kf.Insert(input);

            return Redirect("/CMS/Kontakt");
        }

        public ActionResult Delete(int ID)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS/Kontakt");
            }



            KontaktTabel kontakt = kf.Get(ID);

            if (kontakt.Billede != null)
            {
                string imagePath = Request.PhysicalApplicationPath + "/Content/Images/Kontakt/" + kontakt.Billede;

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            kf.Delete(ID);

            return Redirect("/CMS/Kontakt");
        }

        public ActionResult Edit(int ID)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS/Kontakt");
            }

            return View(kf.Get(ID));
        }

        [HttpPost]
        public ActionResult Edit(KontaktTabel input, HttpPostedFileBase Photo)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS/Kontakt");
            }


            input.Billede = null;

            if (Photo != null)
            {
                KontaktTabel kontakt = kf.Get(input.ID);

                if (kontakt.Billede != null)
                {
                    string imagePath = Request.PhysicalApplicationPath + "/Content/Images/Kontakt/" + kontakt.Billede;

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                }
                string newImagePath = Request.PhysicalApplicationPath + "/Content/Images/Kontakt/";
                input.Billede = ft.ImageUpload(Photo, newImagePath);
            }

            kf.Update(input);


            return Redirect("/CMS/Kontakt");
        }
    }
}