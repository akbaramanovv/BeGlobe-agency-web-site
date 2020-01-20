using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeGlobeProject.DAL;
using BeGlobeProject.Models;

namespace BeGlobeProject.Areas.Admin.Controllers
{
    [Authorize]
    public class PositionnsController : Controller
    {
        private BeGlobeDAL db = new BeGlobeDAL();

        // GET: Admin/Positionns
        public ActionResult Index()
        {
            return View(db.Positions.ToList());
        }

        // GET: Admin/Positionns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Positionn positionn = db.Positions.Find(id);
            if (positionn == null)
            {
                return HttpNotFound();
            }
            return View(positionn);
        }

        // GET: Admin/Positionns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Positionns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PositionnID,Name")] Positionn positionn)
        {
            if (ModelState.IsValid)
            {
                db.Positions.Add(positionn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(positionn);
        }

        // GET: Admin/Positionns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Positionn positionn = db.Positions.Find(id);
            if (positionn == null)
            {
                return HttpNotFound();
            }
            return View(positionn);
        }

        // POST: Admin/Positionns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PositionnID,Name")] Positionn positionn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(positionn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(positionn);
        }

        // GET: Admin/Positionns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Positionn positionn = db.Positions.Find(id);
            if (positionn == null)
            {
                return HttpNotFound();
            }
            return View(positionn);
        }

        // POST: Admin/Positionns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Positionn positionn = db.Positions.Find(id);
            db.Positions.Remove(positionn);
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
