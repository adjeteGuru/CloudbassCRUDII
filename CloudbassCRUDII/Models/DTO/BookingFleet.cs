using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class BookingFleet
    {
        public string JobId { get; set; }
        public int fleetId { get; set; }

        [Display(Name = "Start Date")]
        public Nullable<System.DateTime> start_date { get; set; }

        [Display(Name = "End Date")]
        public Nullable<System.DateTime> end_date { get; set; }

        [Display(Name = "Rate")]
        public Nullable<decimal> rate { get; set; }

        [Display(Name = "Total Days")]
        public Nullable<decimal> totalDays { get; set; }

        //public Nullable<int> createdBy { get; set; }
        [Display(Name = "Staff Name ")]
        public string EmployeeName { get; set; }
    }
}