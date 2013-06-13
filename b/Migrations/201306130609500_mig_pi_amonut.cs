namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_pi_amonut : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseItems", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }

        public override void Down()
        {
            DropColumn("dbo.PurchaseItems", "Amount");
        }
    }
}
