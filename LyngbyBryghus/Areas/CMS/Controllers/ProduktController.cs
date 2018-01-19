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
            return View();
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

    }
}
