using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Personal.Entities;
using Personal.Persistence;
namespace Personal.WebApi
{
    public class DepartmentsController : ApiController
    {
        private readonly InMemoryHrContext context;

        public DepartmentsController(InMemoryHrContext ctx)
        {
            context = ctx;
        }
        // GET: api/Departments
        public IHttpActionResult Get()
        {
            return Ok(context.Departments);
        }

        // GET: api/Departments/5
        public IHttpActionResult Get(int id)
        {
            var department = context.Departments.Find(id);
            if (department != null)
            {
                return Ok(department);
            }
            else
            {
                return NotFound();
            }
        }
        // POST: api/Departments
        public IHttpActionResult Post(Department department)
        {
            var addedDepartment = context.Departments.Add(department);
            return CreatedAtRoute("DefaultApi", new { controller = "Departments", addedDepartment.DepartmentId }, addedDepartment);
        }

        // PUT: api/Departments/5
        public IHttpActionResult Put(Department department)
        {
            var dbDepartement = context.Departments.Find(department.DepartmentId);

            if (dbDepartement != null)
            {
                dbDepartement.DepartmentName = department.DepartmentName;
                if (department.Location != null && dbDepartement.Location != null)
                {
                    dbDepartement.Location.LocationId = department.Location.LocationId;
                    dbDepartement.Location.City = department.Location.City;
                    dbDepartement.Location.PostalCode = department.Location.PostalCode;
                    dbDepartement.Location.StateProvince = department.Location.StateProvince;
                    dbDepartement.Location.StreetAddress = department.Location.StreetAddress;
                }
                else
                {
                    throw new BadRequest("There is no location");
                }
            }
            else
            {
                throw new BadRequest("There is no location!");
            }

            return Ok(context.SaveChanges());
        }


        // DELETE: api/Departments/5
        public IHttpActionResult Delete(int id)
        {
            var dbDepartement = context.Departments.Find(id);
            if (dbDepartement != null)
            {
                return Ok(context.Departments.Remove(dbDepartement));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
