namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_po_store : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseOrders", "StoreID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseOrders", "StoreID");
        }
    }
}
