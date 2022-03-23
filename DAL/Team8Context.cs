using MISTeam8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MISTeam8.DAL
{
    public class Team8Context : DbContext
    {
        public Team8Context() : base("name=DefaultConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();  // note: this is all one line!
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Recognition> Recognitions { get; set; }
    }
}