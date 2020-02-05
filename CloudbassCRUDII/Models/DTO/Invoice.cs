using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class Invoice
    {
        public int Id { get; set; }
        public string JobId { get; set; }
        public Nullable<System.DateTime> dateGenerated { get; set; }
        public Nullable<decimal> rate { get; set; }
        public Nullable<decimal> totalDays { get; set; }
        public Nullable<int> createdBy { get; set; }
    }
}