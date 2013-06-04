namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_poitems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);

            DropColumn("dbo.POItems", "Timestamp");
        }

        public override void Down()
        {
            AddColumn("dbo.POItems", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            DropTable("dbo.PurchaseItems");
        }
    }
}
