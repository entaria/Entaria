namespace Entaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reader : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        ReaderId = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        HardwareIdentifier = c.String(),
                        AttachedToNote = c.String(),
                    })
                .PrimaryKey(t => t.ReaderId);
            
            CreateTable(
                "dbo.LoyaltyCardHolders",
                c => new
                    {
                        LoyaltyCardHolderId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Street = c.String(),
                        Town = c.String(),
                        City = c.String(),
                        County = c.String(),
                        Country = c.String(),
                        GeoCode = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Gender = c.String(),
                        Password = c.String(),
                        LastLoginDate = c.DateTime(nullable: false),
                        FailedLoginCount = c.Int(nullable: false),
                        LoginFailureContactNotification = c.String(),
                        CreationDateTime = c.DateTime(nullable: false),
                        ModificationDateTime = c.DateTime(nullable: false),
                        LastModifiedByUserName = c.String(),
                        CreatedByUserName = c.String(),
                    })
                .PrimaryKey(t => t.LoyaltyCardHolderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoyaltyCardHolders");
            DropTable("dbo.Readers");
        }
    }
}
