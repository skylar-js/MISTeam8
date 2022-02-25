using MISTeam8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MISTeam8.DAL
{
    public class Team8Context : DbContext
    {
        public Team8Context() : base("name=DefaultConnection")
        {

        }
        public DbSet<User> Users { get; set; }
    }
}