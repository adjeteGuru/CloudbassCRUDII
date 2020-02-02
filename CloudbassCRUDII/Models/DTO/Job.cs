using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class Job
    {

        public string Id { get; set; }
        public string text { get; set; }
        public string Description { get; set; }

        public string NameConcatenateLocation
        {
            get { return text + " - " + Location; }
        }

        public string Location { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> TXDate { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public string Coordinator { get; set; }
        public string CommercialLead { get; set; }
        public int ClientId { get; set; }

        public string ClientName { get; set; }
        public Nullable<int> statusId { get; set; }

        public string StatusName { get; set; }


    }
}