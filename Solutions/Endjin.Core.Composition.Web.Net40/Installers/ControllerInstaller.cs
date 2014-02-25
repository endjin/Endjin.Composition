namespace Endjin.Core.Installers
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Web.Mvc;
    using Endjin.Core.Container;

    #endregion 

    public class ControllerInstaller : IInstaller
    {
        public void Install(IContainer container)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                IEnumerable<Type> controllers = new List<Type>();
                    
                try
                {
                    controllers = assembly.TryGetExportedTypes().Where(x => !(x.IsGenericType && x.ContainsGenericParameters) && !x.IsAbstract && !x.IsInterface && (typeof(IController).IsAssignableFrom(x)));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

                foreach (var current in controllers)
                {
                    container.Register(Component.For(current).Named(current.FullName.ToLowerInvariant()).AsTransient());
                }
            }
        }
    }
}