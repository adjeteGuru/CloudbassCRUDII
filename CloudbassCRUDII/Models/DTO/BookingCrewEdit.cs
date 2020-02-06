using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Models.DTO
{
    public class BookingCrewEdit
    {

        [Display(Name = "Sched ID")]
        public int scheduleId { get; set; }
               

        [Display(Name = "HasRoleID")]

        public int has_RoleId { get; set; }
               

        [Display(Name = "Start Date")]
        public Nullable<System.DateTime> start_date { get; set; }

        [Display(Name = "End Date")]
        public Nullable<System.DateTime> end_date { get; set; }

        [Display(Name = "Total Days")]
        public Nullable<decimal> totalDays { get; set; }

        [Display(Name = "Rate")]
        public Nullable<decimal> rate { get; set; }

        [Display(Name = "Edited By")]
        public string SelectedEmployee { get; set; }
        public IEnumerable<SelectListItem> Employees { get; set; }
    }
}