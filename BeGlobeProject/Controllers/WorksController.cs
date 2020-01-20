using BeGlobeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BeGlobeProject.Controllers
{
    public class WorksController : MainController
    {

        public async Task<ActionResult> RenderImage(int? id)
        {
            Photo item = await db.Photos.FindAsync(id);

            byte[] photoBack = item.FileName;

            return File(photoBack, "image/png");
        }
        public async Task<ActionResult> RenderImage2(int? id)
        {
            Photo item = await db.Photos.FindAsync(id);

            byte[] photoBack = item.FileName;

            return File(photoBack, "image/png");
        }
        // GET: Works
        [HttpGet]
        public ActionResult Index2()
        {
            WorkWM model = new WorkWM();

          
            model.PhotoCount = db.Photos.Count();
            model.Works = db.Works.ToList();
            return View(model);
        }

        //public ActionResult Load()
        //{
        //    int rows = Convert.ToInt32(Session["data"]) + 1;
        //    WorkWM model2 = new WorkWM();
        //    model2.Photos = db.Photos.Take(rows).ToList();
        //    model2.PhotoCount = db.Photos.Count();

        //    model2.Works = db.Works.ToList();
        //    Session["data"] = rows;
        //    return View("Index2", model2);
        //}

       

        public ActionResult WorkIndex(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            WorkWM model = new WorkWM()
            {
                Work = db.Works.Find(id),
                Photos = db.Photos.Where(p => p.WorkID == id).ToList(),

            };
            if (model.Work == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            return View(model);
        }
    }
}