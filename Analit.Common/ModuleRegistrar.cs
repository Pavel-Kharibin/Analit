using Analit.Common.Interfaces;
using Microsoft.Practices.Unity;

namespace Analit.Common
{
    internal class ModuleRegistrar : IModuleRegistrar
    {
        private readonly IUnityContainer _container;

        public ModuleRegistrar(IUnityContainer container)
        {
            _container = container;
        }

        public void RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>();
        }
    }
}