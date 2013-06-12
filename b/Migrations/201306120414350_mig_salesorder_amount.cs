namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_salesorder_amount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesOrderItems", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.SalesOrderItems", "Timestamp");
        }

        public override void Down()
        {
            AddColumn("dbo.SalesOrderItems", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            DropColumn("dbo.SalesOrderItems", "Amount");
        }
    }
}
