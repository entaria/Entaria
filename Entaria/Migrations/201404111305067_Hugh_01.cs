namespace Entaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hugh_01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        MainContactTitle = c.String(),
                        MainContactName = c.String(),
                        PrimaryStreet = c.String(),
                        PrimaryTown = c.String(),
                        PrimaryCity = c.String(),
                        PrimaryCounty = c.String(),
                        PrimaryCountry = c.String(),
                        PrimaryGeoCode = c.String(),
                        Website = c.String(),
                        PrimaryPhone = c.String(),
                        VatNumber = c.String(),
                        Password = c.String(),
                        LastLoginDate = c.DateTime(nullable: false),
                        FailedLoginCount = c.Int(nullable: false),
                        LoginFailureContactNotification = c.String(),
                        CreationDateTime = c.DateTime(nullable: false),
                        ModificationDateTime = c.DateTime(nullable: false),
                        LastModifiedByUserName = c.String(),
                        CreatedByUserName = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clients");
        }
    }
}
