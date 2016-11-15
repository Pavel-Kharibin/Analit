using Analit.Data.Contract;
using Analit.Service.Contract;

namespace Analit.Service
{
    public partial class AnalitService : IAnalitService
    {
        public AnalitService(IProductsRepository productsRepository, IOrdersRepository ordersRepository)
        {
            _productsRepository = productsRepository;
            _ordersRepository = ordersRepository;
        }

        private readonly IProductsRepository _productsRepository;
        private readonly IOrdersRepository _ordersRepository;
    }
}