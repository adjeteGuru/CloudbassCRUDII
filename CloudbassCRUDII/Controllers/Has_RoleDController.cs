using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CloudbassCRUDII.Models;

namespace CloudbassCRUDII.Controllers
{
    public class Has_RoleDController : Controller
    {
        private cloudbassDBMSEntities db = new cloudbassDBMSEntities();

        // GET: Has_RoleD
        public ActionResult Index()
        {
            var has_Role = db.Has_Role.Include(h => h.Categ).Include(h => h.Employee).Include(h => h.Role);
            return View(has_Role.ToList());
        }

        // GET: Has_RoleD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Has_Role has_Role = db.Has_Role.Find(id);
            if (has_Role == null)
            {
                return HttpNotFound();
            }
            return View(has_Role);
        }

        // GET: Has_RoleD/Create
        public ActionResult Create()
        {
            ViewBag.catId = new SelectList(db.Categs, "Id", "name");
            ViewBag.employeeId = new SelectList(db.Employees, "Id", "fullName");
            ViewBag.roleId = new SelectList(db.Roles, "Id", "Name");
            return View();
        }

        // POST: Has_RoleD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,employeeId,roleId,start_date,end_date,totalDays,catId")] Has_Role has_Role)
        {
            if (ModelState.IsValid)
            {
                db.Has_Role.Add(has_Role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.catId = new SelectList(db.Categs, "Id", "name", has_Role.catId);
            ViewBag.employeeId = new SelectList(db.Employees, "Id", "fullName", has_Role.employeeId);
            ViewBag.roleId = new SelectList(db.Roles, "Id", "Name", has_Role.roleId);
            return View(has_Role);
        }

        // GET: Has_RoleD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Has_Role has_Role = db.Has_Role.Find(id);
            if (has_Role == null)
            {
                return HttpNotFound();
            }
            ViewBag.catId = new SelectList(db.Categs, "Id", "name", has_Role.catId);
            ViewBag.employeeId = new SelectList(db.Employees, "Id", "fullName", has_Role.employeeId);
            ViewBag.roleId = new SelectList(db.Roles, "Id", "Name", has_Role.roleId);
            return View(has_Role);
        }

        // POST: Has_RoleD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,employeeId,roleId,start_date,end_date,totalDays,catId")] Has_Role has_Role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(has_Role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.catId = new SelectList(db.Categs, "Id", "name", has_Role.catId);
            ViewBag.employeeId = new SelectList(db.Employees, "Id", "fullName", has_Role.employeeId);
            ViewBag.roleId = new SelectList(db.Roles, "Id", "Name", has_Role.roleId);
            return View(has_Role);
        }

        // GET: Has_RoleD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Has_Role has_Role = db.Has_Role.Find(id);
            if (has_Role == null)
            {
                return HttpNotFound();
            }
            return View(has_Role);
        }

        // POST: Has_RoleD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Has_Role has_Role = db.Has_Role.Find(id);
            db.Has_Role.Remove(has_Role);
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
