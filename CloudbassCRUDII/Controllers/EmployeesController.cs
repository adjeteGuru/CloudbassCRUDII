using CloudbassCRUDII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public JsonResult Get(int? page, int? limit, string sortBy, string direction, string name, string fullname, string lastname)
        {
            List<Models.DTO.Employee> records;
            int total;
            using (CloudbassDBMSEntities context = new CloudbassDBMSEntities())
            {
                var query = context.Employees.Select(p => new Models.DTO.Employee
                {
                    Id = p.Id,
                    
                    firstName = p.firstName,
                    lastName = p.lastName,
                    fullName = p.fullName,
                    mobile  = p.mobile,
                    email= p.email,
                    countyId = p.countyId,
                    bared = p.bared,
                   // CountyName = p.County != null ? p.County.Name : "",
                    IsAvailable = p.IsAvailable,
                    startDate = p.startDate,
                    note = p.note,
                    photo = p.photo,
                    nextOfKin = p.nextOfKin,
                    alergy = p.alergy,
                    postNominals = p.postNominals,
                   // OrderNumber = p.OrderNumber
                });

                if (!string.IsNullOrWhiteSpace(name))
                {
                    query = query.Where(q => q.firstName.Contains(name));
                }

                if (!string.IsNullOrWhiteSpace(fullname))
                {
                    query = query.Where(q => q.fullName != null && q.fullName.Contains(fullname));
                }

                //if (!string.IsNullOrWhiteSpace(county))
                //{
                //    query = query.Where(q => q.countyId != null && q.PlaceOfBirth.Contains(placeOfBirth));
                //}

                if (!string.IsNullOrWhiteSpace(lastname))
                {
                    query = query.Where(q => q.firstName.Contains(lastname));
                }


                if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
                {
                    if (direction.Trim().ToLower() == "asc")
                    {
                        switch (sortBy.Trim().ToLower())
                        {
                            case "name":
                                query = query.OrderBy(q => q.firstName);
                                break;
                            case "fullname":
                                query = query.OrderBy(q => q.lastName);
                                break;
                            case "lastname":
                                query = query.OrderBy(q => q.lastName);
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
                            case "name":
                                query = query.OrderByDescending(q => q.firstName);
                                break;
                            case "fullname":
                                query = query.OrderByDescending(q => q.lastName);
                                break;
                            case "lastname":
                                query = query.OrderByDescending(q => q.fullName);
                                break;
                            //case "dateofbirth":
                            //    query = query.OrderByDescending(q => q.DateOfBirth);
                            //    break;
                        }
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

        [HttpPost]
        public JsonResult Save(Models.DTO.Employee record)
        {
            Employee entity;
            using (CloudbassDBMSEntities context = new CloudbassDBMSEntities())
            {
                if (record.Id > 0)
                {
                    entity = context.Employees.First(p => p.Id == record.Id);
                    entity.firstName = record.firstName;
                    entity.lastName = record.lastName;
                    entity.mobile = record.mobile;
                    entity.note = record.note;
                    entity.countyId = record.countyId;
                    entity.email = record.email;
                    entity.bared = record.bared;
                    entity.startDate = record.startDate;
                    //entity.countyId = record.countyId;
                    //entity.email = record.email;
                   // entity.Country = context.Locations.FirstOrDefault(l => l.ID == record.CountryID);
                    entity.IsAvailable = record.IsAvailable;
                    entity.photo = record.photo;
                    entity.nextOfKin = record.nextOfKin;
                    entity.alergy = record.alergy;
                    entity.postNominals = record.postNominals;
                 
                }
                else
                {
                    context.Employees.Add(new Employee
                    {
                        firstName = record.firstName,
                        lastName = record.lastName,
                        email = record.email,
                        countyId = record.countyId,
                        mobile = record.mobile,
                        note = record.note,
                        bared = record.bared,
                        startDate = record.startDate,
                       // Country = context.Locations.FirstOrDefault(l => l.ID == record.CountryID),
                        IsAvailable = record.IsAvailable,
                        photo = record.photo,
                        nextOfKin = record.nextOfKin,
                        alergy = record.alergy,
                        postNominals = record.postNominals
                    });
                }
                context.SaveChanges();
            }
            return Json(new { result = true });
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            using (CloudbassDBMSEntities context = new CloudbassDBMSEntities())
            {
                Employee entity = context.Employees.First(p => p.Id == id);
                context.Employees.Remove(entity);
                context.SaveChanges();
            }
            return Json(new { result = true });
        }

        public JsonResult GetTeams(int employeeId, int? page, int? limit)
        {
            List<Models.DTO.Has_Role> records;
            int total;
            using (CloudbassDBMSEntities context = new CloudbassDBMSEntities())
            {
                // I USED BOTH FOREIGN KEYS HERE BELONG TO CREW TABLE
                var query = context.BookingCrews.Where(pt => pt.has_RoleId == employeeId && pt.scheduleId == employeeId).Select(pt => new Models.DTO.BookingCrew
                {
                    scheduleId= pt.scheduleId,
                    has_RoleId = pt.has_RoleId,
                   // PlayerID = pt.PlayerID,
                    start_date = pt.end_date,
                    end_date = pt.end_date
                    //Has_Role = pt.Has_Role,
                    //Schedule = pt.Schedule,
                    //Apps = pt.Apps,
                    //Goals = pt.Goals
                });

                total = query.Count();
                if (page.HasValue && limit.HasValue)
                {
                    int start = (page.Value - 1) * limit.Value;
                    records = query.OrderBy(pt => pt.long.Parse(start_date.ToString("")).ToString("11/11/2020").Skip(start).Take(limit.Value).ToList();
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