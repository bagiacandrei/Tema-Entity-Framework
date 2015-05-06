namespace Personal.Persistence.Migrations
{
    using Personal.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Personal.Persistence.DbPersonalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Personal.Persistence.DbPersonalContext";
        }

        protected override void Seed(Personal.Persistence.DbPersonalContext context)
        {
            var jobList = new List<Job>(){
            
            new Job()
            {
                JobId="job1",
                JobTitle="Title1",
                MinSalary=200,
                MaxSalary=3000
            },
             new Job()
             {
                JobId="job2",
                JobTitle="Title2",
                MinSalary=200,
                MaxSalary=300
            
            }
        };
            //new Job(){
            //    JobId="job3",
            //    JobTitle="Title3",
            //    MinSalary=200,
            //    MaxSalary=300
            //}
            foreach(var j in jobList)
            {
                context.Jobs.AddOrUpdate(x=>x.JobTitle,j);
            };
}
    }
}
