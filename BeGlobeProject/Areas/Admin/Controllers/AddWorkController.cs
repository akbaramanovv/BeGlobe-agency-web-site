using BeGlobeProject.DAL;
using BeGlobeProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BeGlobeProject.Areas.Admin.Controllers
{

    public class AddWorkController : Controller
    {
        private BeGlobeDAL db = new BeGlobeDAL();

        public async Task<ActionResult> RenderImage(int? id)
        {
            Work item = await db.Works.FindAsync(id);

            byte[] photoBack = item.WorkPhoto;

            return File(photoBack, "image/png");
        }
        public async Task<ActionResult> RenderImage2(int? id)
        {
            Work item = await db.Works.FindAsync(id);

            byte[] photoBack = item.WorkFullImage;

            return File(photoBack, "image/png");
        }
        // GET: Admin/AddWork
        public ActionResult Index()
        {
            return View(db.Works.ToList());
        }

        // GET: Admin/AddWork/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Works.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            return View(work);
        }

        // GET: Admin/AddWork/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AddWork/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase Photo, Work work)
        {
            if (work.Image == null )
            {
                ModelState.AddModelError("Image", "This field is required");


            }
            if (work.Image2 == null)
            {
                ModelState.AddModelError("Image2", "This field is required");


            }

            if (ModelState.IsValid)
            {
                if (work.Image != null )
                {
                    byte[] bytes;

                    using (BinaryReader br = new BinaryReader(work.Image.InputStream))
                    {
                        bytes = br.ReadBytes(work.Image.ContentLength);

                    }
                    work.WorkPhoto = bytes;

                }
                if ( work.Image2 != null)
                {
                    byte[] bytes2;
                    using (BinaryReader br = new BinaryReader(work.Image2.InputStream))
                    {
                        bytes2 = br.ReadBytes(work.Image2.ContentLength);

                    }
                    work.WorkFullImage = bytes2;

                }


                db.Works.Add(work);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(work);
        }

        // GET: Admin/AddWork/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Works.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            ViewBag.Base64String = "data:image/png;base64," + Convert.ToBase64String(work.WorkPhoto, 0, work.WorkPhoto.Length);
            ViewBag.Base64String2 = Convert.ToBase64String(work.WorkPhoto, 0, work.WorkPhoto.Length);
            if (work.WorkFullImage != null)
            {
                ViewBag.Base64StringFull = "data:image/png;base64," + Convert.ToBase64String(work.WorkFullImage, 0, work.WorkFullImage.Length);
                ViewBag.Base64String2Full = Convert.ToBase64String(work.WorkFullImage, 0, work.WorkFullImage.Length);
            }
            return View(work);
        }

        // POST: Admin/AddWork/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase Image, HttpPostedFileBase Image2, string salam,string salamm, Work work)
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
                    work.WorkPhoto = bytes;
                }
                else
                {
                    work.WorkPhoto = Convert.FromBase64String(salam);
                }
                if (Image2 != null)
                {
                    byte[] bytes2;
                    using (BinaryReader br = new BinaryReader(Image2.InputStream))
                    {
                        bytes2 = br.ReadBytes(Image2.ContentLength);
                    }
                    work.WorkFullImage = bytes2;
                }
                else
                {
                    work.WorkFullImage = Convert.FromBase64String(salamm);
                }
                db.Entry(work).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(work);
        }

        // GET: Admin/AddWork/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Works.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            return View(work);
        }

        // POST: Admin/AddWork/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Work work = db.Works.Find(id);
            db.Works.Remove(work);
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