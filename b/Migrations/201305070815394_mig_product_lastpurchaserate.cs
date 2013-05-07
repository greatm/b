namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_product_lastpurchaserate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "LastPurchaseRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }

        public override void Down()
        {
            DropColumn("dbo.Products", "LastPurchaseRate");
        }
    }
}
