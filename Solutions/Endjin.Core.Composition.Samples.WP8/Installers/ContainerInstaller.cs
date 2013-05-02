namespace Endjin.Core.Composition.Samples.WP8.Installers
{
    using Endjin.Core.Container;

    public class ContainerInstaller : IInstaller
    {
        public void Install(IContainer container)
        {
            container.Register(Component.For<IContainer>().ImplementedBy(container));
        } 
    }
}