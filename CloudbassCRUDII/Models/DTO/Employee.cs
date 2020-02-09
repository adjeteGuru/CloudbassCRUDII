using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class Employee
    {

        [Display(Name = "Emplyee ID")]
        public int Id { get; set; }

        [Display(Name = "Fullname")]
        public string fullName { get; set; }

        [Display(Name = "Mobile")]
        public string mobile { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "County")]
        public int countyId { get; set; }
        //public string countyName { get; set; }

        [Display(Name = "Avoid Job")]
        public string bared { get; set; }

        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Date joined")]
        public Nullable<System.DateTime> startDate { get; set; }

        [Display(Name = "Photo")]
        public string photo { get; set; }

        [Display(Name = "NextOfKin")]
        public string nextOfKin { get; set; }

        [Display(Name = "Alergy")]
        public string alergy { get; set; }

        [Display(Name = "Note")]
        public string note { get; set; }

        [Display(Name = "Post Nominals")]
        public string postNominals { get; set; }


    }
}