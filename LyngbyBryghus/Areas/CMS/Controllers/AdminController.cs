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

        public ActionResult AddNew()
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Admin)
            {
                return Redirect("/CMS/Admin");
            }


            return View();
        }

        [HttpPost]

        public ActionResult AddNew(AdminTabel input)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Admin)
            {
                return Redirect("/CMS/Admin");
            }

            af.Insert(input);
            return Redirect("/CMS/Admin/");
        }
        public ActionResult Edit(int ID)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Admin)
            {
                return Redirect("/CMS/Admin");
            }

            return View(af.Get(ID));
        }

        [HttpPost]

        public ActionResult Edit(AdminTabel input)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Admin)
            {
                return Redirect("/CMS/Admin");
            }

            if (input.ID == (int)Session["id"])
            {
                input.Rolle = null;
            }

            af.Update(input);

            return Redirect("/CMS/Admin");
        }


        public ActionResult Delete(int ID)
        {
            if (Session["rolle"] == null || (int)Session["rolle"] < Admin || (int)Session["id"] == ID)
            {
                return Redirect("/CMS/Admin");
            }

            af.Delete(ID);

            return Redirect("/CMS/Admin/");
        }

    }
}