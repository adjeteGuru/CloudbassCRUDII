using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class Equipment
    {
        public int Id { get; set; }
        public string equipmentName { get; set; }
        public Nullable<decimal> rate { get; set; }
        public Nullable<int> equipTypeId { get; set; }
    }
}