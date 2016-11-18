using System.Collections.Generic;
using System.Threading.Tasks;
using Analit.Common.Models;

namespace Analit.Service.Contract
{
    public partial interface IAnalitService
    {
        Task<Order> OrderGetByIdAsync(int id);
        Task<IEnumerable<Order>> OrdersGetAllAsync();
        Task<Order> OrderAddAsync(Order order);
        Task<Order> OrderUpdateAsync(Order order);
        Task OrderDeleteAsync(int id);
    }
}