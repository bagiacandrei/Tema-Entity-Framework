using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Personal.Entities;
using Personal.Persistence;

namespace Personal.WebApi
{
    public class JobsController : ApiController
    {
        private readonly InMemoryHrContext context;
        public JobsController(InMemoryHrContext ctx)
        {
            context = ctx;
        } 
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return Ok(context.Jobs);
        }


        // GET api/<controller>/5
        public IHttpActionResult Get(string id)
        {
            var job = context.Jobs.Find(id);
            if (job != null)
            {
                return Ok(job);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post(Job job)
        {
            var addedJob = context.Jobs.Add(job);
            return CreatedAtRoute("DefaultApi", new { controller = "Jobs", addedJob.JobId }, addedJob);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(Job job)
        {
            var dbJob = context.Jobs.Find(job.JobId);

            if (dbJob != null)
            {
                dbJob.JobTitle = job.JobTitle;
                dbJob.MaxSalary = job.MaxSalary;
                dbJob.MinSalary = job.MinSalary;
            }

            return Ok(context.SaveChanges());
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(string id)
        {
            var dbJob = context.Jobs.Find(id);
            if (dbJob != null)
            {
                return Ok(context.Jobs.Remove(dbJob));
            }
            else
            {
                return NotFound();
            }
        }
    }
}