using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class Fleet
    {
        public int Id { get; set; }
        public string fleetName { get; set; }
        public string reg { get; set; }
        public Nullable<decimal> rate { get; set; }
        public Nullable<int> fleetTypeId { get; set; }
    }
}