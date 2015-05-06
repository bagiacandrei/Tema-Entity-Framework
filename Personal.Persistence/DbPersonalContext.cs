using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Persistence
{
    public class DbPersonalContext:DbContext,IHrContext
    {
     
       public DbSet<Entities.Job> Jobs{get;set;}
       public DbSet<Entities.Location> Locations { get; set; }

        public DbPersonalContext() : base("Personal") { }
        public DbSet<Entities.Department> Departments { get; set; }
        public DbSet<Entities.Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();//cand stergi parintele se sterg si copiii
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
           
            base.OnModelCreating(modelBuilder);
        }
        
        
    }
}
