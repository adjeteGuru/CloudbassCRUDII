﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class BookingKitListView
    {
        public string JobId { get; set; }

        public ICollection<BookingKit> BookingKits { get; set; }
    }
}