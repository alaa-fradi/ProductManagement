using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using Domaine.Entities;
using Data.Configurations;
using Data.CustomConvention;

namespace Data 
{
    public class GestionProduitsContext : DbContext
    {
        public GestionProduitsContext(): base("name=GestionProduitsCtx")
        {
            Database.SetInitializer<GestionProduitsContext>(new GestionProduitsContextInitialize());
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Provider> Provider { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Facture> Factures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new AdressConfiguration());
            modelBuilder.Conventions.Add(new DataTime2Convention());
        }
    }

}
