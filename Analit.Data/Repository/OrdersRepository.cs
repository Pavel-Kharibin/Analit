using Analit.Common.Models;
using Analit.Data.Bases;
using Analit.Data.Contract;

namespace Analit.Data.Repository
{
    public class OrdersRepository : RepositoryBase<Order>, IOrdersRepository
    {
    }
}