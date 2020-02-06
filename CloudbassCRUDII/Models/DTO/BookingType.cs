using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Models.DTO
{
    public class BookingType
    {
        public string CustomerID { get; set; } // Carries the value in POST action.

        [Display(Name = "Booking Type")]
        public string SelectedBookingType { get; set; }
        public IEnumerable<SelectListItem> BookingTypes { get; set; }
    }
}