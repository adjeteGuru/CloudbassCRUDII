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
    
    public partial class Schedule
    {
        public int Id { get; set; }
        public string text { get; set; }
        public System.DateTime start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<int> SchTypeId { get; set; }
        public string JobId { get; set; }
        public Nullable<int> statusId { get; set; }
    
        public virtual ScheduleStatu ScheduleStatu { get; set; }
        public virtual SchType SchType { get; set; }
        public virtual Job Job { get; set; }
    }
}
