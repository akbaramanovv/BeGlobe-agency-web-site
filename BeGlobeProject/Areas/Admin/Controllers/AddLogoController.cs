using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BeGlobeProject.DAL;
using BeGlobeProject.Models;

namespace BeGlobeProject.Areas.Admin.Controllers
{
    [Authorize]
    public class AddLogoController : Controller
    {
        private BeGlobeDAL db = new BeGlobeDAL();

        public async Task<ActionResult> RenderImage(int? id)
        {
            Logo item = await db.Logos.FindAsync(id);

            byte[] photoBack = item.Photo;

            return File(photoBack, "image/png");
        }
        // GET: Admin/AddLogo
        public ActionResult Index()
        {
            return View(db.Logos.ToList());
        }

        // GET: Admin/AddLogo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logo logo = db.Logos.Find(id);
            if (logo == null)
            {
                return HttpNotFound();
            }
            return View(logo);
        }

        // GET: Admin/AddLogo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AddLogo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase File, Logo logo)
        {
           
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    byte[] bytes;
                    using (BinaryReader br = new BinaryReader(File.InputStream))
                    {
                        bytes = br.ReadBytes(File.ContentLength);
                    }
                    logo.Photo = bytes;
                }
                db.Logos.Add(logo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logo);
        }

        // GET: Admin/AddLogo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logo logo = db.Logos.Find(id);
            if (logo.Photo != null)
            {
                ViewBag.Base64String = "data:image/png;base64," + Convert.ToBase64String(logo.Photo, 0, logo.Photo.Length);
                ViewBag.Base64String2 = Convert.ToBase64String(logo.Photo, 0, logo.Photo.Length);
            }
           
            if (logo == null)
            {
                return HttpNotFound();
            }
            return View(logo);
        }

        // POST: Admin/AddLogo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase Image, string salam, Logo logo)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    byte[] bytes;
                    using (BinaryReader br = new BinaryReader(Image.InputStream))
                    {
                        bytes = br.ReadBytes(Image.ContentLength);
                    }
                    logo.Photo = bytes;
                }
                else
                {
                    logo.Photo = Convert.FromBase64String(salam);
                }
                db.Entry(logo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logo);
        }

        // GET: Admin/AddLogo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logo logo = db.Logos.Find(id);
            if (logo == null)
            {
                return HttpNotFound();
            }
            return View(logo);
        }

        // POST: Admin/AddLogo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Logo logo = db.Logos.Find(id);
            db.Logos.Remove(logo);
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
