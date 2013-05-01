namespace Endjin.Core.Container
{
    #region Using statements

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    #endregion

    public static class InstallerHelpers
    {
        public static Task<IEnumerable<IInstaller>> GetInstallersAsync(IEnumerable<Assembly> assembliesToSearch)
        {
            return Task.Factory.StartNew(
                () =>
                    {
                        var typeInfo = typeof(IInstaller).GetTypeInfo();
                        IEnumerable<IInstaller> installers = new IInstaller[0];

                        return assembliesToSearch.Aggregate(installers, (current, assembly) => current.Union(TryGetExportedTypes(assembly).Where(t =>
                            {
                                var info = t.GetTypeInfo();
                                return info.IsClass && !info.IsAbstract && !info.ContainsGenericParameters && typeInfo.IsAssignableFrom(info) && info.GetConstructors().Any(c => !c.GetParameters().Any());
                            }).Select(CreateInstance).Where(i => i != null)));
                    });
        }

        private static IEnumerable<Type> TryGetExportedTypes(Assembly assembly)
        {
            try
            {
                return assembly.GetExportedTypes();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return new Type[] { };
        }

        private static IInstaller CreateInstance(Type type)
        {
            return (IInstaller)Activator.CreateInstance(type);
        }
    }
}