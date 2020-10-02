using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models
{
    public class MultipleClass
    {
        public Employee EmployeeDetails { get; set; }
        public Role RoleDetails { get; set; }
        public Has_Role HasRoleDetails { get; set; }
        public Job JobDetails { get; set; }
        public Crew CrewDetails { get; set; }

    }
}