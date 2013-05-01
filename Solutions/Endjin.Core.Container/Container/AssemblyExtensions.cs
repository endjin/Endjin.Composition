namespace Endjin.Core.Container
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetExportedTypes(this Assembly assembly)
        {
            return assembly.ExportedTypes;
        }
    }
}