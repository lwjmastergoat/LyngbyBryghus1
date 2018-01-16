using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LyngbyBrygRepo.Models;
using LyngbyBrygRepo.Factories;
using LyngbyBrygRepo;

namespace LyngbyBryghus.Controllers
{
    public class LoginController : Controller
    {
        AdminFac af = new AdminFac();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Navn, string Password)
        {
            AdminTabel user = af.Login(Navn, Password);

            if (user.Navn != null)
            {
                Session["id"] = user.ID;
                Session["rolle"] = user.Rolle;
                return Redirect("/CMS/");
            }
            else
            {
                ViewBag.Msg = "<b>Forkert login</b>";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("id");
            Session.Remove("rolle");
            return Redirect("/Home/Index/");
        }
    }
}