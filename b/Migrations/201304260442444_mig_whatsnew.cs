namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_whatsnew : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SalesOrderItems", "SalesOrder_ID", "dbo.SalesOrders");
            DropIndex("dbo.SalesOrderItems", new[] { "SalesOrder_ID" });
            CreateTable(
                "dbo.whatsnews",
                c => new
                    {
                        WorkTime = c.DateTime(nullable: false),
                        Work = c.String(),
                    })
                .PrimaryKey(t => t.WorkTime);

            AddColumn("dbo.SalesOrders", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropTable("dbo.SalesOrderItems");
        }

        public override void Down()
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
                .PrimaryKey(t => t.ID);

            DropColumn("dbo.SalesOrders", "TotalAmount");
            DropTable("dbo.whatsnews");
            CreateIndex("dbo.SalesOrderItems", "SalesOrder_ID");
            AddForeignKey("dbo.SalesOrderItems", "SalesOrder_ID", "dbo.SalesOrders", "ID");
        }
    }
}
