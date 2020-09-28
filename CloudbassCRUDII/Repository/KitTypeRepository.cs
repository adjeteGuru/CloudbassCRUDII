using CloudbassCRUDII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Repository
{
    public class KitTypeRepository
    {
        //public IEnumerable<SelectListItem> GetKitTypes()
        //{
        //    using (var context = new CBDBEntities())
        //    {
        //        List<SelectListItem> kittypes = context.KitTypes.AsNoTracking()
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
        //        kittypes.Insert(0, kittypetip);
        //        return new SelectList(kittypes, "Value", "Text");
        //    }
        //}
    }
}