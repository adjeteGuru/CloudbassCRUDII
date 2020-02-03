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
        public System.DateTime start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<int> SchTypeId { get; set; }
        public string SchTypName { get; set; }
        public string JobId { get; set; }
        //public string JobName { get; set; }
         public Nullable<int> statusId { get; set; }
        public string StatusName { get; set; }




    }
}