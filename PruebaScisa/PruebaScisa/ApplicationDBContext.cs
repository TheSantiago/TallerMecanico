using PruebaScisa.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaScisa
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext():base("name=AppConnectionString")
        {

        }
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
    }
}