using System.Linq;
using System.Threading.Tasks;
using Analit.Common.Models;
using Analit.Data.Bases;
using Analit.Data.Contract;

namespace Analit.Data.Repository
{
    public class OrdersRepository : RepositoryBase<Order>, IOrdersRepository
    {
        public override async Task<Order> AddAsync(Order entity)
        {
            using (var tr = DataContext.Database.BeginTransaction())
            {
                var productsIds = entity.OrderProducts.Select(p => p.ProductId).ToArray();

                var productsDbSet = DataContext.Set<Product>();

                var products = (from product in productsDbSet
                    where productsIds.Contains(product.Id)
                    select product).ToList();

                DbSet.Add(entity);

                foreach (var orderProduct in entity.OrderProducts)
                {
                    var product = products.First(p => p.Id == orderProduct.ProductId);
                    product.Residue -= orderProduct.Count;
                }

                await DataContext.SaveChangesAsync();

                tr.Commit();

                return entity;
            }
        }
    }
}