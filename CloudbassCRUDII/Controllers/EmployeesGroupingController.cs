using CloudbassCRUDII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Controllers
{
    public class EmployeesGroupingController : Controller
    {
        // GET: EmployeesGrouping
        public JsonResult Get(string groupBy, string groupByDirection, int? page, int? limit)
        {
            List<Models.DTO.Employee> records;
            int total;
            using (CBDBEntities context = new CBDBEntities())
            {
                var query = context.Employees.Select(p => new Models.DTO.Employee
                {
                    Id = p.Id,
                    firstName = p.firstName,

                    mobile = p.mobile,
                    email = p.email,
                    countyId = p.countyId,
                    bared = p.bared,
                    // CountyName = p.County != null ? p.County.Name : "",
                    // bared = p.bared != null ? p.bared : "",
                    IsAvailable = p.IsAvailable,
                    startDate = p.startDate,
                    note = p.note,
                    photo = p.photo,
                    nextOfKin = p.nextOfKin,
                    alergy = p.alergy,
                    postNominals = p.postNominals,

                });

                if (groupBy == "County")
                {
                    if (groupByDirection.Trim().ToLower() == "asc")
                    {
                        query = query.OrderBy(q => q.countyId);
                    }
                    else
                    {
                        query = query.OrderByDescending(q => q.countyId);
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