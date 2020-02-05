//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CloudbassCRUDII.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookingFleet
    {
        public string JobId { get; set; }
        public int fleetId { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<decimal> rate { get; set; }
        public Nullable<decimal> totalDays { get; set; }
        public Nullable<int> createdBy { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Fleet Fleet { get; set; }
        public virtual Job Job { get; set; }
    }
}
