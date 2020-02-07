using CloudbassCRUDII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Repository
{
    public class MetadataRepository
    {

        public IEnumerable<SelectListItem> GetBookingTypes()
        {
            using (var context = new cloudbassDBMSEntities())
            {
                List<SelectListItem> bookingtypes = context.BookingTypes.AsNoTracking()
                    .OrderBy(x => x.bookingTypeId)
                    .Select(x =>
                    new SelectListItem
                    {
                        Value = x.bookingTypeId,
                        Text = x.bookingTypeId
                    }).ToList();
                return new SelectList(bookingtypes, "Value", "Text");
            }
        }

    }
}