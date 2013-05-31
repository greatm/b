namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_purchase_c1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "PO_ID", c => c.Int());
            AddColumn("dbo.Purchases", "PO_Version", c => c.Int());
            AddForeignKey("dbo.Purchases", new[] { "PO_ID", "PO_Version" }, "dbo.PurchaseOrders", new[] { "ID", "Version" });
            CreateIndex("dbo.Purchases", new[] { "PO_ID", "PO_Version" });
            DropColumn("dbo.Purchases", "VendorID");
        }

        public override void Down()
        {
            AddColumn("dbo.Purchases", "VendorID", c => c.Int(nullable: false));
            DropIndex("dbo.Purchases", new[] { "PO_ID", "PO_Version" });
            DropForeignKey("dbo.Purchases", new[] { "PO_ID", "PO_Version" }, "dbo.PurchaseOrders");
            DropColumn("dbo.Purchases", "PO_Version");
            DropColumn("dbo.Purchases", "PO_ID");
        }
    }
}
