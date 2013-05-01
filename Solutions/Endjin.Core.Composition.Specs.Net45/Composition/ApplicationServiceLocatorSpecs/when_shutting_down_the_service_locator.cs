namespace Endjin.Core.Specs.Composition.ApplicationServiceLocatorSpecs
{
    #region Using statements

    using Endjin.Core.Composition;

    using Endjin.Core.Specs.Composition.ApplicationServiceLocatorSpecs.Context;
    using Endjin.Core.Specs.Helpers;

    using NUnit.Framework;

    using Should;

    #endregion

    public class when_shutting_down_the_service_locator : SpecificationsFor<ApplicationServiceLocator>
    {
        protected override void EstablishContext()
        {
            this.Given<the_service_locator_has_been_initialized>();
        }

        protected override void When()
        {
            ApplicationServiceLocator.Shutdown();
        }

        [Spec]
        public void then_the_container_should_be_null()
        {
            ApplicationServiceLocator.Container.ShouldBeNull();
        }
    }
}