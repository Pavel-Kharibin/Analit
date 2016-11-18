using System.Data.Entity.ModelConfiguration;
using Analit.Common.Models;

namespace Analit.Data.Configuration
{
    internal sealed class OrderProductConfiguration : EntityTypeConfiguration<OrderProduct>
    {
        public OrderProductConfiguration()
        {
            ToTable("OrderProducts");
            HasKey(p => new {p.OrderId, p.ProductId});
            Property(p => p.OrderId).HasColumnName("OrderID");
            Property(p => p.ProductId).HasColumnName("ProductID");
            Property(p => p.Count).HasColumnName("Count");
        }
    }
}