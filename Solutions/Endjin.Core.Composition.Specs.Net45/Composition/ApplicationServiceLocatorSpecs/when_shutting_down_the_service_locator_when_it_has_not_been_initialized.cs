namespace Endjin.Core.Specs.Composition.ApplicationServiceLocatorSpecs
{
    #region Using statements

    using Endjin.Core.Composition;
    using Endjin.Core.Specs.Helpers;

    using NUnit.Framework;

    using Should;

    #endregion

    public class when_shutting_down_the_service_locator_when_it_has_not_been_initialized : SpecificationsFor<ApplicationServiceLocator>
    {
        protected override void EstablishContext()
        {
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