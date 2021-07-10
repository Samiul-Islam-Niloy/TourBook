using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TourBook_V9.Models
{
    public class DB_EntitiesEvent: DbContext
    {
        public DB_EntitiesEvent() : base("EventDatabase") { }
        public DbSet<CreateEvent> Events { get; set; }
      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreateEvent>().ToTable("Events");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}