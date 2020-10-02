using CloudbassCRUDII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Controllers
{
    public class MultipleController : Controller
    {
        private CBDBEntities context = new CBDBEntities();
        // GET: Multiple
        public ActionResult Index()
        {
            //List<Has_Role> has_Roles;
            List<Has_Role> hasRoleList = context.Has_Role.ToList();
            List<Job> jobList = context.Jobs.ToList();
            List<Crew> crewList = context.Crews.ToList();

            var multipleTable = from j in jobList
                                join c in crewList on j.Id equals c.jobId into table1
                                from c in table1.DefaultIfEmpty()
                                join h in hasRoleList on c.has_RoleId equals h.Id into table2
                                from h in table2.DefaultIfEmpty()
                                select new MultipleClass { JobDetails = j, CrewDetails = c, HasRoleDetails = h };


            return View(multipleTable);
        }
    }
}