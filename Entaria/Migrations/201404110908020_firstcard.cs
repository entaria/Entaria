namespace Entaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstcard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        LoyaltyCardHolderId = c.Int(nullable: false),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.CardId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cards");
        }
    }
}
