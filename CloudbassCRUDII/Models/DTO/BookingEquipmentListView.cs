using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class BookingEquipmentListView
    {
        public string JobId { get; set; }

        public ICollection<BookingEquipment> BookingEquipments { get; set; }
    }
}