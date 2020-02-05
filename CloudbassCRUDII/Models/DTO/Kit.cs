using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class Kit
    {

        public int Id { get; set; }
        public string kitName { get; set; }
        public string model { get; set; }
        public Nullable<decimal> rate { get; set; }
        public Nullable<int> kitTypeId { get; set; }
    }
}