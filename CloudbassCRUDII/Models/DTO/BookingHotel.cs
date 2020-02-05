using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class BookingHotel
    {

        public string JobId { get; set; }
        public int hotelId { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_time { get; set; }
        public Nullable<decimal> totalDays { get; set; }
        public Nullable<decimal> cost { get; set; }
        public Nullable<int> createdBy { get; set; }

    }
}