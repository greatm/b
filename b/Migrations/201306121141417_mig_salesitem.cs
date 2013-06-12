namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_salesitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesItems", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.SalesItems", "Timestamp");
        }

        public override void Down()
        {
            AddColumn("dbo.SalesItems", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            DropColumn("dbo.SalesItems", "Amount");
        }
    }
}
