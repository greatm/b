namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_start : DbMigration
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
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
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
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Name = c.String(nullable: false),
                        Category = c.String(),
                        Description = c.String(),
                        UoM = c.String(),
                        RoL = c.Int(nullable: false),
                        RoQ = c.Int(nullable: false),
                        LastPurchaseRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Color = c.String(),
                        Image = c.Binary(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Company = c.String(),
                        Active = c.Boolean(nullable: false),
                        ServiceLevel = c.Int(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Date = c.DateTime(nullable: false),
                        VendorID = c.Int(nullable: false),
                        StoreID = c.Int(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Vendors", t => t.VendorID, cascadeDelete: true)
                .Index(t => t.VendorID);

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
                        PurchaseOrder_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrder_ID)
                .Index(t => t.ProductID)
                .Index(t => t.PurchaseOrder_ID);

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
                "dbo.Sales",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Date = c.DateTime(nullable: false),
                        SOID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
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

            CreateTable(
                "dbo.Sublocations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Store = c.String(),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropIndex("dbo.SalesItems", new[] { "Sales_ID" });
            DropIndex("dbo.POItems", new[] { "PurchaseOrder_ID" });
            DropIndex("dbo.POItems", new[] { "ProductID" });
            DropIndex("dbo.PurchaseOrders", new[] { "VendorID" });
            DropForeignKey("dbo.SalesItems", "Sales_ID", "dbo.Sales");
            DropForeignKey("dbo.POItems", "PurchaseOrder_ID", "dbo.PurchaseOrders");
            DropForeignKey("dbo.POItems", "ProductID", "dbo.Products");
            DropForeignKey("dbo.PurchaseOrders", "VendorID", "dbo.Vendors");
            DropTable("dbo.Sublocations");
            DropTable("dbo.SalesItems");
            DropTable("dbo.Sales");
            DropTable("dbo.SalesOrders");
            DropTable("dbo.Purchases");
            DropTable("dbo.POItems");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.Customers");
            DropTable("dbo.Stores");
            DropTable("dbo.Products");
            DropTable("dbo.Vendors");
            DropTable("dbo.whatsnews");
            DropTable("dbo.UserProfile");
        }
    }
}
