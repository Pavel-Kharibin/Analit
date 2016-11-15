using System.Collections.Generic;
using System.Threading.Tasks;
using Analit.Common.Models;

namespace Analit.Service
{
    public partial class AnalitService
    {
        public async Task<Order> OrderGetByIdAsync(int id)
        {
            return await _ordersRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Order>> OrdersGetAllAsync()
        {
            return await _ordersRepository.GetAllAsync();
        }

        public async Task<Order> OrderAddAsync(Order order)
        {
            return await _ordersRepository.AddAsync(order);
        }

        public async Task<Order> OrderUpdateAsync(Order order)
        {
            return await _ordersRepository.UpdateAsync(order);
        }

        public async Task OrderDeleteAsync(int id)
        {
            await _ordersRepository.DeleteAsync(id);
        }
    }
}