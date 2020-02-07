using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class Schedule
    {
        [Display(Name = "Sched ID")]
        public int Id { get; set; }

        [Display(Name = "Job ID")]
        public string JobId { get; set; }

        [Display(Name = "Type")]
        public string SchTypName { get; set; }

        //[Display(Name = "Type")]
        //public Nullable<int> SchTypeId { get; set; }

        [Display(Name = "Job Title")]
        public string text { get; set; }

        [Display(Name = "Start Date")]
        public System.DateTime start_date { get; set; }

        [Display(Name = "End Date")]
        public Nullable<System.DateTime> end_date { get; set; }
        // public Nullable<int> SchTypeId { get; set; }

        //public string JobId { get; set; }
        //public string JobName { get; set; }
        // public Nullable<int> statusId { get; set; }

        [Display(Name = "Status")]
        public string StatusName { get; set; }




    }
}