namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_timestamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendors", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Products", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Stores", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Customers", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.PurchaseOrders", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.POItems", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Purchases", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.SalesOrders", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Sales", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            //AddColumn("dbo.Sales", "PackingList_Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.SalesItems", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }

        public override void Down()
        {
            DropColumn("dbo.SalesItems", "Timestamp");
            //DropColumn("dbo.Sales", "PackingList_Timestamp");
            DropColumn("dbo.Sales", "Timestamp");
            DropColumn("dbo.SalesOrders", "Timestamp");
            DropColumn("dbo.Purchases", "Timestamp");
            DropColumn("dbo.POItems", "Timestamp");
            DropColumn("dbo.PurchaseOrders", "Timestamp");
            DropColumn("dbo.Customers", "Timestamp");
            DropColumn("dbo.Stores", "Timestamp");
            DropColumn("dbo.Products", "Timestamp");
            DropColumn("dbo.Vendors", "Timestamp");
        }
    }
}
