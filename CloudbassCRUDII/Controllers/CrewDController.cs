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
    public class CrewDController : Controller
    {
        private cloudbassDBMSEntities db = new cloudbassDBMSEntities();

        // GET: CrewD
        public ActionResult Index()
        {
            var crews = db.Crews.Include(c => c.Has_Role).Include(c => c.Job);
            return View(crews.ToList());
        }

        // GET: CrewD/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crew crew = db.Crews.Find(id);
            if (crew == null)
            {
                return HttpNotFound();
            }
            return View(crew);
        }

        // GET: CrewD/Create
        public ActionResult Create()
        {
            ViewBag.has_roleId = new SelectList(db.Has_Role, "Id", "Id");
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "text");
            return View();
        }

        // POST: CrewD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobId,has_roleId,totalDays,rate")] Crew crew)
        {
            if (ModelState.IsValid)
            {
                db.Crews.Add(crew);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.has_roleId = new SelectList(db.Has_Role, "Id", "Id", crew.has_roleId);
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "text", crew.JobId);
            return View(crew);
        }

        // GET: CrewD/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crew crew = db.Crews.Find(id);
            if (crew == null)
            {
                return HttpNotFound();
            }
            ViewBag.has_roleId = new SelectList(db.Has_Role, "Id", "Id", crew.has_roleId);
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "text", crew.JobId);
            return View(crew);
        }

        // POST: CrewD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobId,has_roleId,totalDays,rate")] Crew crew)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crew).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.has_roleId = new SelectList(db.Has_Role, "Id", "Id", crew.has_roleId);
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "text", crew.JobId);
            return View(crew);
        }

        // GET: CrewD/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crew crew = db.Crews.Find(id);
            if (crew == null)
            {
                return HttpNotFound();
            }
            return View(crew);
        }

        // POST: CrewD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Crew crew = db.Crews.Find(id);
            db.Crews.Remove(crew);
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
