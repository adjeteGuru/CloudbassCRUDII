using CloudbassCRUDII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Repository
{
    public class EquipmentTypeRepository
    {
        //public IEnumerable<SelectListItem> GetEquipmentTypes()
        //{
        //    using (var context = new CBDBEntities())
        //    {
        //        List<SelectListItem> equipmenttypes = context.EquipTypes.AsNoTracking()
        //            .OrderBy(cl => cl.name)
        //            .Select(cl =>
        //            new SelectListItem
        //            {
        //                Value = cl.Id.ToString(),
        //                Text = cl.name
        //            }
        //            ).ToList();

        //        var kittypetip = new SelectListItem()
        //        {
        //            Value = null,
        //            Text = "---select Type---"
        //        };
        //        equipmenttypes.Insert(0, kittypetip);
        //        return new SelectList(equipmenttypes, "Value", "Text");
        //    }
        //}
    }
}