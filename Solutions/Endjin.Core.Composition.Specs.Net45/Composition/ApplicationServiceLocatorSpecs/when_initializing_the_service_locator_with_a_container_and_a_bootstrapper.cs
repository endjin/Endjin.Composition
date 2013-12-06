namespace Endjin.Core.Specs.Composition.ApplicationServiceLocatorSpecs
{
    #region Using statements

    using Endjin.Core.Composition;

    using Endjin.Core.Specs.Composition.ApplicationServiceLocatorSpecs.Context;
    using Endjin.Core.Specs.Helpers;

    using NUnit.Framework;

    using Should;

    #endregion

    public class when_initializing_the_service_locator_with_a_container_and_a_bootstrapper : SpecificationsFor<ApplicationServiceLocator>
    {
        protected override void EstablishContext()
        {
            Given<a_container_is_available>();
            And<a_bootstrapper_is_available>();
        }

        protected override void When()
        {
            ApplicationServiceLocator.InitializeAsync(
                a_container_is_available.Container.Object,
                a_bootstrapper_is_available.Bootstrapper.Object).Wait();
        }

        [Spec]
        public void then_the_container_is_set()
        {
            ApplicationServiceLocator.Container
                .ShouldBeSameAs(a_container_is_available.Container.Object);
        }

        [Spec]
        public void then_the_container_has_been_installed()
        {
            a_container_is_available.Container.Verify(c => c.InstallAsync(a_bootstrapper_is_available.Bootstrapper.Object));
        }

        public override void TearDown()
        {
            ApplicationServiceLocator.Shutdown();
            base.TearDown();
        }
    }
}