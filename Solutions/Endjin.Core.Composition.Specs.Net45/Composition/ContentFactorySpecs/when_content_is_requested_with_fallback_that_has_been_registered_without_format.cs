namespace Endjin.Core.Specs.Composition.ContentFactorySpecs
{
    #region Using statements

    using Endjin.Core.Composition;

    using Endjin.Core.Specs.Composition.ContentFactorySpecs.Context;
    using Endjin.Core.Specs.Helpers;

    using NUnit.Framework;

    using Should;

    #endregion

    public class when_content_is_requested_with_fallback_that_has_been_registered_without_format : SpecificationsFor<TestContentFactory>
    {
        protected override void EstablishContext()
        {
            context = this.Given<content_is_registered_without_format>();
        }

        protected override void When()
        {
            this.content = this.SUT.GetContentFor(context.ContentNameForFallback);
        }

        [Spec]
        public void then_the_content_should_be_retrieved()
        {
            this.content.ShouldBeSameAs(context.Content);
        }

        public override void TearDown()
        {
            ApplicationServiceLocator.Shutdown();
            base.TearDown();
        }

        private object content;
        private content_is_registered_without_format context;
    }
}