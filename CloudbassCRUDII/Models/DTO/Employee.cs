using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class Employee
    {


        public int Id { get; set; }
        public string fullName { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public int countyId { get; set; }
        public string bared { get; set; }
        public bool IsAvailable { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public string photo { get; set; }
        public string nextOfKin { get; set; }
        public string alergy { get; set; }
        public string note { get; set; }
        public string postNominals { get; set; }


    }
}