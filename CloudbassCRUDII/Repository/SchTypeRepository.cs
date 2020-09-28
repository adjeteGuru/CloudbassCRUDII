using CloudbassCRUDII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Repository
{
    public class SchTypeRepository
    {

        public IEnumerable<SelectListItem> GetSchTypes()
        {
            using (var context = new CBDBEntities())
            {
                List<SelectListItem> schtype = context.SchTypes.AsNoTracking()
                    .OrderBy(cl => cl.name)
                    .Select(cl =>
                    new SelectListItem
                    {
                        Value = cl.Id.ToString(),
                        Text = cl.name
                    }
                    ).ToList();

                var schtypestip = new SelectListItem()
                {
                    Value = null,
                    Text = "---select type---"
                };
                schtype.Insert(0, schtypestip);
                return new SelectList(schtype, "Value", "Text");
            }
        }

        //public string GetSchTypeName(int? id)
        //{
        //    if (id != null)
        //    {
        //        using (var context = new CBDBEntities())
        //        {
        //            var schtypeName = context.SchTypes.AsNoTracking()
        //                .Where(x => x.Id == id)
        //                .Single();
        //            if (schtypeName != null)
        //            {
        //                var schtypename = schtypeName.name.Trim();
        //                return schtypename;
        //            }
        //        }
        //    }
        //    return null;
        //}
    }
}