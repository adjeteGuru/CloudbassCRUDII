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
        public decimal rate { get; set; }
        public int kitTypeId { get; set; }
    }
}