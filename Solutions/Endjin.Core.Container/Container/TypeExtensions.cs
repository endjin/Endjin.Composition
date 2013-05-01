namespace Endjin.Core.Container
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public static class TypeExtensions
    {
        public static IEnumerable<ConstructorInfo> GetConstructors(this TypeInfo type)
        {
            return type.DeclaredConstructors;
        }

        public static IEnumerable<Type> GetInterfaces(this TypeInfo type)
        {
            return type.ImplementedInterfaces;
        }

    }
}