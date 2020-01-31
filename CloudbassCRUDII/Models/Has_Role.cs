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
    
    public partial class Has_Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Has_Role()
        {
            this.BookingCrews = new HashSet<BookingCrew>();
        }
    
        public int Id { get; set; }
        public int employeeId { get; set; }
        public int roleId { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<decimal> totalDays { get; set; }
        public Nullable<decimal> rate { get; set; }
        public Nullable<int> catId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingCrew> BookingCrews { get; set; }
        public virtual Categ Categ { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }
    }
}
