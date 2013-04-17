namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class po : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        Vendor_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Vendors", t => t.Vendor_ID)
                .Index(t => t.Vendor_ID);

        }

        public override void Down()
        {
            DropIndex("dbo.PurchaseOrders", new[] { "Vendor_ID" });
            DropForeignKey("dbo.PurchaseOrders", "Vendor_ID", "dbo.Vendors");
            DropTable("dbo.PurchaseOrders");
        }
    }
}
