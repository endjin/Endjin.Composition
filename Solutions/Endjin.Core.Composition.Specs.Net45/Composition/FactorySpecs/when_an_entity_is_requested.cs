namespace Endjin.Core.Specs.Composition.FactorySpecs
{
    #region Using statements

    using Endjin.Core.Composition;
    using Endjin.Core.Specs.Composition.Context;
    using Endjin.Core.Specs.Composition.FactorySpecs.Context;
    using Endjin.Core.Specs.Helpers;

    #endregion

    public class when_an_entity_is_requested : SpecificationsFor<TestFactory>
    {
        protected override void EstablishContext()
        {
            Given<the_service_locator_is_initialized<TestFactory>>();
        }

        protected override void When()
        {
            SUT.Create();
        }

        [Spec]
        public void then_the_entity_is_requested_from_the_container()
        {
            the_service_locator_is_initialized<TestFactory>.Container.Verify(c => c.Resolve<ExampleEntity>());
        }

        public override void TearDown()
        {
            ApplicationServiceLocator.Shutdown();
            base.TearDown();
        }
    }
}