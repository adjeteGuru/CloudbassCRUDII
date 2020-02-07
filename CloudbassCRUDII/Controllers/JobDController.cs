using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CloudbassCRUDII.Models;
using CloudbassCRUDII.Models.DTO;
using CloudbassCRUDII.Repository;

namespace CloudbassCRUDII.Controllers
{
    public class JobDController : Controller
    {

        public ActionResult Index()
        {
            var repo = new JobRepository();
            var jobList = repo.GetJobs();
            return View(jobList);
        }

        [HttpGet]
        public ActionResult GetClients(int? id)
        {
            if (id != null)
            {
                var repo = new ClientRepository();

                IEnumerable<SelectListItem> clients = repo.GetClients();
                return Json(clients, JsonRequestBehavior.AllowGet);
            }
            return null;
        }


        // GET: Job/Details/5
        public ActionResult Details(int id)
        {
            return View();

        }

        // GET: Job/Create
        public ActionResult Create()
        {
            var repo = new JobRepository();
            var job = repo.CreateJob();
            return View(job);
        }

        // POST: Job/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id, text,Description, SelectedClientId, DateCreated, Location, Coordinator,start_date, TXDate, end_date, CommercialLead,status")] JobEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var repo = new JobRepository();
                    bool saved = repo.SaveJob(model);
                    if (saved)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        

        // GET: Job/Edit/5
  
