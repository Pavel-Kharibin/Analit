using System.ComponentModel.Composition;
using Analit.Common.Interfaces;
using Analit.Data.Contract;
using Analit.Data.Repository;

namespace Analit.Data
{
    [Export(typeof(IModule))]
    public class Module : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.RegisterType<IProductsRepository, ProductsRepository>();
            registrar.RegisterType<IOrdersRepository, OrdersRepository>();
        }
    }
}