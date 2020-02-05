using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class Hotel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string postcode { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public string roomNo { get; set; }
    }
}