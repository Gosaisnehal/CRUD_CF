using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CRUD_CF.DAL
{
    public class crudDBContext : DbContext
    {
        public crudDBContext() : base("contact")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().MapToStoredProcedures();
        }
    }


}