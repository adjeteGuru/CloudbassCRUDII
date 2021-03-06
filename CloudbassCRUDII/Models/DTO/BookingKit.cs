﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class BookingKit
    {
        public string JobId { get; set; }
        public int kitId { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<decimal> totalDays { get; set; }
        public Nullable<decimal> rate { get; set; }

        [Display(Name = "Staff Name ")]
        public string EmployeeName { get; set; }
    }
}