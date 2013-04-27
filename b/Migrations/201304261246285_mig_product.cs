namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_product : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Color", c => c.String());
            AddColumn("dbo.Products", "Picture", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Products", "Picture");
            DropColumn("dbo.Products", "Color");
        }
    }
}
