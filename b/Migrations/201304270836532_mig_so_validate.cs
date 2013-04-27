namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_so_validate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SalesOrders", "Remarks", c => c.String(maxLength: 5));
        }

        public override void Down()
        {
            AlterColumn("dbo.SalesOrders", "Remarks", c => c.String());
        }
    }
}
