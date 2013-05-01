namespace Endjin.Core.Specs.Composition.ContentFactorySpecs
{
    #region Using statements

    using Endjin.Core.Composition;

    using Endjin.Core.Specs.Composition.ContentFactorySpecs.Context;
    using Endjin.Core.Specs.Helpers;

    using NUnit.Framework;

    using Should;

    #endregion

    public class when_content_is_requested_with_fallback_that_has_been_registered : SpecificationsFor<TestContentFactory>
    {
        private object content;

        protected override void EstablishContext()
        {
            this.Given<content_is_registered>();
        }

        protected override void When()
        {
            var context = this.GetContext<content_is_registered>();
            this.content = this.SUT.GetContentFor(context.ContentNameForFallback);
        }

        [Spec]
        public void then_the_content_should_be_retrieved()
        {
            var context = this.GetContext<content_is_registered>();
            this.content.ShouldBeSameAs(context.Content);
        }

        public override void TearDown()
        {
            ApplicationServiceLocator.Shutdown();
            base.TearDown();
        }
    }
}