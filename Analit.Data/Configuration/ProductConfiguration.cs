using System.Data.Entity.ModelConfiguration;
using Analit.Common.Models;

namespace Analit.Data.Configuration
{
    internal sealed class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Products");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("ID");
            Property(p => p.Name).HasColumnName("Name");
            Property(p => p.Price).HasColumnName("Price");
            Property(p => p.Residue).HasColumnName("Residue");
        }
    }
}