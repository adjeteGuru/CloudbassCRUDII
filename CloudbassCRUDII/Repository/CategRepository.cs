using CloudbassCRUDII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Repository
{
    public class CategRepository
    {
        public IEnumerable<SelectListItem> GetCategs()
        {
            using (var context = new CBDBEntities())
            {
                List<SelectListItem> categs = context.Categs.AsNoTracking()
                    .OrderBy(cl => cl.name)
                    .Select(cl =>
                    new SelectListItem
                    {
                        Value = cl.Id.ToString(),
                        Text = cl.name
                    }
                    ).ToList();

                var categstip = new SelectListItem()
                {
                    Value = null,
                    Text = "---select category---"
                };
                categs.Insert(0, categstip);
                return new SelectList(categs, "Value", "Text");
            }
        }
    }
}