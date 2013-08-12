namespace Endjin.Core.Container
{
    #region Using statements

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    #endregion

    public static class ComponentRegistrationExtensions
    {        
        public static IEnumerable<ComponentRegistration> BasedOn<T>(this IEnumerable<ComponentRegistration> types)
        {
            var typeInfo = typeof(T).GetTypeInfo();
            return types.Where(t => typeInfo.IsAssignableFrom(t.ComponentType.GetTypeInfo()));
        }

        public static IEnumerable<ComponentRegistration> WhereNameContains(this IEnumerable<ComponentRegistration> types, string partialName)
        {
            return types.Where(t => t.ComponentType.Name.Contains(partialName));
        }

        public static IEnumerable<ComponentRegistration> WhereNameStartsWith(this IEnumerable<ComponentRegistration> types, string partialName)
        {
            return types.Where(t => t.ComponentType.Name.StartsWith(partialName));
        }

        public static IEnumerable<ComponentRegistration> WhereNameEndsWith(this IEnumerable<ComponentRegistration> types, string partialName)
        {
            return types.Where(t => t.ComponentType.Name.EndsWith(partialName));
        }

        public static IEnumerable<ComponentRegistration> WhereNamespaceContains(this IEnumerable<ComponentRegistration> types, string partialNamespace)
        {
            return types.Where(t => t.ComponentType.Namespace.Contains(partialNamespace));
        }

        public static IEnumerable<ComponentRegistration> WhereHasInterface(this IEnumerable<ComponentRegistration> types)
        {
            return types.Where(t => t.ComponentType.GetTypeInfo().GetInterfaces().Any());
        }

        public static IEnumerable<ComponentRegistration> WhereNamespaceStartsWith(this IEnumerable<ComponentRegistration> types, string partialNamespace)
        {
            return types.Where(t => t.ComponentType.Namespace.StartsWith(partialNamespace));
        }

        public static IEnumerable<ComponentRegistration> WhereNamespaceEndsWith(this IEnumerable<ComponentRegistration> types, string partialNamespace)
        {
            return types.Where(t => t.ComponentType.Namespace.EndsWith(partialNamespace));
        }

        public static IEnumerable<ComponentRegistration> Matching(this IEnumerable<ComponentRegistration> types, Predicate<ComponentRegistration> predicate)
        {
            return types.Where(t => predicate(t));
        }

        public static IEnumerable<ComponentRegistration> For<T>(this IEnumerable<ComponentRegistration> types)
        {
            var componentRegistrations = types as List<ComponentRegistration> ?? types.ToList();
            foreach (var t in componentRegistrations)
            {
                t.Interfaces = Interfaces.SpecificType;
                EnsureRegistrationTypes(t);

                t.RegistrationTypes.Add(typeof(T));
            }

            return componentRegistrations;
        }

        public static IEnumerable<ComponentRegistration> WithService(this IEnumerable<ComponentRegistration> types, Interfaces interfaces)
        {
            var componentRegistrations = types as List<ComponentRegistration> ?? types.ToList();
            foreach (var t in componentRegistrations)
            {
                t.Interfaces = interfaces;
                EnsureRegistrationTypes(t);
                switch (interfaces)
                {
                    case Interfaces.DefaultInterface:
                        var defaultInterface = GetDefaultInterfaceFor(t);
                        if (defaultInterface != null)
                        {
                            t.RegistrationTypes.Add(defaultInterface);
                        }

                        break;
                    case Interfaces.SpecificType:
                        if (!t.RegistrationTypes.Contains(t.ComponentType))
                        {
                            t.RegistrationTypes.Add(t.ComponentType);
                        }

                        break;
                    case Interfaces.FirstInterface:
                        var componentInterfaces = t.ComponentType.GetTypeInfo().GetInterfaces();

                        if (componentInterfaces.Any())
                        {
                            t.RegistrationTypes.Add(componentInterfaces.First());
                        }

                        break;
                    case Interfaces.AllInterfaces:
                        t.RegistrationTypes.AddRange(t.ComponentType.GetTypeInfo().GetInterfaces());
                        break;
                }
            }

            return componentRegistrations;
        }

        public static IEnumerable<ComponentRegistration> AsSingletonIf(this IEnumerable<ComponentRegistration> types, Predicate<ComponentRegistration> predicate)
        {
            var allRegistrations = types as List<ComponentRegistration> ?? types.ToList();
            
            var componentRegistrations = allRegistrations.Where(t => predicate(t));

            foreach (var t in componentRegistrations)
            {
                t.Lifestyle = Lifestyle.Singleton;
            }

            return allRegistrations;
        }

        public static IEnumerable<ComponentRegistration> AsSingleton(this IEnumerable<ComponentRegistration> types)
        {
            var componentRegistrations = types as List<ComponentRegistration> ?? types.ToList();
            foreach (var t in componentRegistrations)
            {
                t.Lifestyle = Lifestyle.Singleton;
            }

            return componentRegistrations;
        }

        public static IEnumerable<ComponentRegistration> AsTransient(this IEnumerable<ComponentRegistration> types)
        {
            var componentRegistrations = types as List<ComponentRegistration> ?? types.ToList();
            foreach (var t in componentRegistrations)
            {
                t.Lifestyle = Lifestyle.Transient;
            }

            return componentRegistrations;
        }

        public static IEnumerable<ComponentRegistration> Named(this IEnumerable<ComponentRegistration> types, Func<ComponentRegistration, string> name)
        {
            var componentRegistrations = types as List<ComponentRegistration> ?? types.ToList();
            foreach (var t in componentRegistrations)
            {
                t.Name = name(t);
            }

            return componentRegistrations;
        }

        public static IEnumerable<ComponentRegistration> Named(this IEnumerable<ComponentRegistration> types, string name)
        {
            var componentRegistrations = types as List<ComponentRegistration> ?? types.ToList();
            foreach (var t in componentRegistrations)
            {
                t.Name = name;
            }

            return componentRegistrations;
        }

        public static IEnumerable<ComponentRegistration> AsTransientIf(this IEnumerable<ComponentRegistration> types, Predicate<ComponentRegistration> predicate)
        {
            var allRegistrations = types as List<ComponentRegistration> ?? types.ToList();

            var componentRegistrations = allRegistrations.Where(t => predicate(t));

            foreach (var t in componentRegistrations)
            {
                t.Lifestyle = Lifestyle.Transient;
            }

            return allRegistrations;
        }

        public static IEnumerable<ComponentRegistration> ImplementedBy<T>(this IEnumerable<ComponentRegistration> types)
        {
            var componentRegistrations = types as List<ComponentRegistration> ?? types.ToList();
            foreach (var t in componentRegistrations)
            {
                t.ComponentType = typeof(T);
            }

            return componentRegistrations;
        }

        public static IEnumerable<ComponentRegistration> ImplementedBy(this IEnumerable<ComponentRegistration> types, object entity)
        {
            var componentRegistrations = types as List<ComponentRegistration> ?? types.ToList();
            foreach (var t in componentRegistrations)
            {
                t.ComponentType = entity.GetType();
                t.ComponentInstance = entity;
            }
            


            return componentRegistrations;
        }

        private static Type GetDefaultInterfaceFor(ComponentRegistration componentRegistration)
        {
            return componentRegistration.ComponentType.GetTypeInfo().GetInterfaces().OrderByDescending(i => i.Name.Length).FirstOrDefault(i => componentRegistration.Name.EndsWith(i.Name) || componentRegistration.Name.EndsWith(i.Name.Substring(1)));
        }

        private static void EnsureRegistrationTypes(ComponentRegistration registration)
        {
            if (registration.RegistrationTypes == null)
            {
                registration.RegistrationTypes = new List<Type>();
            }
        }
    }
}