using BeGlobeProject.DAL;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BeGlobeProject.Controllers
{
    public class MainController : Controller
    {
        protected readonly BeGlobeDAL db;

        public MainController()
        {

            db = new BeGlobeDAL();
        }

       
       
    }
}