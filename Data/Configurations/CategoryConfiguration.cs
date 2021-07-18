using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domaine.Entities;

namespace Data.Configurations
{
    public class CategoryConfiguration:EntityTypeConfiguration<Categories>
    {
        public CategoryConfiguration()
        {
            this.ToTable("MyCategory");
            this.HasKey(c => c.categoryId);
            this.Property(c => c.name).HasMaxLength(50).IsRequired();


        }
    }
}
