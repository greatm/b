namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);

            CreateTable(
                "dbo.whatsnews",
                c => new
                    {
                        WorkTime = c.DateTime(nullable: false),
                        Work = c.String(),
                    })
                .PrimaryKey(t => t.WorkTime);

            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Name = c.String(),
                        Person = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Mobile = c.String(),
                        Phone = c.String(),
                        eMail = c.String(),
                        WebSite = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.Version });

            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Category = c.String(),
                        Description = c.String(),
                        UoM = c.String(),
                        RoL = c.Int(nullable: false),
                        RoQ = c.Int(nullable: false),
                        LastPurchaseRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Color = c.String(),
                        Image = c.Binary(),
                        EntryDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.Version });

            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.Version });

            CreateTable(
                "dbo.Sublocations",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        StoreID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        Store_ID = c.Int(),
                        Store_Version = c.Int(),
                    })
                .PrimaryKey(t => new { t.ID, t.Version })
                .ForeignKey("dbo.Stores", t => new { t.Store_ID, t.Store_Version })
                .Index(t => new { t.Store_ID, t.Store_Version });

            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Company = c.String(),
                        Active = c.Boolean(nullable: false),
                        ServiceLevel = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.Version });

            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        VendorID = c.Int(nullable: false),
                        StoreID = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        Vendor_ID = c.Int(),
                        Vendor_Version = c.Int(),
                    })
                .PrimaryKey(t => new { t.ID, t.Version })
                .ForeignKey("dbo.Vendors", t => new { t.Vendor_ID, t.Vendor_Version })
                .Index(t => new { t.Vendor_ID, t.Vendor_Version });

            CreateTable(
                "dbo.POItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ProductID = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_ID = c.Int(),
                        Product_Version = c.Int(),
                        PurchaseOrder_ID = c.Int(),
                        PurchaseOrder_Version = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => new { t.Product_ID, t.Product_Version })
                .ForeignKey("dbo.PurchaseOrders", t => new { t.PurchaseOrder_ID, t.PurchaseOrder_Version })
                .Index(t => new { t.Product_ID, t.Product_Version })
                .Index(t => new { t.PurchaseOrder_ID, t.PurchaseOrder_Version });

            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Date = c.DateTime(nullable: false),
                        POID = c.Int(nullable: false),
                        VendorID = c.Int(nullable: false),
                        VendorInvoice = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.SalesOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Date = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Remarks = c.String(maxLength: 5),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.SalesOrderItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ProductID = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesOrder_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SalesOrders", t => t.SalesOrder_ID)
                .Index(t => t.SalesOrder_ID);

            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Date = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        SOID = c.Int(nullable: false),
                        Invoice = c.String(),
                        Remarks = c.String(),
                        PackingList_Item = c.String(),
                        PackingList_Code = c.String(),
                        PackingList_Description = c.String(),
                        PackingList_CaseFrom = c.Int(nullable: false),
                        PackingList_CaseTo = c.Int(nullable: false),
                        PackingList_QtyPerCase = c.Int(nullable: false),
                        PackingList_TotalQty = c.Int(nullable: false),
                        BoxNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.SalesItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ProductID = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sales_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sales", t => t.Sales_ID)
                .Index(t => t.Sales_ID);

        }

        public override void Down()
        {
            DropIndex("dbo.SalesItems", new[] { "Sales_ID" });
            DropIndex("dbo.SalesOrderItems", new[] { "SalesOrder_ID" });
            DropIndex("dbo.POItems", new[] { "PurchaseOrder_ID", "PurchaseOrder_Version" });
            DropIndex("dbo.POItems", new[] { "Product_ID", "Product_Version" });
            DropIndex("dbo.PurchaseOrders", new[] { "Vendor_ID", "Vendor_Version" });
            DropIndex("dbo.Sublocations", new[] { "Store_ID", "Store_Version" });
            DropForeignKey("dbo.SalesItems", "Sales_ID", "dbo.Sales");
            DropForeignKey("dbo.SalesOrderItems", "SalesOrder_ID", "dbo.SalesOrders");
            DropForeignKey("dbo.POItems", new[] { "PurchaseOrder_ID", "PurchaseOrder_Version" }, "dbo.PurchaseOrders");
            DropForeignKey("dbo.POItems", new[] { "Product_ID", "Product_Version" }, "dbo.Products");
            DropForeignKey("dbo.PurchaseOrders", new[] { "Vendor_ID", "Vendor_Version" }, "dbo.Vendors");
            DropForeignKey("dbo.Sublocations", new[] { "Store_ID", "Store_Version" }, "dbo.Stores");
            DropTable("dbo.SalesItems");
            DropTable("dbo.Sales");
            DropTable("dbo.SalesOrderItems");
            DropTable("dbo.SalesOrders");
            DropTable("dbo.Purchases");
            DropTable("dbo.POItems");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.Customers");
            DropTable("dbo.Sublocations");
            DropTable("dbo.Stores");
            DropTable("dbo.Products");
            DropTable("dbo.Vendors");
            DropTable("dbo.whatsnews");
            DropTable("dbo.UserProfile");
        }
    }
}
