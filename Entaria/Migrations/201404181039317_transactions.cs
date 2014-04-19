namespace Entaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactions : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transactions");
        }
    }
}
