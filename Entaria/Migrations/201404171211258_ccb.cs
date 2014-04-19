namespace Entaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ccb : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClientCardBalances");
        }
    }
}
