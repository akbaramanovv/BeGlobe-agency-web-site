using BeGlobeProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace BeGlobeProject.DAL
{
    public class BeGlobeDAL : DbContext

    {
        public BeGlobeDAL() : base("BeGlobeDBConnectionString")
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Positionn> Positions { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Advertising> Advertisings { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<Admin> Admin { get; set; }









    }
}