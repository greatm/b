namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_soitem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesOrderItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesOrder_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SalesOrders", t => t.SalesOrder_ID)
                .Index(t => t.SalesOrder_ID);

        }

        public override void Down()
        {
            DropIndex("dbo.SalesOrderItems", new[] { "SalesOrder_ID" });
            DropForeignKey("dbo.SalesOrderItems", "SalesOrder_ID", "dbo.SalesOrders");
            DropTable("dbo.SalesOrderItems");
        }
    }
}
