namespace Endjin.Core.Specs.Composition.ApplicationServiceLocatorSpecs.Context
{
    #region Using statements

    using Endjin.Core.Composition;
    using Endjin.Core.Container;

    using SpecsFor;

    #endregion

    public class the_service_locator_has_been_initialized : IContext<ApplicationServiceLocator>
    {
        public void Initialize(ISpecs<ApplicationServiceLocator> state)
        {
            ApplicationServiceLocator.Initialize(state.GetMockFor<IContainer>().Object);
        }
    }
}