namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_customer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Company = c.String(),
                        Active = c.Boolean(nullable: false),
                        ServiceLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
