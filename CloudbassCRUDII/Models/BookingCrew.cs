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
    
    public partial class BookingCrew
    {
        public int scheduleId { get; set; }
        public int has_RoleId { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<decimal> totalDays { get; set; }
        public Nullable<decimal> rate { get; set; }
    
        public virtual Has_Role Has_Role { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
