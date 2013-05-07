namespace b.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using b.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<b.Models.bDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(bDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.whatsnews.AddOrUpdate(
                p => p.WorkTime,

                new whatsnew { WorkTime = new DateTime(2013, 5, 4, 10, 30, 0), Work = "add this update time in site" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 3, 10, 30, 0), Work = "use jquery in site" },
                new whatsnew { WorkTime = new DateTime(2013, 5, 2, 10, 30, 0), Work = "add master customer" },
                new whatsnew { WorkTime = new DateTime(2013, 4, 26, 10, 30, 0), Work = "add master product" },
                new whatsnew { WorkTime = new DateTime(2013, 4, 26, 10, 20, 0), Work = "add master vendor" },
                new whatsnew { WorkTime = new DateTime(2013, 4, 26, 10, 10, 0), Work = "add logo" }
                );
        }
    }
}
