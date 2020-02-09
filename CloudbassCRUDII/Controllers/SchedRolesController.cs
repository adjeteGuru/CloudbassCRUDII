using CloudbassCRUDII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Controllers
{
    public class SchedRolesController : Controller
    {
        private cloudbassDBMSEntities context = new cloudbassDBMSEntities();
        // GET: SchedRoles
       public JsonResult Get(int? page, int? limit, string sortBy, string direction, string schedname)
        {
            List<Models.DTO.Schedule> records;
            int total;

           
            using (cloudbassDBMSEntities context = new cloudbassDBMSEntities())
            {
                var query = context.Schedules.Select(p => new Models.DTO.Schedule
                {
                    Id = p.Id,
                    text = p.text,
                   
                    
                    start_date = p.start_date,
                   
                    end_date = p.end_date,
                    
                    SchTypName = p.SchType.name,
                    //jo = p.Client.Name,
              
                   // statusId = p.statusId,
                    StatusName = p.ScheduleStatu.title
                 
                });

                if (!string.IsNullOrWhiteSpace(schedname))
                {
                    query = query.Where(q => q.text.Contains(schedname));
                }

                

                if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
                {
                    if (direction.Trim().ToLower() == "asc")
                    {
                        switch (sortBy.Trim().ToLower())
                        {
                            case "schedname":
                                query = query.OrderBy(q => q.text);
                                break;
                            
                        }
                    }
                    else
                    {
                        switch (sortBy.Trim().ToLower())
                        {
                            case "schedname":
                                query = query.OrderByDescending(q => q.text);
                                break;
                          
                        }
                    }
                }
                else
                {
                    query = query.OrderBy(q => q.start_date);
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
        public JsonResult Save(Models.DTO.Schedule record)
        {
            Schedule entity;
            using (cloudbassDBMSEntities context = new cloudbassDBMSEntities())
            {
                if (record.Id == 0)
                {
                    entity = context.Schedules.First(p => p.Id == record.Id);
                    entity.text = record.text;
                    //entity.SchTypeId = record.SchTypeId;
                    //entity.Country = context.Locations.FirstOrDefault(l => l.ID == record.CountryID);
                   // entity.statusId = record.statusId;
                   // entity.JobId = record.JobId;
                   
                    entity.start_date = record.start_date;
                    entity.end_date = record.end_date;
                   
                   
                }
                else
                {
                    context.Schedules.Add(new Schedule
                    {
                        Id = record.Id,
                        text = record.text,
                        //statusId = record.statusId,
                       // JobId = record.JobId,
                       // SchTypeId = record.SchTypeId,
                        start_date = record.start_date,
                        end_date = record.end_date,

                    
                    });
                }
                context.SaveChanges();
            }
            return Json(new { result = true });
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            using (cloudbassDBMSEntities context = new cloudbassDBMSEntities())
            {
                Schedule entity = context.Schedules.First(p => p.Id == id);
                context.Schedules.Remove(entity);
                context.SaveChanges();
            }
            return Json(new { result = true });
        }

        public JsonResult GetHas_Roles(int Id, int? page, int? limit)
        {
            List<Models.DTO.Crew> records;
            int total;
            using (cloudbassDBMSEntities context = new cloudbassDBMSEntities())
            {
                var query = context.Crews.Where(pt => pt.has_roleId == Id && pt.has_roleId==Id).Select(pt => new Models.DTO.Crew
                {
                    has_RoleId = pt.has_roleId,
                    JobId = pt.JobId,
                    //JobName = pt.
                    roleName = pt.Has_Role.Role.Name,

                   // SchTypeId = pt.SchTypeId,
                    totalDays = pt.totalDays,
                   
                    rate = pt.rate
                    

                });

                total = query.Count();
                if (page.HasValue && limit.HasValue)
                {
                    int start = (page.Value - 1) * limit.Value;
                    records = query.OrderBy(pt => pt.roleName).Skip(start).Take(limit.Value).ToList();
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