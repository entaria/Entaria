namespace Entaria.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Entaria.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Entaria.Models.EntariaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Entaria.Models.EntariaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Admins.AddOrUpdate(
                p => p.UserName,
                new Admin { Title     = "Mr",
                            FirstName = "Hugh",
                            LastName  = "Kelly",
                            UserName  = "hkelly",
                            Password  = "a123456#",
                            LastLoginDate = DateTime.Now,
                            CreationDateTime = DateTime.Now,
                            ModificationDateTime = DateTime.Now,
                },
                new Admin { Title     = "Mr",
                            FirstName = "Adrian",
                            LastName  = "Mann",
                            UserName  = "amann",
                            Password  = "a123456#",
                            LastLoginDate = DateTime.Now,
                            CreationDateTime = DateTime.Now,
                            ModificationDateTime = DateTime.Now,
                },
                new Admin { Title     = "Mr",
                            FirstName = "Brendan",
                            LastName  = "O'Brien",
                            UserName  = "bobrien",
                            Password  = "a123456#",
                            LastLoginDate = DateTime.Now,
                            CreationDateTime = DateTime.Now,
                            ModificationDateTime = DateTime.Now,
                },
                new Admin { Title     = "Mr",
                            FirstName = "Fran",
                            LastName  = "Rodgers",
                            UserName  = "frodgers",
                            Password  = "a123456#",
                            LastLoginDate = DateTime.Now,
                            CreationDateTime = DateTime.Now,
                            ModificationDateTime = DateTime.Now,
                }
                
                

                
           );
     
        }
    }
}
