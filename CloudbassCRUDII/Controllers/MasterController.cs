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
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getEmployeeRole()
        {
            List<Has_Role> roles = new List<Has_Role>();

            using (cloudbassDBMSEntities dc= new cloudbassDBMSEntities())
            {
                roles = dc.Has_Role.OrderBy(x => x.Role.Name).ToList();
            }

              
            return new JsonResult { Data = roles, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public JsonResult getEmployee(int roldId)
        {

            List<Has_Role> employees = new List<Has_Role>();
            using (cloudbassDBMSEntities dc= new cloudbassDBMSEntities())
            {
                employees = dc.Has_Role.Where(x => x.employeeId.Equals(roldId)).OrderBy(x => x.Employee.fullName).ToList();
            }

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
                using (cloudbassDBMSEntities dc= new cloudbassDBMSEntities())
                {
                    dc.Jobs.Add(job);
                    dc.SaveChanges();
                    status = true;
                }
            }

            return new JsonResult { Data = new { status = status } };
        
        }
    }
}