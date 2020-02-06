using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class ScheduleListView
    {
      
        public string JobId { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
    }
}