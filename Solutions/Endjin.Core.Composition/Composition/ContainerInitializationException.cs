namespace Endjin.Core.Composition
{
    using Endjin.Core.Container;
    using System;

    public class ContainerInitializationException : Exception
    {
        public IContainer Container { get; private set; }

        public ContainerInitializationException(IContainer container)
        {
            this.Container = container;
        }
    }
}
