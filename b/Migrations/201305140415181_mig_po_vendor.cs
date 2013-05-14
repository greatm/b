namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_po_vendor : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.PurchaseOrders", "VendorID", "dbo.Vendors", "ID", cascadeDelete: true);
            CreateIndex("dbo.PurchaseOrders", "VendorID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PurchaseOrders", new[] { "VendorID" });
            DropForeignKey("dbo.PurchaseOrders", "VendorID", "dbo.Vendors");
        }
    }
}
