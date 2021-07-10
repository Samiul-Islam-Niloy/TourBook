using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TourBook_V9.Models
{
    public class EventNameList: DbContext
    {
        public EventNameList() : base("EventDatabase") { }
        public DbSet<EventNameInput> NameList { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventNameInput>().ToTable("NameList");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

    }
}