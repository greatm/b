namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_subloaction_store : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sublocations", "StoreID", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Sublocations", "StoreID");
        }
    }
}
