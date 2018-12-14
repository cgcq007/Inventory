namespace InventoryTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InventoryTest.ItemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "InventoryTest.ItemContext";
        }

        protected override void Seed(InventoryTest.ItemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Users.AddOrUpdate(
              u => u.UserName,
              new User { UserName = "admin", UserPwd = "admin", UserType = "admin" }
             // new User { UserName = "service", UserPwd = "service", UserType = "serviceMan" },
              //new User { UserName = "operator", UserPwd = "operator", UserType = "itemOperator" }
            );
            //
        }
    }
}
