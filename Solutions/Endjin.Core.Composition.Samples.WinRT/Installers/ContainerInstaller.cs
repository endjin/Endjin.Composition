namespace Endjin.Core.Composition.Samples.WinRT.Installers
{
    #region Using Directives

    using Endjin.Core.Container;

    #endregion

    public class ContainerInstaller : IInstaller
    {
        public void Install(IContainer container)
        {
            container.Register(Component.For<IContainer>().ImplementedBy(container));
        }
    }
}