namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_vendor_version : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendors", "EntryDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Vendors", "Timestamp");
        }

        public override void Down()
        {
            AddColumn("dbo.Vendors", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            DropColumn("dbo.Vendors", "EntryDate");
        }
    }
}
