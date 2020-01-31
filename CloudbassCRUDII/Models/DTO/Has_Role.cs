using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class Has_Role
    {
        public int Id { get; set; }
        public int employeeId { get; set; }
        public int roleId { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public decimal totalDays { get; set; }
        public decimal rate { get; set; }
        public int catId { get; set; }
    }
}