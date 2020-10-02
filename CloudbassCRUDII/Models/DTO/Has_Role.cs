using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class Has_Role
    {
        [Display(Name = "HasRole ID")]
        public int Id { get; set; }

        [Display(Name = "Employee Name")]
         public int employeeId { get; set; }
        //public string EmployeeName { get; set; }

        [Display(Name = "Role Name")]

        public int roleId { get; set; }
       // public string roleName { get; set; }

        [Display(Name = "Start Date")]
        public Nullable<System.DateTime> start_date { get; set; }

        [Display(Name = "End Date")]
        public Nullable<System.DateTime> end_date { get; set; }

        [Display(Name = "Total Days")]
        public Nullable<decimal> totalDays { get; set; }


        [Display(Name = "Employee Category")]

        //public string CategoName { get; set; }
        public Nullable<int> catId { get; set; }

    }
}