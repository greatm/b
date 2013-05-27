namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_product_version : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.POItems", "ProductID", "dbo.Products");
            DropIndex("dbo.POItems", new[] { "ProductID" });
            RenameColumn(table: "dbo.POItems", name: "ProductID", newName: "Product_ID");
            AddColumn("dbo.Products", "Version", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "EntryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.POItems", "Product_Version", c => c.Int());
            AlterColumn("dbo.Products", "ID", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Products", new[] { "ID" });
            AddPrimaryKey("dbo.Products", new[] { "ID", "Version" });
            AddForeignKey("dbo.POItems", new[] { "Product_ID", "Product_Version" }, "dbo.Products", new[] { "ID", "Version" });
            CreateIndex("dbo.POItems", new[] { "Product_ID", "Product_Version" });
            DropColumn("dbo.Products", "Timestamp");
        }

        public override void Down()
        {
            AddColumn("dbo.Products", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            DropIndex("dbo.POItems", new[] { "Product_ID", "Product_Version" });
            DropForeignKey("dbo.POItems", new[] { "Product_ID", "Product_Version" }, "dbo.Products");
            DropPrimaryKey("dbo.Products", new[] { "ID", "Version" });
            AddPrimaryKey("dbo.Products", "ID");
            AlterColumn("dbo.Products", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.POItems", "Product_Version");
            DropColumn("dbo.Products", "EntryDate");
            DropColumn("dbo.Products", "Version");
            RenameColumn(table: "dbo.POItems", name: "Product_ID", newName: "ProductID");
            CreateIndex("dbo.POItems", "ProductID");
            AddForeignKey("dbo.POItems", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
        }
    }
}
