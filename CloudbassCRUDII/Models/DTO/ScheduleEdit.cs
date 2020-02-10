using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Models.DTO
{
    public class ScheduleEdit
    {
       
        public int Id { get; set; }

        
        public string JobId { get; set; }

        [Display(Name = "Type")]
       // public Nullable<int> SchTypeId { get; set; }
        public int SelectedSchType { get; set; }
        public IEnumerable<SelectListItem> SchType { get; set; }

        [Display(Name = "Job Title")]
        public string text { get; set; }

        [Display(Name = "Start Date")]
        public System.DateTime start_date { get; set; }

        [Display(Name = "End Date")]
        public Nullable<System.DateTime> end_date { get; set; }
      

        //public string JobId { get; set; }
        //public string JobName { get; set; }
  

        [Display(Name = "Status")]
        //public Nullable<int> statusId { get; set; }
        public int SelectedStatus { get; set; }
        public IEnumerable<SelectListItem> ScheduleStatu { get; set; }
    }
}