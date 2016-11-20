using System.Data.Entity.ModelConfiguration;
using Analit.Common.Models;

namespace Analit.Data.Configuration
{
    internal sealed class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("Orders");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("ID");
            Property(p => p.Created).HasColumnName("Created");
            Property(p => p.Status).HasColumnName("Status");

            //HasRequired(p => p.OrderProducts);
        }
    }
}