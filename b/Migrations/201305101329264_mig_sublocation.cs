namespace b.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_sublocation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sublocations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Store = c.String(),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropTable("dbo.Sublocations");
        }
    }
}
