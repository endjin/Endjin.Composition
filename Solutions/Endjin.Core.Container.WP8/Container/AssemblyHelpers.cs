namespace Endjin.Core.Container
{
    #region Using statements

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    #endregion

    public class AssemblyHelpers
    {
        public static IEnumerable<Assembly> GetAssemblyList()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            return currentDomain.GetAssemblies();
        }        
    }
}