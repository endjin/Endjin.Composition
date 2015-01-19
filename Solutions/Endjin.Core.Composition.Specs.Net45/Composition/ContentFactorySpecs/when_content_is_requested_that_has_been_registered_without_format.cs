namespace Endjin.Core.Specs.Composition.ContentFactorySpecs
{
    #region Using statements

    using Endjin.Core.Composition;

    using Endjin.Core.Specs.Composition.ContentFactorySpecs.Context;
    using Endjin.Core.Specs.Helpers;

    using NUnit.Framework;

    using Should;

    #endregion Using statements

    public class when_content_is_requested_that_has_been_registered_without_format : SpecificationsFor<TestContentFactory>
    {
        private object content;

        public override void TearDown()
        {
            ApplicationServiceLocator.Shutdown();
            base.TearDown();
        }

        [Spec]
        public void then_the_content_should_be_retrieved()
        {
            var context = this.GetContext<content_is_registered_without_format>();
            this.content.ShouldBeSameAs(context.Content);
        }

        protected override void EstablishContext()
        {
            this.Given<content_is_registered_without_format>();
        }

        protected override void When()
        {
            var context = this.GetContext<content_is_registered_without_format>();
            this.content = this.SUT.GetContentFor(context.ContentName);
        }
    }
}