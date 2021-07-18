using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configurations
{
    public class AdressConfiguration:ComplexTypeConfiguration<Adresse>
    {
        public AdressConfiguration()
        {
            this.Property(p => p.StreetAddress).HasMaxLength(50).IsOptional();
            this.Property(p => p.City).IsRequired();
        }
    }
}
