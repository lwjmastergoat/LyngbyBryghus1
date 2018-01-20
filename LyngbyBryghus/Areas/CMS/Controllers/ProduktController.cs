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
    public class ProduktController : Controller
    {

        int Admin = 2;
        int Editor = 1;

        ProduktFac pf = new ProduktFac();
        FileTools ft = new FileTools();
        // GET: CMS/Produkt
        public ActionResult Index()
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/Login");
            }
            return View(pf.GetAll());
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
        public ActionResult AddNew(ProduktTabellen input, HttpPostedFileBase Photo)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS");
            }

            
            input.Billede = null;

            if (Photo != null)
            {
                string imagePath = Request.PhysicalApplicationPath + "/Content/Images/Produkter/";
                input.Billede = ft.ImageUpload(Photo, imagePath);
            }


            pf.Insert(input);

            return Redirect("/CMS/Produkt");
        }

        public ActionResult Delete(int ID)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS/Produkt");
            }



            ProduktTabellen produkt = pf.Get(ID);

            if (produkt.Billede != null)
            {
                string imagePath = Request.PhysicalApplicationPath + "/Content/Images/Produkter/" + produkt.Billede;

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            pf.Delete(ID);

            return Redirect("/CMS/Produkt");
        }

        public ActionResult Edit(int ID)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS/Produkt");
            }

            return View(pf.Get(ID));
        }

        [HttpPost]
        public ActionResult Edit(ProduktTabellen input, HttpPostedFileBase Photo)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS/Produkt");
            }


            input.Billede = null;

            if (Photo != null)
            {
                ProduktTabellen produkt = pf.Get(input.ID);

                if (produkt.Billede != null)
                {
                    string imagePath = Request.PhysicalApplicationPath + "/Content/Images/Produkter/" + produkt.Billede;

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                }
                string newImagePath = Request.PhysicalApplicationPath + "/Content/Images/Produkter/";
                input.Billede = ft.ImageUpload(Photo, newImagePath);
            }

            pf.Update(input);


            return Redirect("/CMS/Produkt");
        }

    }
}
