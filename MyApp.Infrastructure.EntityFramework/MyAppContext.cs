using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.EntityFramework
{
    public class MyAppContext : DbContext
    {

        public MyAppContext() : base("MyApp")
        {
        }

        public DbSet<Domain.Task> Tasks { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //}
    }
}
