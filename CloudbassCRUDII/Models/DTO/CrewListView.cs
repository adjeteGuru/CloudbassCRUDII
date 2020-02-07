using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class CrewListView
    {
        public string JobId { get; set; }

        public ICollection<Crew> Crews { get; set; }
    }
}