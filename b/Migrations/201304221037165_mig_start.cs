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
                "dbo.Vendors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
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
                        Name = c.String(),
                        Category = c.String(),
                        Description = c.String(),
                        UoM = c.String(),
                        RoL = c.String(),
                        RoQ = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        VendorID = c.Int(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID);

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
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.Products");
            DropTable("dbo.Vendors");
            DropTable("dbo.UserProfile");
        }
    }
}
