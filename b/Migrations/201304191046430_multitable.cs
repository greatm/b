namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class multitable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseOrders", "Vendor_ID", "dbo.Vendors");
            DropIndex("dbo.PurchaseOrders", new[] { "Vendor_ID" });
            AddColumn("dbo.PurchaseOrders", "VendorID", c => c.Int(nullable: false));
            DropColumn("dbo.PurchaseOrders", "Vendor_ID");
        }

        public override void Down()
        {
            AddColumn("dbo.PurchaseOrders", "Vendor_ID", c => c.Int());
            DropColumn("dbo.PurchaseOrders", "VendorID");
            CreateIndex("dbo.PurchaseOrders", "Vendor_ID");
            AddForeignKey("dbo.PurchaseOrders", "Vendor_ID", "dbo.Vendors", "ID");
        }
    }
}
