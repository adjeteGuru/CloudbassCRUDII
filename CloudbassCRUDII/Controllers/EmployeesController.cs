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
        public JsonResult Get(int? page, int? limit, string sortBy, string direction, string fullname, string bare)
        {
            List<Models.DTO.Employee> records;
            int total;
            using (CloudbassDBMSEntities context = new CloudbassDBMSEntities())
            {
                var query = context.Employees.Select(p => new Models.DTO.Employee
                {
                    Id = p.Id,

                    fullName = p.fullName,
                 
                    mobile  = p.mobile,
                    email= p.email,
                    countyId = p.countyId,
                   // bared = p.bared,
                    // CountyName = p.County != null ? p.County.Name : "",
                     bared = p.bared != null ? p.bared : "",
                    IsAvailable = p.IsAvailable,
                    startDate = p.startDate,
                    note = p.note,
                    photo = p.photo,
                    nextOfKin = p.nextOfKin,
                    alergy = p.alergy,
                    postNominals = p.postNominals,
                   // OrderNumber = p.OrderNumber
                });

                if (!string.IsNullOrWhiteSpace(fullname))
                {
                    query = query.Where(q => q.fullName.Contains(fullname));
                }

                if (!string.IsNullOrWhiteSpace(bare))
                {
                    query = query.Where(q => q.bared.Contains(bare));
                }

                //if (!string.IsNullOrWhiteSpace(lastname))
                //{
                //    query = query.Where(q => q.lastName != null && q.lastName.Contains(lastname));
                //}

                //if (!string.IsNullOrWhiteSpace(bare))
                //{
                //    query = query.Where(q => q.bared != null && q.bared.Contains("a"));
                //}

                //if (!string.IsNullOrWhiteSpace(lastname))
                //{
                //    query = query.Where(q => q.lastName.Contains(lastname));
                //}


                if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
                {
                    if (direction.Trim().ToLower() == "asc")
                    {
                        switch (sortBy.Trim().ToLower())
                        {
                            case "fullname":
                                query = query.OrderBy(q => q.fullName);
                                break;
                            
                            case "bare":
                                query = query.OrderBy(q => q.bared);
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
                            case "fullname":
                                query = query.OrderByDescending(q => q.fullName);
                                break;
                           
                            case "bare":
                                query = query.OrderByDescending(q => q.bared);
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
                    entity.fullName = record.fullName;
                 
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
                        fullName = record.fullName,
                       
                        email = record.email,
                        countyId = record.countyId,
                        mobile = record.mobile,
                        note = record.note,
                        bared = record.bared,
                        startDate = record.startDate,
                       // Has_Role = context.Roles.FirstOrDefault(l => l.Id == record.Id),
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
                var query = context.Has_Role.Where(pt => pt.Id == employeeId ).Select(pt => new Models.DTO.Has_Role
                {
                    
                    Id = pt.Id,
                   
                    start_date = pt.start_date,
                    end_date = pt.end_date,
                    roleId = pt.roleId,
                    employeeId = pt.employeeId,
                    
                    totalDays = pt.totalDays,
                    catId = pt.catId
                   
                }); ;

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