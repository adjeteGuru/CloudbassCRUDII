using CloudbassCRUDII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Controllers
{
    public class MasterController : Controller
    {
        private CBDBEntities dc = new CBDBEntities();
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getEmployeeRole()
        {
            //List<Role> roles = new List<Role>();

            //using (CBDBEntities dc = new CBDBEntities())
            //{
            //    roles = dc.Roles.OrderBy(x => x.Name).ToList();
            //}

            var roles = dc.Roles.OrderBy(x => x.Name).ToList();


            return new JsonResult { Data = roles, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        //THIS SEREVE TO GET EMPLOYEE DETAILS FROM ROLE FOREIGN KEY

        public JsonResult getEmployees(int countyID)
        {

            //List<Employee> employees = new List<Employee>();

            //using (CBDBEntities dc = new CBDBEntities())
            //{
            //employees = dc.Employees.Where(x => x.roleId.Equals(roleID)).OrderBy(x => x.fullName).ToList();
            var employees = dc.Employees.Where(x => x.countyId == countyID).OrderBy(x => x.firstName).ToList();
            //}

            return new JsonResult { Data = employees, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }




        [HttpPost]

        public JsonResult save(Job job)
        {
            bool status = false;

            DateTime dateOrd;
            var isValidDate = DateTime.TryParseExact(job.DateCreatedString, "mm-dd-yyyy", null, System.Globalization.DateTimeStyles.None, out dateOrd);
            if (isValidDate)
            {
                job.DateCreated = dateOrd;
            }

            var isValidModel = TryUpdateModel(job);
            if (isValidModel)
            {
                //using (CBDBEntities dc = new CBDBEntities())
                //{
                //    dc.Jobs.Add(job);
                //    dc.SaveChanges();
                //    status = true;
                //}

                dc.Jobs.Add(job);
                dc.SaveChanges();
                status = true;
            }

            return new JsonResult { Data = new { status = status } };

        }
    }
}