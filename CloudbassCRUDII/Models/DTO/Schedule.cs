using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class Schedule
    {

        public int Id { get; set; }
        public string text { get; set; }
        public DateTime start_date { get; set; }
        public DateTime  end_date { get; set; }
        public int SchTypeId { get; set; }
        public string JobId { get; set; }
        public int statusId { get; set; }
        public int AdminId { get; set; }
        public bool is_approved { get; set; }

    }
}