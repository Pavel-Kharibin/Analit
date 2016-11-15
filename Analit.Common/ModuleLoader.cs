using System;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;
using Analit.Common.Interfaces;
using Microsoft.Practices.Unity;

namespace Analit.Common
{
    public static class ModuleLoader
    {
        public static void LoadContainer(IUnityContainer container, string path, string pattern)
        {
            var directoryCatalog = new DirectoryCatalog(path, pattern);
            var importDefinition = BuildImportDefinition();

            try
            {
                using (var aggregateCatalog = new AggregateCatalog())
                {
                    aggregateCatalog.Catalogs.Add(directoryCatalog);

                    using (var componsitionContainer = new CompositionContainer(aggregateCatalog))
                    {
                        var exports = componsitionContainer.GetExports(importDefinition);

                        var modules = exports.Select(export => export.Value as IModule).Where(m => m != null);

                        var registrar = new ModuleRegistrar(container);
                        foreach (var module in modules)
                        {
                            module.Initialize(registrar);
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                var builder = new StringBuilder();
                foreach (var loaderException in ex.LoaderExceptions)
                {
                    builder.AppendFormat("{0}\n", loaderException.Message);
                }

                throw new TypeLoadException(builder.ToString(), ex);
            }
        }

        private static ImportDefinition BuildImportDefinition()
        {
            return new ImportDefinition(def => true, typeof (IModule).FullName, ImportCardinality.ZeroOrMore, false, false);
        }
    }
}