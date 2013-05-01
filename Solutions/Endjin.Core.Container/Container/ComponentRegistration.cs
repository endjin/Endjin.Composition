namespace Endjin.Core.Container
{
    using System;
    using System.Collections.Generic;

    public class ComponentRegistration
    {
        public Type ComponentType { get; set; }

        public List<Type> RegistrationTypes { get; set; }

        public Interfaces Interfaces { get; set; }

        public Lifestyle Lifestyle { get; set; }

        public string Name { get; set; }

        public object ComponentInstance { get; set; }

        public ConstructorRegistration PreferredConstructor { get; set; }

        public string Error { get; internal set; }
    }
}