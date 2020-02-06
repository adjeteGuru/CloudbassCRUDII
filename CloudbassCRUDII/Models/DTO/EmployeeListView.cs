using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudbassCRUDII.Models.DTO
{
    public class EmployeeListView
    {
        public int employeeId { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}