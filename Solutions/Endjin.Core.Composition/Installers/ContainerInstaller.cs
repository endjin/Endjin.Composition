namespace Endjin.Core.Installers
{
    using Endjin.Core.Container;

    public class ContainerInstaller : IInstaller
    {
        // Installs the container itself into the container, by instance
        public void Install(IContainer container)
        {
            container.Register(Component.For<IContainer>().ImplementedBy(container));
        }
    }
}