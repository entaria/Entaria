using System.Data.Entity;

namespace Entaria.Models
{
    public class EntariaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Entaria.Models.EntariaContext>());

        public EntariaContext() : base("name=EntariaContext")
        {
        }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Reader> Readers { get; set; }

        public DbSet<LoyaltyCardHolder> LoyaltyCardHolders { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<ClientCardBalance> ClientCardBalances { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<TransactionType> TransactionTypes { get; set; }
    }
}
