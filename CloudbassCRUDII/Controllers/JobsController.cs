using CloudbassCRUDII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Controllers
{
    public class JobsController : Controller
    {
        // GET: Jobs
        public JsonResult Get(int? page, int? limit, string sortBy, string direction, string jobname, string clientname, string location)
        {
            List<Models.DTO.Job> records;
            int total;
            using (CloudbassDBMSEntities context = new CloudbassDBMSEntities())
            {
                var query = context.Jobs.Select(p => new Models.DTO.Job
                {
                    Id = p.Id,
                    text = p.text,
                   
                    Description = p.Description,
                    Location = p.Location,
                    start_date = p.start_date,
                    DateCreated = p.DateCreated,
                    end_date = p.end_date,
                    TXDate = p.TXDate,
                    Coordinator = p.Coordinator,
                    CommercialLead = p.CommercialLead,
                    ClientId = p.ClientId,
                    ClientName = p.Client.Name,
              
                    statusId = p.statusId,
                    StatusName = p.JobStatu.title
                 
                });

                if (!string.IsNullOrWhiteSpace(jobname))
                {
                    query = query.Where(q => q.text.Contains(jobname));
                }

                if (!string.IsNullOrWhiteSpace(location))
                {
                    query = query.Where(q => q.Location.Contains(location));
                }

                if (!string.IsNullOrWhiteSpace(clientname))
                {
                    query = query.Where(q => q.ClientName.Contains(clientname));
                }

                //if (!string.IsNullOrWhiteSpace(location))
                //{
                //    query = query.Where(q => q.PlaceOfBirth != null && q.PlaceOfBirth.Contains(location));
                //}

                if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
                {
                    if (direction.Trim().ToLower() == "asc")
                    {
                        switch (sortBy.Trim().ToLower())
                        {
                            case "jobname":
                                query = query.OrderBy(q => q.text);
                                break;
                            case "location":
                                query = query.OrderBy(q => q.Location);
                                break;
                            case "placeOfBirth":
                                query = query.OrderBy(q => q.ClientName);
                                break;
                                //case "dateofbirth":
                                //    query = query.OrderBy(q => q.DateOfBirth);
                                //    break;
                        }
                    }
                    else
                    {
                        switch (sortBy.Trim().ToLower())
                        {
                            case "jobname":
                                query = query.OrderByDescending(q => q.text);
                                break;
                            case "location":
                                query = query.OrderByDescending(q => q.Location);
                                break;
                            case "placeOfBirth":
                                query = query.OrderByDescending(q => q.ClientName);
                                break;
                                //case "dateofbirth":
                                //    query = query.OrderByDescending(q => q.DateOfBirth);
                                //    break;
                        }
                    }
                }
                else
                {
                    query = query.OrderBy(q => q.TXDate);
                }

                total = query.Count();
                if (page.HasValue && limit.HasValue)
                {
                    int start = (page.Value - 1) * limit.Value;
                    records = query.Skip(start).Take(limit.Value).ToList();
                }
                else
                {
                    records = query.ToList();
                }
            }

            return this.Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(Models.DTO.Job record)
        {
            Job entity;
            using (CloudbassDBMSEntities context = new CloudbassDBMSEntities())
            {
                if (record.Id.Length == 0)
                {
                    entity = context.Jobs.First(p => p.Id == record.Id);
                    entity.text = record.text;
                    entity.Description = record.Description;
                    entity.Location = record.Location;
                    entity.ClientId = record.ClientId;
                    //entity.Country = context.Locations.FirstOrDefault(l => l.ID == record.CountryID);
                    entity.statusId = record.statusId;
                    entity.DateCreated = record.DateCreated;
                    entity.TXDate = record.TXDate;
                    entity.start_date = record.start_date;
                    entity.end_date = record.end_date;
                    entity.Coordinator = record.Coordinator;
                    entity.CommercialLead = record.CommercialLead;
                   
                }
                else
                {
                    context.Jobs.Add(new Job
                    {
                        Id = record.Id,
                        text = record.text,
                        
                        Description = record.Description,
                        Location = record.Location,
                        start_date = record.start_date,
                        DateCreated = record.DateCreated,
                        end_date = record.end_date,
                        TXDate = record.TXDate,
                        Coordinator = record.Coordinator,
                        CommercialLead = record.CommercialLead,
                        ClientId = record.ClientId,
                     
                        statusId = record.statusId,
                    });
                }
                context.SaveChanges();
            }
            return Json(new { result = true });
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            using (CloudbassDBMSEntities context = new CloudbassDBMSEntities())
            {
                Job entity = context.Jobs.First(p => p.Id == id);
                context.Jobs.Remove(entity);
                context.SaveChanges();
            }
            return Json(new { result = true });
        }

        public JsonResult GetSchedules(string Id, int? page, int? limit)
        {
            List<Models.DTO.Schedule> records;
            int total;
            using (CloudbassDBMSEntities context = new CloudbassDBMSEntities())
            {
                var query = context.Schedules.Where(pt => pt.JobId == Id).Select(pt => new Models.DTO.Schedule
                {
                    Id = pt.Id,
                    //JobId = pt.JobId,
                    //JobName = pt.
                    text = pt.text,

                   // SchTypeId = pt.SchTypeId,
                    SchTypName = pt.SchType.name,
                    start_date = pt.start_date,
                    end_date = pt.end_date,
                    //statusId = pt.statusId,
                    StatusName = pt.ScheduleStatu.title

                });

                total = query.Count();
                if (page.HasValue && limit.HasValue)
                {
                    int start = (page.Value - 1) * limit.Value;
                    records = query.OrderBy(pt => pt.start_date).Skip(start).Take(limit.Value).ToList();
                }
                else
                {
                    records = query.ToList();
                }
            }

            return this.Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }
    }
}