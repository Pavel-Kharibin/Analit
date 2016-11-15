using Analit.Common.Interfaces;
using System.ComponentModel.Composition;
using Analit.Service.Contract;

namespace Analit.Service
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.RegisterType<IAnalitService, AnalitService>();
        }
    }
}