namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_purchase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        POID = c.Int(nullable: false),
                        VendorID = c.Int(nullable: false),
                        VendorInvoice = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropTable("dbo.Purchases");
        }
    }
}
