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

        public void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            if (withInterception)
            {
                //register with interception 
            }
            else
            {
                _container.RegisterType<TFrom, TTo>();
            }
        }
    }
}