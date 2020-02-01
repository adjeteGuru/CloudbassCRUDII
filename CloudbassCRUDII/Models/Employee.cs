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
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Has_Role = new HashSet<Has_Role>();
        }
    
        public int Id { get; set; }
        public string fullName { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public int countyId { get; set; }
        public string bared { get; set; }
        public bool IsAvailable { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public byte[] photo { get; set; }
        public string nextOfKin { get; set; }
        public string alergy { get; set; }
        public string note { get; set; }
        public string postNominals { get; set; }
    
        public virtual County County { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Has_Role> Has_Role { get; set; }
    }
}
