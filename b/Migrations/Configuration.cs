namespace b.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using b.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<bDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(bDBContext context)
        {
            context.whatsnews.AddOrUpdate(
                    p => p.WorkTime,
                    
                    
                    new whatsnew { WorkTime = new DateTime(2013, 5, 10, 12, 0, 0), Work = "add status message" },
                    new whatsnew { WorkTime = new DateTime(2013, 5, 10, 10, 30, 0), Work = "sale create � add box number" },
                    new whatsnew { WorkTime = new DateTime(2013, 5, 9, 10, 30, 0), Work = "add master store" },
                    new whatsnew { WorkTime = new DateTime(2013, 5, 8, 10, 30, 0), Work = "add IsPostedFromThisSite Attribute" },
                    new whatsnew { WorkTime = new DateTime(2013, 5, 7, 10, 30, 0), Work = "install package AntiXSS" },
                    new whatsnew { WorkTime = new DateTime(2013, 5, 6, 10, 30, 0), Work = "product add color and pic" },
                    new whatsnew { WorkTime = new DateTime(2013, 5, 4, 10, 30, 0), Work = "add this update time in site" },
                    new whatsnew { WorkTime = new DateTime(2013, 5, 3, 10, 30, 0), Work = "use jquery in site" },
                    new whatsnew { WorkTime = new DateTime(2013, 5, 2, 10, 30, 0), Work = "add master customer" },
                    new whatsnew { WorkTime = new DateTime(2013, 4, 26, 10, 30, 0), Work = "add master product" },
                    new whatsnew { WorkTime = new DateTime(2013, 4, 26, 10, 20, 0), Work = "add master vendor" },
                    new whatsnew { WorkTime = new DateTime(2013, 4, 26, 10, 10, 0), Work = "add logo" }
                    );
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
        }
    }
}
