using CloudbassCRUDII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Controllers
{
    public class SchedulesGroupingController : Controller
    {
        // GET: SchedulesGrouping
        public JsonResult Get(string groupBy, string groupByDirection, int? page, int? limit)
        {
            List<Models.DTO.Job> records;
            int total;
            using (cloudbassDBMSEntities context = new cloudbassDBMSEntities())
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
                    //CountryName = p.Country != null ? p.Country.Name : "",
                    statusId = p.statusId
                });

                if (groupBy == "ClientId")
                {
                    if (groupByDirection.Trim().ToLower() == "asc")
                    {
                        query = query.OrderBy(q => q.ClientName);/*.ThenBy(q => q.OrderNumber);*/
                    }
                    else
                    {
                        query = query.OrderByDescending(q => q.ClientName);/*.ThenBy(q => q.OrderNumber);*/
                    }
                }
                //else
                //{
                //    query = query.OrderBy(q => q.OrderNumber);
                //}

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
    }
}