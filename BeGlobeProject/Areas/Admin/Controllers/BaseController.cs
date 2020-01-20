using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BeGlobeProject.Areas.Admin.Controllers
{

    [Authorize]

    public class BaseController : Controller
    {
        // GET: Admin/Base

        public ActionResult Index()
        {
            return View();
        }
    }
}