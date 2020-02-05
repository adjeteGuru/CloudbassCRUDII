using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class BookingEquipment
    {
        public string JobId { get; set; }
        public int equipmentId { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<decimal> rate { get; set; }
        public Nullable<decimal> totalDays { get; set; }
        public Nullable<int> createdBy { get; set; }

       
    }
}