namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_sales_box : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "BoxNumber", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Sales", "BoxNumber");
        }
    }
}
