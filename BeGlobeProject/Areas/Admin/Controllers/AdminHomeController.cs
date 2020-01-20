using BeGlobeProject.Controllers;
using BeGlobeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace BeGlobeProject.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminHomeController : MainController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            var model = db.Admin.FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public bool ChangePassword(string old , string newPass,string name)
        {

            var admin = db.Admin.FirstOrDefault();
            var equal  = false;
            
           
            if(old == admin.Password )
            {
                admin.Password = newPass;
                admin.UserName = name;
                db.SaveChanges();
                equal = true;
                return equal;

            }
            

            return equal;

        }
    }
}