using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configurations
{
    public class ProductConfiguration: EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            this.HasMany<Provider>(pr => pr.Provider)
                .WithMany(p => p.Product)
                .Map(m =>
                {
                    m.MapLeftKey("Product");
                    m.MapRightKey("Provider");
                    m.ToTable("Providing");
                });

            this.HasRequired<Categories>(c => c.categories)
                 .WithMany(p => p.Product)
                 .HasForeignKey(p => p.categoryId)
                 .WillCascadeOnDelete(false);

            this.Map<Biological>(c =>
            {
                c.Requires("IsBiological").HasValue(1); //isBiological is the discriminator
            });
            this.Map<Chemical>(c =>
            {
                c.Requires("IsBiological").HasValue(0); //isBiological is the discriminator
            });

            this.Property(p => p.Description)
                .HasMaxLength(200)
                .IsOptional();

        }
    }
}
