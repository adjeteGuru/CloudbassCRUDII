using CloudbassCRUDII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Repository
{
    public class FleetTypeRepository
    {
        //public IEnumerable<SelectListItem> GetFleetTypes()
        //{
        //using (var context = new CBDBEntities())
        //{
        //    List<SelectListItem> fleettypes = context.FleetTypes.AsNoTracking()
        //        .OrderBy(cl => cl.name)
        //        .Select(cl =>
        //        new SelectListItem
        //        {
        //            Value = cl.Id.ToString(),
        //            Text = cl.name
        //        }
        //        ).ToList();

        //    var clienttip = new SelectListItem()
        //    {
        //        Value = null,
        //        Text = "---select Type---"
        //    };
        //    fleettypes.Insert(0, clienttip);
        //    return new SelectList(fleettypes, "Value", "Text");
        //}
        //}
    }
}