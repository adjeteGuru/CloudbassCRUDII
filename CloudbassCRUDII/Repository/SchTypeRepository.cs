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
            using (var context = new cloudbassDBMSEntities())
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
    }
}