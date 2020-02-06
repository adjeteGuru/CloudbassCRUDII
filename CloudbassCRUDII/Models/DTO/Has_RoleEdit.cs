using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Models.DTO
{
    public class Has_RoleEdit
    {
        [Display(Name = "HasRole ID")]
        public int Id { get; set; }

        [Display(Name = "Employee Name")]
        // public int employeeId { get; set; }
        public string SelectedEmployee { get; set; }
        public IEnumerable<SelectListItem> Employees { get; set; }

        [Display(Name = "Role Name")]

        //public int roleId { get; set; }
        public string SelectedRole { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }

        [Display(Name = "Start Date")]
        public Nullable<System.DateTime> start_date { get; set; }

        [Display(Name = "End Date")]
        public Nullable<System.DateTime> end_date { get; set; }

        [Display(Name = "Total Days")]
        public Nullable<decimal> totalDays { get; set; }


        [Display(Name = "Employee Category")]

        public string SelectedCateg { get; set; }
        public IEnumerable<SelectListItem> Categs { get; set; }
    }
}