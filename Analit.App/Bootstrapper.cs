using Analit.Common;
using Microsoft.Practices.Unity;

namespace Analit.App
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            ModuleLoader.LoadContainer(container, ".\\", "Analit.*.dll");

            return container;
        }
    }
}