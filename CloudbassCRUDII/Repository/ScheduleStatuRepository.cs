using CloudbassCRUDII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Repository
{
    public class ScheduleStatuRepository
    {

        //public IEnumerable<SelectListItem> GetScheduleStatus()
        //{
        //    using (var context = new CBDBEntities())
        //    {
        //        List<SelectListItem> schedulestatus = context.ScheduleStatus.AsNoTracking()
        //            .OrderBy(cl => cl.title)
        //            .Select(cl =>
        //            new SelectListItem
        //            {
        //                Value = cl.Id.ToString(),
        //                Text = cl.title
        //            }
        //            ).ToList();

        //        var schedulestatustip = new SelectListItem()
        //        {
        //            Value = null,
        //            Text = "---select status---"
        //        };
        //        schedulestatus.Insert(0, schedulestatustip);
        //        return new SelectList(schedulestatus, "Value", "Text");
        //    }
        //}
    }
}