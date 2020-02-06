using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class BookingCrewListView
    {
        public int scheduleId { get; set; }

        public ICollection<BookingCrew> BookingCrews { get; set; }
    }
}