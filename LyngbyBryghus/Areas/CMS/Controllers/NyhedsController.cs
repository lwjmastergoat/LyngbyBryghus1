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
    public class NyhedsController : Controller
    {

        int Admin = 2;
        int Editor = 1;
        FileTools ft = new FileTools();
        NyhedsFac nf = new NyhedsFac();

        // GET: CMS/Nyheds
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
        public ActionResult AddNew(Nyhedstabel input, HttpPostedFileBase Photo)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS");
            }


            input.Image = null;

            if (Photo != null)
            {
                string imagePath = Request.PhysicalApplicationPath + "/Content/Images/Nyheder/";
                input.Image = ft.ImageUpload(Photo, imagePath);
            }


            nf.Insert(input);

            return Redirect("/CMS/Nyheder");
        }

    }
}