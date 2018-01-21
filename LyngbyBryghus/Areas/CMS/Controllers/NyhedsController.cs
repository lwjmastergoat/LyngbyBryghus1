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
            return View(nf.GetAll());
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

            input.Dato = DateTime.Now;
            input.Image = null;

            if (Photo != null)
            {
                string imagePath = Request.PhysicalApplicationPath + "/Content/Images/Nyheder/";
                input.Image = ft.ImageUpload(Photo, imagePath);
            }


            nf.Insert(input);

            return Redirect("/CMS/Nyheds");
        }

        public ActionResult Delete(int ID)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS/Nyheds");
            }



            Nyhedstabel Nyheds = nf.Get(ID);

            if (Nyheds.Image != null)
            {
                string imagePath = Request.PhysicalApplicationPath + "/ArticleImages/" + Nyheds.Image;

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            nf.Delete(ID);

            return Redirect("/CMS/Nyheds");
        }

        public ActionResult Edit(int ID)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS/Nyheds");
            }

            return View(nf.Get(ID));
        }

        [HttpPost]
        public ActionResult Edit(Nyhedstabel input, HttpPostedFileBase Photo)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Editor)
            {
                return Redirect("/CMS/Nyheds");
            }


            input.Image = null;
            input.Dato = null;
            input.BrugerID = null;

            if (Photo != null)
            {
                Nyhedstabel nyheds = nf.Get(input.ID);

                if (nyheds.Image != null)
                {
                    string imagePath = Request.PhysicalApplicationPath + "/Content/Images/Nyheder/" + nyheds.Image;

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                }
                string newImagePath = Request.PhysicalApplicationPath + "/Content/Images/Nyheder/";
                input.Image = ft.ImageUpload(Photo, newImagePath);
            }

            nf.Update(input);


            return Redirect("/CMS/Nyheds");
        }

    }
}