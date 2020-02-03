using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.ViewModel
{
    public class JobSchedCrewViewModel
    {
        public Job Job { get; set; }

        public Schedule Schedule { get; set; }
        public BookingCrew BookingCrew { get; set; }
        public Has_Role Has_Role { get; set; }
    }
}