using CloudbassCRUDII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Controllers
{
    public class VewModelController : Controller
    {


        // GET: VewModel

      //  public JsonResult Get(int? page, int? limit, string sortBy, string direction, string jobname, string clientname, string location)
      //  {
      //      List<Models.DTO.Job> records;
      //      int total;
      //      using (CloudbassDBMSEntities context = new CloudbassDBMSEntities())
      //      {
      //          var query = context.Jobs
      //              .Select(p => new Models.Job
      //              {
        
      //  text = p.text,

      // // Description = p.Description,
      //  Location = p.Location,
      //  start_date = p.start_date,
      ////  DateCreated = p.DateCreated,
      //  end_date = p.end_date,
      //  TXDate = p.TXDate,
      //  Coordinator = p.Coordinator,
      //  CommercialLead = p.CommercialLead,
      //  ClientId = p.ClientId,
      // // ClientName = p.Client.Name,

      //  statusId = p.statusId,
      //  //StatusName = p.JobStatu.title

      //  });

      //          if (!string.IsNullOrWhiteSpace(jobname))
      //          {
      //              query = query.Where(q => q.text.Contains(jobname));
      //          }

      //          if (!string.IsNullOrWhiteSpace(location))
      //          {
      //              query = query.Where(q => q.Location.Contains(location));
      //          }

      //          //if (!string.IsNullOrWhiteSpace(clientname))
      //          //{
      //          //    query = query.Where(q => q.ClientName.Contains(clientname));
      //          //}



      //          if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
      //          {
      //              if (direction.Trim().ToLower() == "asc")
      //              {
      //                  switch (sortBy.Trim().ToLower())
      //                  {
      //                      case "jobname":
      //                          query = query.OrderBy(q => q.text);
      //                          break;
      //                      case "location":
      //                          query = query.OrderBy(q => q.Location);
      //                          break;
      //                      //case "placeOfBirth":
      //                      //    query = query.OrderBy(q => q.ClientName);
      //                      //    break;

      //                  }
      //              }
      //              else
      //              {
      //                  switch (sortBy.Trim().ToLower())
      //                  {
      //                      case "jobname":
      //                          query = query.OrderByDescending(q => q.text);
      //                          break;
      //                      case "location":
      //                          query = query.OrderByDescending(q => q.Location);
      //                          break;
      //                      //case "placeOfBirth":
      //                      //    query = query.OrderByDescending(q => q.ClientName);
      //                      //    break;

      //                  }
      //              }
      //          }
      //          else
      //          {
      //              query = query.OrderBy(q => q.TXDate);
      //          }

      //          total = query.Count();
      //          if (page.HasValue && limit.HasValue)
      //          {
      //              int start = (page.Value - 1) * limit.Value;
      //              records = query.Skip(start).Take(limit.Value).ToList();
      //          }
      //          else
      //          {
      //              records = query.ToList();
      //          }
      //      }

      //      return this.Json(new { records, total }, JsonRequestBehavior.AllowGet);
      //      }


        //[HttpPost]
        //public JsonResult Save(Models.DTO.Schedule record)
        //{
        //    Schedule entity;
        //    using (CloudbassDBMSEntities context = new CloudbassDBMSEntities())
        //    {
        //        if (record.Id == 0)
        //        {
        //            entity = context.Schedules.First(p => p.Id == record.Id);
        //            entity.text = record.text;
        //            entity.SchTypeId = record.SchTypeId;
        //            //entity.Country = context.Locations.FirstOrDefault(l => l.ID == record.CountryID);
        //            entity.statusId = record.statusId;
        //            entity.JobId = record.JobId;

        //            entity.start_date = record.start_date;
        //            entity.end_date = record.end_date;


        //        }
        //        else
        //        {
        //            context.Schedules.Add(new Schedule
        //            {
        //                Id = record.Id,
        //                text = record.text,
        //                statusId = record.statusId,
        //                JobId = record.JobId,
        //                SchTypeId = record.SchTypeId,
        //                start_date = record.start_date,
        //                end_date = record.end_date,


        //            });
        //        }
        //        context.SaveChanges();
        //    }
        //    return Json(new { result = true });
        //}

        //[HttpPost]
        //public JsonResult Delete(int id)
        //{
        //    using (CloudbassDBMSEntities context = new CloudbassDBMSEntities())
        //    {
        //        Schedule entity = context.Schedules.First(p => p.Id == id);
        //        context.Schedules.Remove(entity);
        //        context.SaveChanges();
        //    }
        //    return Json(new { result = true });
        //}

        public JsonResult GetHas_Roles(int Id, int? page, int? limit)
        {
            List<Models.ViewModel.JobSchedCrewViewModel> records;
            int total;
            using (cloudbassDBMSEntities context = new cloudbassDBMSEntities())
            {
                var query = context.Crews.Where(pt => pt.has_roleId == Id && pt.has_roleId == Id).Select(pt => new Models.ViewModel.JobSchedCrewViewModel
                {
                    has_RoleId = pt.has_roleId,
                    JobId = pt.JobId,
                    //JobName = pt.
                    RoleName = pt.Has_Role.Role.Name,

                    // SchTypeId = pt.SchTypeId,
                    totalDays = pt.totalDays,

                    rate = pt.rate


                });

                total = query.Count();
                if (page.HasValue && limit.HasValue)
                {
                    int start = (page.Value - 1) * limit.Value;
                    records = query.OrderBy(pt => pt.RoleName).Skip(start).Take(limit.Value).ToList();
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