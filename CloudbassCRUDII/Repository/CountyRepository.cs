using CloudbassCRUDII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Repository
{
    public class CountyRepository
    {
        public IEnumerable<SelectListItem> GetCounties()
        {
            using (var context = new CBDBEntities())
            {
                List<SelectListItem> counties = context.Counties.AsNoTracking()
                    .OrderBy(cl => cl.Name)
                    .Select(cl =>
                    new SelectListItem
                    {
                        Value = cl.Id.ToString(),
                        Text = cl.Name
                    }
                    ).ToList();

                var countiestip = new SelectListItem()
                {
                    Value = null,
                    Text = "---select county---"
                };
                counties.Insert(0, countiestip);
                return new SelectList(counties, "Value", "Text");
            }
        }
    }
}