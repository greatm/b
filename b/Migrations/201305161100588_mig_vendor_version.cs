namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_vendor_version : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseOrders", "VendorID", "dbo.Vendors");
            DropIndex("dbo.PurchaseOrders", new[] { "VendorID" });
            RenameColumn(table: "dbo.PurchaseOrders", name: "VendorID", newName: "Vendor_ID");
            AddColumn("dbo.Vendors", "Version", c => c.Int(nullable: false));
            AddColumn("dbo.PurchaseOrders", "Vendor_Version", c => c.Int());
            AlterColumn("dbo.Vendors", "ID", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Vendors", new[] { "ID" });
            AddPrimaryKey("dbo.Vendors", new[] { "ID", "Version" });
            AddForeignKey("dbo.PurchaseOrders", new[] { "Vendor_ID", "Vendor_Version" }, "dbo.Vendors", new[] { "ID", "Version" });
            CreateIndex("dbo.PurchaseOrders", new[] { "Vendor_ID", "Vendor_Version" });
        }

        public override void Down()
        {
            DropIndex("dbo.PurchaseOrders", new[] { "Vendor_ID", "Vendor_Version" });
            DropForeignKey("dbo.PurchaseOrders", new[] { "Vendor_ID", "Vendor_Version" }, "dbo.Vendors");
            DropPrimaryKey("dbo.Vendors", new[] { "ID", "Version" });
            AddPrimaryKey("dbo.Vendors", "ID");
            AlterColumn("dbo.Vendors", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.PurchaseOrders", "Vendor_Version");
            DropColumn("dbo.Vendors", "Version");
            RenameColumn(table: "dbo.PurchaseOrders", name: "Vendor_ID", newName: "VendorID");
            CreateIndex("dbo.PurchaseOrders", "VendorID");
            AddForeignKey("dbo.PurchaseOrders", "VendorID", "dbo.Vendors", "ID", cascadeDelete: true);
        }
    }
}
