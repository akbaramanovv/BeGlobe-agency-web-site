namespace BeGlobeProject.Migrations
{
    using BeGlobeProject.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BeGlobeProject.DAL.BeGlobeDAL>
    {
        public Configuration()
        {
        }

        protected override void Seed(BeGlobeProject.DAL.BeGlobeDAL context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            IList<Admin> admin = new List<Admin>();
            admin.Add(new Admin()
            {
                UserName = "admin",
                Password = "admin"
            });

            context.Admin.AddRange(admin);

            base.Seed(context);
        }
    }
}
