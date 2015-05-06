using Personal.Entities;
using Personal.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
namespace Personal.Tests
{
    public class JobsBatabaseTests
    {
        public void JobsCanBeSavedAndRetrived()
        {
            var context = new DbPersonalContext();
            //de aici pana unde se inchide am facut add
            var job = new Job
            {
                JobId = "CEO",
                JobTitle = "Chief Executive Officer",
                MinSalary = 1,
                MaxSalary = int.MaxValue
            };
            context.Jobs.Add(job);
            context.SaveChanges();
            //
            //retrive

            var retriveJob=context.Jobs.Single(j => j.JobId == job.JobId);
            
            //verificam ca entitatea salvata in baza de data e identica cu entitatea initiala
            retriveJob.ShouldBe(job);

            //delete
            context.Jobs.Remove(retriveJob);
            context.SaveChanges();
        }

        public void JobCanBeUpdatedAndRetrived()
        {
            var context = new DbPersonalContext();

            var job = new Job
            {
                JobId = "CEO",
                JobTitle = "Chief Executive Officer",
                MinSalary = 1,
                MaxSalary = int.MaxValue
            };
            context.Jobs.Add(job);
            context.SaveChanges();

            //update
            job.JobTitle = "Angajat";
            context.SaveChanges();
            //retrive

            var retriveJob = context.Jobs.Single(j => j.JobId == job.JobId);

            //verificam ca entitatea salvata in baza de data e identica cu entitatea initiala
            retriveJob.ShouldBeSameAs(job);//compara tot obiectul

            //delete
            //context.Jobs.Remove(retriveJob);
            //context.SaveChanges();
            
        }
        public void LocationTest()
        {
            //HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
            var context = new DbPersonalContext();
            //de aici pana unde s einchide am facut add
            var location = new Location
            {
                City = "Bv",
                PostalCode = "1234",
                StateProvince = "dadsa",
                StreetAddress = "hjhgj"
            };
            context.Locations.Add(location);
            context.SaveChanges();
            var retriveJob = context.Locations.Single(d => d.LocationId == location.LocationId);
            context.SaveChanges();
        }
        public void JobTest()
        {
            //HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
            var context = new DbPersonalContext();
            var jobs = context.Jobs.Where(x => x.MinSalary > 100 & x.MaxSalary < 500).ToList();
            var mJobs = jobs.ToList();
        }
        
    }
}
