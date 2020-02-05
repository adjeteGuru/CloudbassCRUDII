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
    public class JobDController : Controller
    {
        private cloudbassDBMSEntities db = new cloudbassDBMSEntities();

        // GET: JobD
        public ActionResult Index()
        {
            var jobs = db.Jobs.Include(j => j.Client).Include(j => j.JobStatu);
            return View(jobs.ToList());
        }

        // GET: JobD/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: JobD/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name");
            ViewBag.statusId = new SelectList(db.JobStatus, "Id", "title");
            return View();
        }

        // POST: JobD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,text,Description,Location,DateCreated,start_date,TXDate,end_date,Coordinator,CommercialLead,ClientId,statusId")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", job.ClientId);
            ViewBag.statusId = new SelectList(db.JobStatus, "Id", "title", job.statusId);
            return View(job);
        }

        // GET: JobD/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", job.ClientId);
            ViewBag.statusId = new SelectList(db.JobStatus, "Id", "title", job.statusId);
            return View(job);
        }

        // POST: JobD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,text,Description,Location,DateCreated,start_date,TXDate,end_date,Coordinator,CommercialLead,ClientId,statusId")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", job.ClientId);
            ViewBag.statusId = new SelectList(db.JobStatus, "Id", "title", job.statusId);
            return View(job);
        }

        // GET: JobD/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: JobD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
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
