using CloudbassCRUDII.Models;
using PagedList;
using System;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CloudbassCRUDII.Controllers
{
    public class EmployeeDController : Controller
    {
        private CBDBEntities db = new CBDBEntities();


        public ViewResult Index(string sortEvent, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortEvent;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortEvent) ? "name_desc" : "";




            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var employees = from e in db.Employees
                            .Include(e => e.County)

                            select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e => e.firstName.Contains(searchString));
                //|| e.fullName.Contains(searchString));
            }

            switch (sortEvent)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(e => e.firstName);
                    break;



                default: // name ascending
                    employees = employees.OrderBy(e => e.countyId);
                    break;

            }

            int pageSize = 7;
            int pageNumber = (page ?? 1);

            return View(employees.ToPagedList(pageNumber, pageSize));
        }


        // GET: EmployeeD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: EmployeeD/Create
        public ActionResult Create()
        {
            ViewBag.countyId = new SelectList(db.Counties, "Id", "Name");
            return View();
        }

        // POST: EmployeeD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,fullName,mobile,email,countyId,bared,IsAvailable,startDate,photo,nextOfKin,alergy,note,postNominals")] Employee employee, HttpPostedFileBase file)
        {

            string filename = Path.GetFileName(file.FileName);
            string _filename = DateTime.Now.ToString("yymmssfff") + filename;
            string extension = Path.GetExtension(file.FileName);
            string path = Path.Combine(Server.MapPath("~/Images/"), _filename);
            employee.photo = "~/Images/" + _filename;
            if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
            {
                //if (file.ContentLength <= 1000000)
                //{
                db.Employees.Add(employee);
                //db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.countyId = new SelectList(db.Counties, "Id", "Name", employee.countyId);
            return View(employee);

            //NEW BEGINNING

            //        if (db.SaveChanges() > 0)
            //        {
            //            file.SaveAs(path);
            //            ViewBag.photo = "Record Added";
            //            ModelState.Clear();
            //        }
            //    }
            //    else
            //    {
            //        ViewBag.photo = "Size is not valid";
            //    }
            //}
            //return View();

            //END NEW


            //if (ModelState.IsValid)
            //{
            //to convert the user photo as Byte Array before save tp DB
            //string convert = hdnImage.Replace("data:image/png;imageData,", String.Empty);

            //var imageParts = model.ImageAsString.Split(',').ToList<string>();
            //Exclude the header from base64 by taking second element in List.


            // Byte[] imageData = Convert.FromBase64String(imageParts[1]);
            //if (Request.Files.Count> 0)
            //{
            // HttpPostedFileBase ImageData = Request.Files["ImageData"];
            //    ContentRepository service = new ContentRepository();
            //    int i = service.UploadImageInDataBase(file, employee);

            //    using (var binary = new BinaryReader(poImgFile.InputStream))
            //    {
            //        imageData = binary.ReadBytes(poImgFile.ContentLength);
            //    }
            //}

            //    int i = UploadImageInDataBase(ImageData, employee);
            //if (i == 1)
            //{
            //    return RedirectToAction("Index");
            //}
            //return View(employee);
            //}


            //db.Employees.Add(employee);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.countyId = new SelectList(db.Counties, "Id", "Name", employee.countyId);
            //return View(employee);
        }

        //public int UploadImageInDataBase(HttpPostedFileBase file, Employee employee)
        //{
        // employee.photo = ConvertToBytes(file);// store the image bytes to database directly
        //var Content = new Content
        //{
        //    Title = contentViewModel.Title,

        //    Description = contentViewModel.Description,

        //    Contents = contentViewModel.Contents,

        //    Image = contentViewModel.Image
        //};


        //db.Employees.Add(employee);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");

        //    db.Employees.Add(employee);
        //    int i = db.SaveChanges();


        //    if (i == 1)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }

        //}

        //public byte[] ConvertToBytes(HttpPostedFileBase image)
        //{
        //    byte[] imageBytes = null;
        //    BinaryReader reader = new BinaryReader(image.InputStream);
        //    imageBytes = reader.ReadBytes((int)image.ContentLength);
        //    return imageBytes;
        //}

        // GET: EmployeeD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.countyId = new SelectList(db.Counties, "Id", "Name", employee.countyId);
            return View(employee);
        }

        // POST: EmployeeD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,fullName,mobile,email,countyId,bared,IsAvailable,startDate,photo,nextOfKin,alergy,note,postNominals")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.countyId = new SelectList(db.Counties, "Id", "Name", employee.countyId);
            return View(employee);
        }

        // GET: EmployeeD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: EmployeeD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
