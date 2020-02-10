using CloudbassCRUDII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Repository
{
    public class JobStatuRepository
    {
        public IEnumerable<SelectListItem> GetJobStatus()
        {
            using (var context = new cloudbassDBMSEntities())
            {
                List<SelectListItem> jobstatus = context.JobStatus.AsNoTracking()
                    .OrderBy(cl => cl.title)
                    .Select(cl =>
                    new SelectListItem
                    {
                        Value = cl.Id.ToString(),
                        Text = cl.title
                    }
                    ).ToList();

                var jobstatustip = new SelectListItem()
                {
                    Value = null,
                    Text = "---select status---"
                };
                jobstatus.Insert(0, jobstatustip);
                return new SelectList(jobstatus, "Value", "Text");
            }
        }

        public string GetJobStatuName(int? id)
        {
            if (id != null)
            {
                using (var context = new cloudbassDBMSEntities())
                {
                    var jobstatuName = context.JobStatus.AsNoTracking()
                        .Where(x => x.Id == id)
                        .Single();
                    if (jobstatuName != null)
                    {
                        var jobstatuname = jobstatuName.title.Trim();
                        return jobstatuname;
                    }
                }
            }
            return null;
        }
    }
}