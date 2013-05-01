namespace Endjin.Core.Specs.Composition.ApplicationServiceLocatorSpecs
{
    #region Using statements

    using Endjin.Core.Composition;

    using Endjin.Core.Specs.Composition.ApplicationServiceLocatorSpecs.Context;
    using Endjin.Core.Specs.Helpers;

    using NUnit.Framework;

    using Should;

    #endregion

    public class when_initializing_the_service_locator_with_a_container_but_no_bootstrapper : SpecificationsFor<ApplicationServiceLocator>
    {
        protected override void EstablishContext()
        {
            this.Given<a_container_is_available>();
        }

        protected override void When()
        {
            // No need to wait, it is just a Mock
            ApplicationServiceLocator.InitializeAsync(a_container_is_available.Container.Object, null);
        }

        [Spec]
        public void then_the_container_is_set()
        {
            ApplicationServiceLocator.Container.ShouldBeSameAs(a_container_is_available.Container.Object);
        }

        public override void TearDown()
        {
            ApplicationServiceLocator.Shutdown();
            base.TearDown();
        }
    }
}