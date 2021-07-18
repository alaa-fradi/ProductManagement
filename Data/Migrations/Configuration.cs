namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Domaine.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.GestionProduitsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Data.GestionProduitsContext";
        }

        protected override void Seed(Data.GestionProduitsContext context)
        {
            context.Categories.AddOrUpdate(
                p => p.name, //Uniqueness property
                new Categories { name = "Medicament" },
                new Categories { name = "Vetement" },
                new Categories { name = "Meuble" }
                );
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }

      

    }
}
