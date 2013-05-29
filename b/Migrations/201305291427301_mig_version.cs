namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_version : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SalesOrderItems", "SalesOrder_ID", "dbo.SalesOrders");
            DropForeignKey("dbo.SalesItems", "Sales_ID", "dbo.Sales");
            DropIndex("dbo.SalesOrderItems", new[] { "SalesOrder_ID" });
            DropIndex("dbo.SalesItems", new[] { "Sales_ID" });
            AddColumn("dbo.Purchases", "Version", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "EntryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SalesOrders", "Version", c => c.Int(nullable: false));
            AddColumn("dbo.SalesOrders", "EntryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SalesOrderItems", "SalesOrder_Version", c => c.Int());
            AddColumn("dbo.Sales", "Version", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "EntryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SalesItems", "Sales_Version", c => c.Int());
            AlterColumn("dbo.Purchases", "ID", c => c.Int(nullable: false));
            AlterColumn("dbo.SalesOrders", "ID", c => c.Int(nullable: false));
            AlterColumn("dbo.SalesOrders", "Remarks", c => c.String());
            AlterColumn("dbo.Sales", "ID", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Purchases", new[] { "ID" });
            AddPrimaryKey("dbo.Purchases", new[] { "ID", "Version" });
            DropPrimaryKey("dbo.SalesOrders", new[] { "ID" });
            AddPrimaryKey("dbo.SalesOrders", new[] { "ID", "Version" });
            DropPrimaryKey("dbo.Sales", new[] { "ID" });
            AddPrimaryKey("dbo.Sales", new[] { "ID", "Version" });
            AddForeignKey("dbo.SalesOrderItems", new[] { "SalesOrder_ID", "SalesOrder_Version" }, "dbo.SalesOrders", new[] { "ID", "Version" });
            AddForeignKey("dbo.SalesItems", new[] { "Sales_ID", "Sales_Version" }, "dbo.Sales", new[] { "ID", "Version" });
            CreateIndex("dbo.SalesOrderItems", new[] { "SalesOrder_ID", "SalesOrder_Version" });
            CreateIndex("dbo.SalesItems", new[] { "Sales_ID", "Sales_Version" });
            DropColumn("dbo.Purchases", "Timestamp");
            DropColumn("dbo.SalesOrders", "Timestamp");
            DropColumn("dbo.Sales", "Timestamp");
        }

        public override void Down()
        {
            AddColumn("dbo.Sales", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.SalesOrders", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Purchases", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            DropIndex("dbo.SalesItems", new[] { "Sales_ID", "Sales_Version" });
            DropIndex("dbo.SalesOrderItems", new[] { "SalesOrder_ID", "SalesOrder_Version" });
            DropForeignKey("dbo.SalesItems", new[] { "Sales_ID", "Sales_Version" }, "dbo.Sales");
            DropForeignKey("dbo.SalesOrderItems", new[] { "SalesOrder_ID", "SalesOrder_Version" }, "dbo.SalesOrders");
            DropPrimaryKey("dbo.Sales", new[] { "ID", "Version" });
            AddPrimaryKey("dbo.Sales", "ID");
            DropPrimaryKey("dbo.SalesOrders", new[] { "ID", "Version" });
            AddPrimaryKey("dbo.SalesOrders", "ID");
            DropPrimaryKey("dbo.Purchases", new[] { "ID", "Version" });
            AddPrimaryKey("dbo.Purchases", "ID");
            AlterColumn("dbo.Sales", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.SalesOrders", "Remarks", c => c.String(maxLength: 5));
            AlterColumn("dbo.SalesOrders", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Purchases", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.SalesItems", "Sales_Version");
            DropColumn("dbo.Sales", "EntryDate");
            DropColumn("dbo.Sales", "Version");
            DropColumn("dbo.SalesOrderItems", "SalesOrder_Version");
            DropColumn("dbo.SalesOrders", "EntryDate");
            DropColumn("dbo.SalesOrders", "Version");
            DropColumn("dbo.Purchases", "EntryDate");
            DropColumn("dbo.Purchases", "Version");
            CreateIndex("dbo.SalesItems", "Sales_ID");
            CreateIndex("dbo.SalesOrderItems", "SalesOrder_ID");
            AddForeignKey("dbo.SalesItems", "Sales_ID", "dbo.Sales", "ID");
            AddForeignKey("dbo.SalesOrderItems", "SalesOrder_ID", "dbo.SalesOrders", "ID");
        }
    }
}
