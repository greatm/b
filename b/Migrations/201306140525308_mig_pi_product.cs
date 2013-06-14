namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_pi_product : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseItems", "Product_ID", c => c.Int());
            AddColumn("dbo.PurchaseItems", "Product_Version", c => c.Int());
            AddForeignKey("dbo.PurchaseItems", new[] { "Product_ID", "Product_Version" }, "dbo.Products", new[] { "ID", "Version" });
            CreateIndex("dbo.PurchaseItems", new[] { "Product_ID", "Product_Version" });
        }

        public override void Down()
        {
            DropIndex("dbo.PurchaseItems", new[] { "Product_ID", "Product_Version" });
            DropForeignKey("dbo.PurchaseItems", new[] { "Product_ID", "Product_Version" }, "dbo.Products");
            DropColumn("dbo.PurchaseItems", "Product_Version");
            DropColumn("dbo.PurchaseItems", "Product_ID");
        }
    }
}
