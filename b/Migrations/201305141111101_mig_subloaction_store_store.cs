namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_subloaction_store_store : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Sublocations", "StoreID", "dbo.Stores", "ID", cascadeDelete: true);
            CreateIndex("dbo.Sublocations", "StoreID");
            DropColumn("dbo.Sublocations", "Store");
        }

        public override void Down()
        {
            AddColumn("dbo.Sublocations", "Store", c => c.String());
            DropIndex("dbo.Sublocations", new[] { "StoreID" });
            DropForeignKey("dbo.Sublocations", "StoreID", "dbo.Stores");
        }
    }
}
