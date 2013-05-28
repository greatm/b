namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_po_version : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.POItems", "PurchaseOrder_ID", "dbo.PurchaseOrders");
            DropIndex("dbo.POItems", new[] { "PurchaseOrder_ID" });
            AddColumn("dbo.Customers", "Version", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "EntryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "Remarks", c => c.String());
            AddColumn("dbo.PurchaseOrders", "Version", c => c.Int(nullable: false));
            AddColumn("dbo.PurchaseOrders", "EntryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.POItems", "PurchaseOrder_Version", c => c.Int());
            AlterColumn("dbo.Customers", "ID", c => c.Int(nullable: false));
            AlterColumn("dbo.PurchaseOrders", "ID", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Customers", new[] { "ID" });
            AddPrimaryKey("dbo.Customers", new[] { "ID", "Version" });
            DropPrimaryKey("dbo.PurchaseOrders", new[] { "ID" });
            AddPrimaryKey("dbo.PurchaseOrders", new[] { "ID", "Version" });
            AddForeignKey("dbo.POItems", new[] { "PurchaseOrder_ID", "PurchaseOrder_Version" }, "dbo.PurchaseOrders", new[] { "ID", "Version" });
            CreateIndex("dbo.POItems", new[] { "PurchaseOrder_ID", "PurchaseOrder_Version" });
            DropColumn("dbo.Customers", "Timestamp");
            DropColumn("dbo.PurchaseOrders", "Timestamp");
        }

        public override void Down()
        {
            AddColumn("dbo.PurchaseOrders", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Customers", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            DropIndex("dbo.POItems", new[] { "PurchaseOrder_ID", "PurchaseOrder_Version" });
            DropForeignKey("dbo.POItems", new[] { "PurchaseOrder_ID", "PurchaseOrder_Version" }, "dbo.PurchaseOrders");
            DropPrimaryKey("dbo.PurchaseOrders", new[] { "ID", "Version" });
            AddPrimaryKey("dbo.PurchaseOrders", "ID");
            DropPrimaryKey("dbo.Customers", new[] { "ID", "Version" });
            AddPrimaryKey("dbo.Customers", "ID");
            AlterColumn("dbo.PurchaseOrders", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Customers", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.POItems", "PurchaseOrder_Version");
            DropColumn("dbo.PurchaseOrders", "EntryDate");
            DropColumn("dbo.PurchaseOrders", "Version");
            DropColumn("dbo.Customers", "Remarks");
            DropColumn("dbo.Customers", "EntryDate");
            DropColumn("dbo.Customers", "Version");
            CreateIndex("dbo.POItems", "PurchaseOrder_ID");
            AddForeignKey("dbo.POItems", "PurchaseOrder_ID", "dbo.PurchaseOrders", "ID");
        }
    }
}
