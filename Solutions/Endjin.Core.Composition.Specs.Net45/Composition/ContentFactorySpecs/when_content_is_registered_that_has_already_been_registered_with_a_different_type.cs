namespace Endjin.Core.Specs.Composition.ContentFactorySpecs
{
    #region Using statements

    using System;

    using Endjin.Core.Composition;

    using Endjin.Core.Specs.Composition.ContentFactorySpecs.Context;
    using Endjin.Core.Specs.Helpers;

    using NUnit.Framework;

    using Should;

    #endregion

    public class when_content_is_registered_that_has_already_been_registered_with_a_different_type : SpecificationsFor<TestContentFactory>
    {
        private Exception exception;

        protected override void EstablishContext()
        {
            context = this.Given<content_is_registered>();
        }

        protected override void When()
        {
            try
            {
                this.SUT.RegisterContentFor<MoreExampleContent>(context.ContentName);
            }
            catch (Exception ex)
            {
                this.exception = ex;
            }
        }

        [Spec]
        public void then_an_argument_exception_is_thrown()
        {
            this.exception.ShouldBeType<ArgumentException>();
        }

        public override void TearDown()
        {
            ApplicationServiceLocator.Shutdown();
            base.TearDown();
        }

        content_is_registered context;

    }
}