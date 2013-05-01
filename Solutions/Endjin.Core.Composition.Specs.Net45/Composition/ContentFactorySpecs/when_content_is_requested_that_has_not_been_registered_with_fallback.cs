namespace Endjin.Core.Specs.Composition.ContentFactorySpecs
{
    #region Using statements

    using Endjin.Core.Specs.Composition.ContentFactorySpecs.Context;
    using Endjin.Core.Specs.Helpers;

    using NUnit.Framework;

    using Should;

    #endregion

    public class when_content_is_requested_that_has_not_been_registered_with_fallback : SpecificationsFor<TestContentFactory>
    {
        private object content;

        protected override void EstablishContext()
        {
        }

        protected override void When()
        {
            this.content = this.SUT.GetContentFor("Nonexistent.Subspec");
        }

        [Spec]
        public void then_the_content_should_be_null()
        {
            this.content.ShouldBeNull();
        }
    }
}