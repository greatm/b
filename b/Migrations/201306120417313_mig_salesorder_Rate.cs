namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_salesorder_Rate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesOrderItems", "Rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.SalesOrderItems", "Price");
        }

        public override void Down()
        {
            AddColumn("dbo.SalesOrderItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.SalesOrderItems", "Rate");
        }
    }
}
