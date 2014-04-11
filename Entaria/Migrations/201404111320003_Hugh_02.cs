namespace Entaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hugh_02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        Street = c.String(),
                        Town = c.String(),
                        City = c.String(),
                        County = c.String(),
                        Country = c.String(),
                        GeoCode = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        CreationDateTime = c.DateTime(nullable: false),
                        ModificationDateTime = c.DateTime(nullable: false),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Locations");
        }
    }
}
