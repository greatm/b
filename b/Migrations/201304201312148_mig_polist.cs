namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_polist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.POItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseOrder_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrder_ID)
                .Index(t => t.PurchaseOrder_ID);

        }

        public override void Down()
        {
            DropIndex("dbo.POItems", new[] { "PurchaseOrder_ID" });
            DropForeignKey("dbo.POItems", "PurchaseOrder_ID", "dbo.PurchaseOrders");
            DropTable("dbo.POItems");
        }
    }
}
