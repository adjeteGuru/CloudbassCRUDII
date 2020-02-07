using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class BookingFleetListView
    {
        public string JobId { get; set; }

        public ICollection<BookingFleet> BookingFleets { get; set; }
    }
}