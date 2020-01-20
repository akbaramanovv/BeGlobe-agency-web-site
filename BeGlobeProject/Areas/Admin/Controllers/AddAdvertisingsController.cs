using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using BeGlobeProject.DAL;
using BeGlobeProject.Models;

namespace BeGlobeProject.Areas.Admin.Controllers
{
    [Authorize]
    public class AddAdvertisingsController : Controller
    {
        private BeGlobeDAL db = new BeGlobeDAL();

        // GET: Admin/AddAdvertisings
        public ActionResult Index()
        {
            return View(db.Advertisings.ToList());
        }

        // GET: Admin/AddAdvertisings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertising advertising = db.Advertisings.Find(id);
            if (advertising == null)
            {
                return HttpNotFound();
            }
            return View(advertising);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Advertising advertising)
        {
            if (advertising.Image == null)
            {
                ModelState.AddModelError("Image","Bos qoyula Bilməz");
            } 
            if (!ModelState.IsValid)
            {
                return View(advertising);

            }
            string pic = "";
            if (advertising.Image != null)
            {
                pic = DateTime.Now.ToString("mmddyyyHHss") + Path.GetFileName(advertising.Image.FileName);
                string path = Path.Combine(
                                       Server.MapPath("~/Uploads"), pic);
                // file is uploaded
                advertising.Image.SaveAs(path);
            }

            db.Advertisings.Add(new Advertising()
            {
                Photo = pic,
                Description = advertising.Description,
                Header = advertising.Header
            });
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Admin/AddAdvertisings/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Advertising advertising = db.Advertisings.Find(id);
            if (advertising == null)
            {
                return HttpNotFound();
            }
            return View(advertising);
        }

        // POST: Admin/AddAdvertisings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Advertising advertising)
        {
            string pic = " ";

            if (advertising.Photo == null)
            {
                ModelState.AddModelError("Image", "Bos qoyula Bilməz");
            }
            if (advertising.Image != null)
            {
                pic = DateTime.Now.ToString("mmddyyyHHss") + Path.GetFileName(advertising.Image.FileName);
                string path = Path.Combine(
                                       Server.MapPath("~/Uploads"), pic);
                // file is uploaded
                advertising.Image.SaveAs(path);
                advertising.Photo = pic;
            }
            
            if (ModelState.IsValid)
            {
                db.Entry(advertising).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advertising);
        }

        // GET: Admin/AddAdvertisings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertising advertising = db.Advertisings.Find(id);
            if (advertising == null)
            {
                return HttpNotFound();
            }
            return View(advertising);
        }

        // POST: Admin/AddAdvertisings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertising advertising = db.Advertisings.Find(id);
            db.Advertisings.Remove(advertising);
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
