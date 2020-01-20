using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeGlobeProject.DAL;
using BeGlobeProject.Models;

namespace BeGlobeProject.Areas.Admin.Controllers
{
    [Authorize]

    public class AdminServicesController : Controller
    {
        private BeGlobeDAL db = new BeGlobeDAL();

        // GET: Admin/AdminServices
        public ActionResult Index()
        {
            return View(db.Services.ToList());
        }

        // GET: Admin/AdminServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Admin/AdminServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( HttpPostedFileBase Photo, Service service)
        {
            
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    string pic =DateTime.Now.ToString("mmddyyyHHss") + Path.GetFileName(Photo.FileName);
                    string path = Path.Combine(
                                           Server.MapPath("~/Uploads"), pic);
                    // file is uploaded
                    Photo.SaveAs(path);
                    service.Photo = pic;

                }
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service);
        }

        // GET: Admin/AdminServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Admin/AdminServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase Photo, string servicePhoto, Service service)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    string pic = DateTime.Now.ToString("mmddyyyHHss") + Path.GetFileName(Photo.FileName);
                    string path = Path.Combine(
                                           Server.MapPath("~/Uploads"), pic);
                    // file is uploaded
                    Photo.SaveAs(path);
                    service.Photo = pic;

                }
                else
                {
                    service.Photo = servicePhoto;
                }
                
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        // GET: Admin/AdminServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Admin/AdminServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
