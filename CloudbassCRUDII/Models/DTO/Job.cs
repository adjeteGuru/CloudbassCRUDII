using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class Job
    {

        public string ID { get; set; }
        public string text { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime start_date { get; set; }
        public DateTime TXDate { get; set; }
        public DateTime end_date { get; set; }
        public string Coordinator { get; set; }
        public string CommercialLead { get; set; }
        public int ClientId { get; set; }
        public int statusId { get; set; }

        
    }
}