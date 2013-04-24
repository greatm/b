namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_saleschange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
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
            DropForeignKey("dbo.SalesItems", "Sales_ID", "dbo.Sales");
            DropTable("dbo.SalesItems");
        }
    }
}
