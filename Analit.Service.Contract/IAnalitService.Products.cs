using System.Collections.Generic;
using System.Threading.Tasks;
using Analit.Common.Models;

namespace Analit.Service.Contract
{
    public partial interface IAnalitService
    {
        Task<Product> ProductGetByIdAsync(int id);
        Task<IEnumerable<Product>> ProductsGetAllAsync();
        Task<Product> ProductAddAsync(Product product);
        Task<Product> ProductUpdateAsync(Product product);
        Task ProductDeleteAsync(int id);
    }
}