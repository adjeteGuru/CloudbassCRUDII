﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class BookingCrew
    {
        [Display(Name = "Sched ID")]
        public int scheduleId { get; set; }

        [Display(Name = "Schedule Name")]
        public int scheduleName { get; set; }

        [Display(Name = "HasRoleID")]

        public int has_RoleId { get; set; }

        [Display(Name = "Role Name")]
        public string roleName { get; set; }

        [Display(Name = "Start Date")]
        public Nullable<System.DateTime> start_date { get; set; }

        [Display(Name = "End Date")]
        public Nullable<System.DateTime> end_date { get; set; }

        [Display(Name = "Total Days")]
        public Nullable<decimal> totalDays { get; set; }

        [Display(Name = "Rate")]
        public Nullable<decimal> rate { get; set; }

        [Display(Name = "Edited By")]
        public string EmployeeName { get; set; }
    }
}