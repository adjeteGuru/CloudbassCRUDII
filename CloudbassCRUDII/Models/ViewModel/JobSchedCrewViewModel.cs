using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.ViewModel
{
    public class JobSchedCrewViewModel
    {
        //public string Id { get; set; }
        //public string text { get; set; }
      
        //public string Location { get; set; }
        //public string NameConcatenateLocation
        //{
        //    get { return text + " - " + Location; }
        //}

        //public Nullable<System.DateTime> start_date { get; set; }
        //public Nullable<System.DateTime> TXDate { get; set; }
        //public Nullable<System.DateTime> end_date { get; set; }
        //public string Coordinator { get; set; }
        //public string CommercialLead { get; set; }
        //public int ClientId { get; set; }
        //public Nullable<int> statusId { get; set; }

        ////end job

   
        public string text1 { get; set; }
        public System.DateTime startdate { get; set; }
        public Nullable<System.DateTime> enddate { get; set; }
        public Nullable<int> SchTypeId { get; set; }
        public string JobId { get; set; }

        //end schedule

        public int scheduleId { get; set; }
        public int has_RoleId { get; set; }
       public string RoleName { get; set; }
        public Nullable<decimal> totalDays { get; set; }
        public Nullable<decimal> rate { get; set; }




        public Job Job { get; set; }

        public Schedule Schedule { get; set; }
        public Crew BookingCrew { get; set; }
        //public Has_Role Has_Role { get; set; }
    }
}