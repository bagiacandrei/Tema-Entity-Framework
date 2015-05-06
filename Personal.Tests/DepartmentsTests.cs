using Personal.Entities;
using Personal.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Tests
{
    class DepartmentsTests
    {
        public void CanAddDepartmet()
        {
            var context = new DbPersonalContext();
            var location = new Location
            {
                City = "Bv",
                PostalCode = "1234",
                StateProvince = "dadsa",
                StreetAddress = "hjhgj"
            };
            var department = new Department
            {
                DepartmentName ="lala",
                Location=location
            };
            context.Departments.Add(department);
            context.SaveChanges();
        }
    }
}
