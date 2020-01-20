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
    public class EmployeeController : Controller
    {
        private BeGlobeDAL db = new BeGlobeDAL();

        // GET: Admin/Employee
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Positionn);
            return View(employees.ToList());
        }

        // GET: Admin/Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Admin/Employee/Create
        public ActionResult Create()
        {
            ViewBag.PositionID = new SelectList(db.Positions, "PositionnID", "Name");
            return View();
        }

        // POST: Admin/Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase File, Employee employee)
        {

            string pic = "";
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    pic = DateTime.Now.ToString("mmddyyyHHss") + Path.GetFileName(File.FileName);
                    string path = Path.Combine(
                                           Server.MapPath("~/Uploads"), pic);
                    // file is uploaded
                    File.SaveAs(path);

                    employee.Photo = pic;
                }
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PositionID = new SelectList(db.Positions, "PositionnID", "Name", employee.PositionID);
            return View(employee);
        }

        // GET: Admin/Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.PositionID = new SelectList(db.Positions, "PositionnID", "Name", employee.PositionID);
            return View(employee);
        }

        // POST: Admin/Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase File,string oldImage, Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (File == null)
                {
                    employee.Photo = oldImage;
                }
                else
                {
                   string pic = DateTime.Now.ToString("mmddyyyHHss") + Path.GetFileName(File.FileName);
                    string path = Path.Combine(
                                           Server.MapPath("~/Uploads"), pic);
                    // file is uploaded
                    File.SaveAs(path);

                    employee.Photo = pic;
                }
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PositionID = new SelectList(db.Positions, "PositionnID", "Name", employee.PositionID);
            return View(employee);
        }

        // GET: Admin/Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Admin/Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
