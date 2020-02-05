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
    public class ScheduleDController : Controller
    {
        private cloudbassDBMSEntities db = new cloudbassDBMSEntities();

        // GET: ScheduleD
        public ActionResult Index()
        {
            var schedules = db.Schedules.Include(s => s.Job).Include(s => s.ScheduleStatu).Include(s => s.SchType);
            return View(schedules.ToList());
        }

        // GET: ScheduleD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // GET: ScheduleD/Create
        public ActionResult Create()
        {
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "text");
            ViewBag.statusId = new SelectList(db.ScheduleStatus, "Id", "title");
            ViewBag.SchTypeId = new SelectList(db.SchTypes, "Id", "name");
            return View();
        }

        // POST: ScheduleD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,text,start_date,end_date,SchTypeId,JobId,statusId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Schedules.Add(schedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobId = new SelectList(db.Jobs, "Id", "text", schedule.JobId);
            ViewBag.statusId = new SelectList(db.ScheduleStatus, "Id", "title", schedule.statusId);
            ViewBag.SchTypeId = new SelectList(db.SchTypes, "Id", "name", schedule.SchTypeId);
            return View(schedule);
        }

        // GET: ScheduleD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "text", schedule.JobId);
            ViewBag.statusId = new SelectList(db.ScheduleStatus, "Id", "title", schedule.statusId);
            ViewBag.SchTypeId = new SelectList(db.SchTypes, "Id", "name", schedule.SchTypeId);
            return View(schedule);
        }

        // POST: ScheduleD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,text,start_date,end_date,SchTypeId,JobId,statusId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "text", schedule.JobId);
            ViewBag.statusId = new SelectList(db.ScheduleStatus, "Id", "title", schedule.statusId);
            ViewBag.SchTypeId = new SelectList(db.SchTypes, "Id", "name", schedule.SchTypeId);
            return View(schedule);
        }

        // GET: ScheduleD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: ScheduleD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schedule schedule = db.Schedules.Find(id);
            db.Schedules.Remove(schedule);
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
