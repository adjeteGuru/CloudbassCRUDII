using CloudbassCRUDII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Repository
{
    public class RoleRepository
    {
        public IEnumerable<SelectListItem> GetRoles()
        {
            using (var context = new cloudbassDBMSEntities())
            {
                List<SelectListItem> roles = context.Roles.AsNoTracking()
                    .OrderBy(cl => cl.Name)
                    .Select(cl =>
                    new SelectListItem
                    {
                        Value = cl.Id.ToString(),
                        Text = cl.Name
                    }
                    ).ToList();

                var rolestip = new SelectListItem()
                {
                    Value = null,
                    Text = "---select role---"
                };
                roles.Insert(0, rolestip);
                return new SelectList(roles, "Value", "Text");
            }
        }
    }
}