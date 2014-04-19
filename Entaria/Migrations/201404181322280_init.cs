namespace Entaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        LastLoginDate = c.DateTime(nullable: false),
                        FailedLoginCount = c.Int(nullable: false),
                        LoginFailureContactNotification = c.String(),
                        CreationDateTime = c.DateTime(nullable: false),
                        ModificationDateTime = c.DateTime(nullable: false),
                        LastModifiedByUserName = c.String(),
                        CreatedByUserName = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        LoyaltyCardHolderId = c.Int(nullable: false),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.CardId);
            
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
            
            CreateTable(
                "dbo.ClientCardBalances",
                c => new
                    {
                        ClientCardBalanceId = c.Int(nullable: false, identity: true),
                        CardId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        PointsBalance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientCardBalanceId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        ReaderId = c.Int(nullable: false),
                        CardId = c.Int(nullable: false),
                        ReceiptNumber = c.String(),
                        TransactionTypeId = c.Int(nullable: false),
                        TransactionTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId);
            
            CreateTable(
                "dbo.TransactionTypes",
                c => new
                    {
                        TransactionTypeId = c.Int(nullable: false, identity: true),
                        TransactionTypeName = c.String(),
                    })
                .PrimaryKey(t => t.TransactionTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.Transactions");
            DropTable("dbo.ClientCardBalances");
            DropTable("dbo.Locations");
            DropTable("dbo.Clients");
            DropTable("dbo.LoyaltyCardHolders");
            DropTable("dbo.Readers");
            DropTable("dbo.Cards");
            DropTable("dbo.Admins");
        }
    }
}
