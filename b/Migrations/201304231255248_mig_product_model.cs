namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_product_model : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "RoL", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "RoQ", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "RoQ", c => c.String());
            AlterColumn("dbo.Products", "RoL", c => c.String());
        }
    }
}
