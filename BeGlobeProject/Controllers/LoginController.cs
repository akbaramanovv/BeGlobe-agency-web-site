using BeGlobeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BeGlobeProject.Controllers
{
    public class LoginController : MainController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var a = db.Admin.Where(m => m.UserName == admin.UserName && m.Password == admin.Password).FirstOrDefault();
            if (a!= null)
            {
                FormsAuthentication.SetAuthCookie(admin.UserName, false);
                return View("~/Areas/Admin/Views/AdminHome/Index.cshtml");

            }
            else
            {
                ViewBag.ErrorMessage = "Isifadəçi adı və ya parol düzgün deyil";
                return View();
            }
            
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View("Index");
        }
    }
}