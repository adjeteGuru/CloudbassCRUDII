using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class Job
    {
        [Display(Name = "Job Number")]
        public string Id { get; set; }

        [Display(Name = "Job Title")]
        public string text { get; set; }

        [Display(Name = "Job Description")]
        public string Description { get; set; }
        //[Display(Name = "Customer Number")]

        public string NameConcatenateLocation
        {
            get { return text + " - " + Location; }
        }
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Date created")]
        public Nullable<System.DateTime> DateCreated { get; set; }

        [Display(Name = "Start Date")]
        public Nullable<System.DateTime> start_date { get; set; }

        [Display(Name = "Transmission")]
        public Nullable<System.DateTime> TXDate { get; set; }

        [Display(Name = "End Date")]
        public Nullable<System.DateTime> end_date { get; set; }

        [Display(Name = "Coordinator")]
        public string Coordinator { get; set; }

        [Display(Name = "Commercial Lead")]
        public string CommercialLead { get; set; }

        [Display(Name = "Client Name")]
        public int ClientId { get; set; }


         //public string ClientName { get; set; }

        [Display(Name = "Status")]

        public Nullable<int> statusId { get; set; }


       // public string StatusName { get; set; }


    }
}