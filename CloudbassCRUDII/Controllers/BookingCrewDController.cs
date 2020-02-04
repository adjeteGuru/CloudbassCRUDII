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
    public class BookingCrewDController : Controller
    {
        private CloudbassDBMSEntities db = new CloudbassDBMSEntities();

        // GET: BookingCrewD
        public ActionResult Index()
        {
            var bookingCrews = db.BookingCrews.Include(b => b.Has_Role).Include(b => b.Schedule);
            return View(bookingCrews.ToList());
        }

        // GET: BookingCrewD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingCrew bookingCrew = db.BookingCrews.Find(id);
            if (bookingCrew == null)
            {
                return HttpNotFound();
            }
            return View(bookingCrew);
        }

        // GET: BookingCrewD/Create
        public ActionResult Create()
        {
            ViewBag.has_RoleId = new SelectList(db.Has_Role, "Id", "Id");
            ViewBag.scheduleId = new SelectList(db.Schedules, "Id", "text");
            return View();
        }

        // POST: BookingCrewD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "scheduleId,has_RoleId,start_date,end_date,totalDays,rate")] BookingCrew bookingCrew)
        {
            if (ModelState.IsValid)
            {
                db.BookingCrews.Add(bookingCrew);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.has_RoleId = new SelectList(db.Has_Role, "Id", "Id", bookingCrew.has_RoleId);
            ViewBag.scheduleId = new SelectList(db.Schedules, "Id", "text", bookingCrew.scheduleId);
            return View(bookingCrew);
        }

        // GET: BookingCrewD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingCrew bookingCrew = db.BookingCrews.Find(id);
            if (bookingCrew == null)
            {
                return HttpNotFound();
            }
            ViewBag.has_RoleId = new SelectList(db.Has_Role, "Id", "Id", bookingCrew.has_RoleId);
            ViewBag.scheduleId = new SelectList(db.Schedules, "Id", "text", bookingCrew.scheduleId);
            return View(bookingCrew);
        }

        // POST: BookingCrewD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "scheduleId,has_RoleId,start_date,end_date,totalDays,rate")] BookingCrew bookingCrew)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingCrew).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.has_RoleId = new SelectList(db.Has_Role, "Id", "Id", bookingCrew.has_RoleId);
            ViewBag.scheduleId = new SelectList(db.Schedules, "Id", "text", bookingCrew.scheduleId);
            return View(bookingCrew);
        }

        // GET: BookingCrewD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingCrew bookingCrew = db.BookingCrews.Find(id);
            if (bookingCrew == null)
            {
                return HttpNotFound();
            }
            return View(bookingCrew);
        }

        // POST: BookingCrewD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingCrew bookingCrew = db.BookingCrews.Find(id);
            db.BookingCrews.Remove(bookingCrew);
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
