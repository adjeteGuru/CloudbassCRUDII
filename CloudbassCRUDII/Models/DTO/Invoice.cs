using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class Invoice
    {
        public int Id { get; set; }
        public int scheduleId { get; set; }
        public DateTime dateGenerated { get; set; }
        public string serviceName { get; set; }
        public decimal rate { get; set; }
        public decimal totalDays { get; set; }
        public string adminName { get; set; }
    }
}