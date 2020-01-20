using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
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

    public class PhotosController : Controller
    {
        private BeGlobeDAL db = new BeGlobeDAL();

        public async Task<ActionResult> RenderImage(int? id)
        {
            Photo item = await db.Photos.FindAsync(id);

            byte[] photoBack = item.FileName;

            return File(photoBack, "image/png");
        }
       //get request for load more button
      
        // GET: Admin/Photos
        public ActionResult Index()
        {
            var photos = db.Photos.Include(p => p.Work);
            return View(photos.ToList());
        }

      

        // GET: Admin/Photos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: Admin/Photos/Create
        public ActionResult Create()
        {
            ViewBag.WorkID = new SelectList(db.Works, "ID", "Name");
            return View();
        }

        // POST: Admin/Photos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase File, Photo photo)
        {
            if (ModelState.IsValid)
            {
                if (File!= null)
                {
                    byte[] bytes;
                    using (BinaryReader br = new BinaryReader(File.InputStream))
                    {
                        bytes = br.ReadBytes(File.ContentLength);
                    }
                    photo.FileName = bytes;
                }
                db.Photos.Add(photo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WorkID = new SelectList(db.Works, "ID", "Name", photo.WorkID);
            return View(photo);
        }

        // GET: Admin/Photos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            };

            Photo photo = db.Photos.Find(id);
            
         
            if (photo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Base64String = "data:image/png;base64," + Convert.ToBase64String(photo.FileName, 0, photo.FileName.Length);
            ViewBag.Base64String2 = Convert.ToBase64String(photo.FileName, 0, photo.FileName.Length);
            ViewBag.WorkID = new SelectList(db.Works, "ID", "Name", photo.WorkID);
            return View(photo);
        }

        // POST: Admin/Photos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase Image, string salam, Photo photo)
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
                    photo.FileName = bytes;
                }
                else
                {
                    photo.FileName = Convert.FromBase64String(salam);
                }
                db.Entry(photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkID = new SelectList(db.Works, "ID", "Name", photo.WorkID);
            return View(photo);
        }

        // GET: Admin/Photos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Admin/Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = db.Photos.Find(id);
            db.Photos.Remove(photo);
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
