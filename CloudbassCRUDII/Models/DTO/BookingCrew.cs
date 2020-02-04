using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class BookingCrew
    {

        public int scheduleId { get; set; }
        public int has_RoleId { get; set; }
        public string roleName { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<decimal> totalDays { get; set; }
        public Nullable<decimal> rate { get; set; }
    }
}