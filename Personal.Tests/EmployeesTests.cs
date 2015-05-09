using Personal.Entities;
using Personal.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Fixie;

namespace Personal.Tests
{
    
    class EmployeesTests
    {   
        public void EmployeesCanBeSavedAndRetrived()
        {
            var context = new DbPersonalContext();
            //de aici pana unde se inchide am facut add
            var job = new Job { JobId = "DEVddad", JobTitle = "Developer", MaxSalary = 2000, MinSalary = 1000 };
            var location = new Location()
            {
                City = "sdad",
                LocationId = 5,
                PostalCode = "1234",
                StateProvince = "asdasd",
                StreetAddress = "pppp"
            };

            var department = new Department()
            {
                DepartmentId = 1,
                DepartmentName = "llll",
                Location = location
            };
           
            var manager = new Employee()
            {
                EmployeeId = 1,
                CommisionPercent = 2,
                Email = "lkjkljklj",
                FirstName = "fgfgfg",
                HireDate = new DateTime(2014, 04, 13),
                LastName = "fgfgfg",
                PhoneNumber = "123456789",
                Salary = 1234,
                Department = department,
                Job = job,
                Manager = null
            };
            var employee = new Employee
            {
                EmployeeId = 1,
                FirstName = "Ionasdas",
                LastName = "Popescusadasd",
                CommisionPercent = 23,
                Email = "Popescu@email.com",
                HireDate = DateTime.Now.AddYears(-2),
                PhoneNumber = "123123123",
                Salary = 1234,
                Job = job,
                Department = department,
                Manager = manager
            };
            context.Employees.Add(employee);
            
            context.SaveChanges();

            var retriveEmployee = context.Employees.Single(e => e.EmployeeId == employee.EmployeeId);
            context.SaveChanges();
            

            //verificam ca entitatea salvata in baza de data e identica cu entitatea initiala
            retriveEmployee.ShouldBe(employee);
        }
    }
}
