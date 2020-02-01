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
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<decimal> totalDays { get; set; }
      
        public Nullable<int> catId { get; set; }

    }
}