namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_storetransfer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreTransfers",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        FromStoreID = c.Int(nullable: false),
                        ToStoreID = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.Version });

            CreateTable(
                "dbo.StoreTransferItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_ID = c.Int(),
                        Product_Version = c.Int(),
                        StoreTransfer_ID = c.Int(),
                        StoreTransfer_Version = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => new { t.Product_ID, t.Product_Version })
                .ForeignKey("dbo.StoreTransfers", t => new { t.StoreTransfer_ID, t.StoreTransfer_Version })
                .Index(t => new { t.Product_ID, t.Product_Version })
                .Index(t => new { t.StoreTransfer_ID, t.StoreTransfer_Version });

        }

        public override void Down()
        {
            DropIndex("dbo.StoreTransferItems", new[] { "StoreTransfer_ID", "StoreTransfer_Version" });
            DropIndex("dbo.StoreTransferItems", new[] { "Product_ID", "Product_Version" });
            DropForeignKey("dbo.StoreTransferItems", new[] { "StoreTransfer_ID", "StoreTransfer_Version" }, "dbo.StoreTransfers");
            DropForeignKey("dbo.StoreTransferItems", new[] { "Product_ID", "Product_Version" }, "dbo.Products");
            DropTable("dbo.StoreTransferItems");
            DropTable("dbo.StoreTransfers");
        }
    }
}
