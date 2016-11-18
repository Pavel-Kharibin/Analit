using System.Data.Entity;
using Analit.Data.Configuration;

namespace Analit.Data
{
    public class AnalitDataContext : DbContext
    {
        public AnalitDataContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<AnalitDataContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderProductConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}