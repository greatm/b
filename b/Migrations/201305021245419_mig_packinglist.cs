namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_packinglist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "PackingList_Item", c => c.String());
            AddColumn("dbo.Sales", "PackingList_Code", c => c.String());
            AddColumn("dbo.Sales", "PackingList_Description", c => c.String());
            AddColumn("dbo.Sales", "PackingList_CaseFrom", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "PackingList_CaseTo", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "PackingList_QtyPerCase", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "PackingList_TotalQty", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Sales", "PackingList_TotalQty");
            DropColumn("dbo.Sales", "PackingList_QtyPerCase");
            DropColumn("dbo.Sales", "PackingList_CaseTo");
            DropColumn("dbo.Sales", "PackingList_CaseFrom");
            DropColumn("dbo.Sales", "PackingList_Description");
            DropColumn("dbo.Sales", "PackingList_Code");
            DropColumn("dbo.Sales", "PackingList_Item");
        }
    }
}
