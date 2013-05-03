namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_product_pic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Image", c => c.Binary());
            DropColumn("dbo.Products", "Picture");
        }

        public override void Down()
        {
            AddColumn("dbo.Products", "Picture", c => c.String());
            DropColumn("dbo.Products", "Image");
        }
    }
}
