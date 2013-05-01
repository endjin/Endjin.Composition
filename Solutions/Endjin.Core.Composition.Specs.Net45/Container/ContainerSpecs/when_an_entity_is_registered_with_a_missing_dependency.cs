namespace Endjin.Core.Specs.Container.ContainerSpecs
{
    #region Using statements

    using System.Linq;

    using Endjin.Core.Composition;
    using Endjin.Core.Container;
    using Endjin.Core.Specs.Helpers;

    using Should;

    #endregion

    public class when_an_entity_is_registered_with_a_missing_dependency : SpecificationsFor<Container>
    {
        protected override void EstablishContext()
        {
        }

        protected override void When()
        {
            this.SUT.Register(Component.For<TestComponent>());
        }

        [Spec]
        public void then_the_entity_should_be_a_misconfigured_component()
        {
            this.SUT.MisconfiguredComponents.Count.ShouldEqual(1);
        }

        [Spec]
        public void then_the_entity_should_be_in_error()
        {
            this.SUT.MisconfiguredComponents.First().Error.ShouldNotBeEmpty();
        }
    }

    public class TestComponent
    {
        public TestComponent(UnregisteredComponent child)
        {}
    }

    public class UnregisteredComponent
    {
    }
}