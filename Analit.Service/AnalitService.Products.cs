using System.Collections.Generic;
using System.Threading.Tasks;
using Analit.Common.Models;

namespace Analit.Service
{
    public partial class AnalitService
    {
        public async Task<Product> ProductGetByIdAsync(int id)
        {
            return await _productsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> ProductsGetAllAsync()
        {
            return await _productsRepository.GetAllAsync();
        }

        public async Task<Product> ProductAddAsync(Product product)
        {
            return await _productsRepository.AddAsync(product);
        }

        public async Task<Product> ProductUpdateAsync(Product product)
        {
            return await _productsRepository.UpdateAsync(product);
        }

        public async Task ProductDeleteAsync(int id)
        {
            await _productsRepository.DeleteAsync(id);
        }
    }
}