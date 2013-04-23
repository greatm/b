namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_sales : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        SOID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Invoice = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropTable("dbo.Sales");
        }
    }
}
