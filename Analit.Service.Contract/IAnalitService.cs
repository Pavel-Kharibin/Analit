using System.Collections.Generic;
using System.Threading.Tasks;
using Analit.Common.Models;

namespace Analit.Service.Contract
{
    public interface IAnalitService
    {
        Task<Product> ProductGetByIdAsync(int id);
        Task<IEnumerable<Product>> ProductsGetAllAsync();
        Task<Product> ProductAddAsync(Product product);
        Task<Product> ProductUpdateAsync(Product product);
        Task ProductDeleteAsync(int id);

        Task<Order> OrderGetByIdAsync(int id);
        Task<IEnumerable<Order>> OrdersGetAllAsync();
        Task<Order> OrderAddAsync(Order order);
        Task<Order> OrderUpdateAsync(Order order);
        Task OrderDeleteAsync(int id);
    }
}