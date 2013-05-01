namespace Endjin.Core.Specs.Composition.NamedFactorySpecs
{
    #region Using statements

    using Endjin.Core.Composition;
    using Endjin.Core.Specs.Composition.Context;
    using Endjin.Core.Specs.Composition.NamedFactorySpecs.Context;
    using Endjin.Core.Specs.Helpers;

    using NUnit.Framework;

    #endregion

    public class when_an_entity_is_requested_by_name : SpecificationsFor<TestFactory>
    {
        protected override void EstablishContext()
        {
            this.Given<the_service_locator_is_initialized<TestFactory>>();
        }

        protected override void When()
        {
            this.SUT.Create(ExampleName);
        }

        [Spec]
        public void then_the_entity_is_requested_from_the_container()
        {
            the_service_locator_is_initialized<TestFactory>.Container.Verify(c => c.Resolve<ExampleEntity>(ExampleName));
        }

        public override void TearDown()
        {
            ApplicationServiceLocator.Shutdown();
            base.TearDown();
        }

        private const string ExampleName = "ExampleName";
    }
}