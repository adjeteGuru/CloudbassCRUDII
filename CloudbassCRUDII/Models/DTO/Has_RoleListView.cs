using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class Has_RoleListView
    {
        public int scheduleId { get; set; }
        public int has_RoleId { get; set; }

        public ICollection<Has_Role> Has_Roles { get; set; }
    }
}