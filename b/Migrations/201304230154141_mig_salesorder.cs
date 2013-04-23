namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_salesorder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropTable("dbo.SalesOrders");
        }
    }
}