        public ActionResult Edit(string id)
        {
            if (!String.IsNullOrWhiteSpace(id))
            {
                bool isGuid = Guid.TryParse(id, out Guid jobId);
                if (isGuid && jobId != Guid.Empty)
                {
                    return View();
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                       
        }

        [ChildActionOnly]
        public ActionResult EditJobPartial(string id)
        {
            if (!String.IsNullOrWhiteSpace(id))
            {
                bool isGuid = Guid.TryParse(id, out Guid jobId);
                if (isGuid && jobId != Guid.Empty)
                {
                    var repo = new JobRepository();
                    var model = repo.GetJob(jobId);
                    return View(model);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: Customer/Edit/5
        [ValidateAntiForgeryToken]
        public ActionResult EditJobPartial(JobEdit model)
        {
            if (ModelState.IsValid)
            {
                var repo = new JobRepository();
                bool saved = repo.SaveJob(model);
                if (saved)
                {
                    bool isGuid = Guid.TryParse(model.Id, out Guid jobId);
                    if (isGuid)
                    {
                        var modelUpdate = repo.GetJob(jobId);
                        return PartialView(modelUpdate);
                    }
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


        [ChildActionOnly]
        public ActionResult BookingTypePartial(string id)
        {
            if (!String.IsNullOrWhiteSpace(id))
            {
                bool isGuid = Guid.TryParse(id, out Guid jobId);
                if (isGuid && jobId != Guid.Empty)
                {
                    var repo = new MetadataRepository();
                    var model = new Models.DTO.BookingType()
                    {
                        JobId = id,
                        BookingTypes = repo.GetBookingTypes()
                    };
                    return PartialView("BookingTypePartial", model);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookingTypePartial(Models.DTO.BookingType model)
        {
            if (ModelState.IsValid && !String.IsNullOrWhiteSpace(model.JobId))
            {
                switch (model.SelectedBookingType)
                {
                    case "Schedule":
                        var scheduleModel = new Models.DTO.Schedule()
                        {
                            JobId = model.JobId
                        };
                        return PartialView("CreateSchedulePartial", scheduleModel);

                    case "Crew":
                        var crewModel = new Models.DTO.Crew()
                        {
                            JobId = model.JobId
                        };
                       
                        return PartialView("CreateCrewPartial", crewModel);

                    case "Fleet":
                        var fleetModel = new Models.DTO.BookingFleet()
                        {
                            JobId = model.JobId
                        };
                        var fleetTypeRepo = new FleetTypeRepository();
                        fleetModel. = fleetTypeRepo.GetFleetTypes();
                        var regionsRepo = new RegionsRepository();
                        postalAddressModel.Regions = regionsRepo.GetRegions();
                        return PartialView("CreatePostalAddressPartial", fleetModel);

                    case "Hotel":
                        var hotelModel = new Models.DTO.BookingHotel()
                        {
                            JobId = model.JobId
                        };
                        var countriesRepo = new CountriesRepository();
                        postalAddressModel.Countries = countriesRepo.GetCountries();
                        var regionsRepo = new RegionsRepository();
                        postalAddressModel.Regions = regionsRepo.GetRegions();
                        return PartialView("CreatePostalAddressPartial", hotelModel);

                    case "Kit":
                        var kitModel = new Models.DTO.BookingKit()
                        {
                            JobId = model.JobId
                        };
                        var countriesRepo = new CountriesRepository();
                        postalAddressModel.Countries = countriesRepo.GetCountries();
                        var regionsRepo = new RegionsRepository();
                        postalAddressModel.Regions = regionsRepo.GetRegions();
                        return PartialView("CreatePostalAddressPartial", kitModel);

                    //case "Hiring":
                    //    var schedule = new Models.DTO.Schedule()
                    //    {
                    //        CustomerID = model.CustomerID
                    //    };
                    //    var countriesRepo = new CountriesRepository();
                    //    postalAddressModel.Countries = countriesRepo.GetCountries();
                    //    var regionsRepo = new RegionsRepository();
                    //    postalAddressModel.Regions = regionsRepo.GetRegions();
                    //    return PartialView("CreatePostalAddressPartial", postalAddressModel);

                    case "Equipment":
                        var schedule = new Models.DTO.BookingEquipment()
                        {
                            JobId = model.JobId
                        };
                        var countriesRepo = new CountriesRepository();
                        postalAddressModel.Countries = countriesRepo.GetCountries();
                        var regionsRepo = new RegionsRepository();
                        postalAddressModel.Regions = regionsRepo.GetRegions();
                        return PartialView("CreatePostalAddressPartial", postalAddressModel);

                    default:
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }





























        //private cloudbassDBMSEntities db = new cloudbassDBMSEntities();

        //// GET: JobD
        //public ActionResult Index()
        //{
        //    var jobs = db.Jobs.Include(j => j.Client).Include(j => j.JobStatu);
        //    return View(jobs.ToList());
        //}

        //// GET: JobD/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Job job = db.Jobs.Find(id);
        //    if (job == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(job);
        //}

        //// GET: JobD/Create
        //public ActionResult Create()
        //{
        //    ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name");
        //    ViewBag.statusId = new SelectList(db.JobStatus, "Id", "title");
        //    return View();
        //}

        //// POST: JobD/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,text,Description,Location,DateCreated,start_date,TXDate,end_date,Coordinator,CommercialLead,ClientId,statusId")] Job job)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Jobs.Add(job);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", job.ClientId);
        //    ViewBag.statusId = new SelectList(db.JobStatus, "Id", "title", job.statusId);
        //    return View(job);
        //}

        //// GET: JobD/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Job job = db.Jobs.Find(id);
        //    if (job == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", job.ClientId);
        //    ViewBag.statusId = new SelectList(db.JobStatus, "Id", "title", job.statusId);
        //    return View(job);
        //}

        //// POST: JobD/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,text,Description,Location,DateCreated,start_date,TXDate,end_date,Coordinator,CommercialLead,ClientId,statusId")] Job job)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(job).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", job.ClientId);
        //    ViewBag.statusId = new SelectList(db.JobStatus, "Id", "title", job.statusId);
        //    return View(job);
        //}

        //// GET: JobD/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Job job = db.Jobs.Find(id);
        //    if (job == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(job);
        //}

        //// POST: JobD/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Job job = db.Jobs.Find(id);
        //    db.Jobs.Remove(job);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
