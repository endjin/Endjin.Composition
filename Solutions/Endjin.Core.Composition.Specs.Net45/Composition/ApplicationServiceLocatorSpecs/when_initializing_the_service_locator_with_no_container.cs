namespace Endjin.Core.Specs.Composition.ApplicationServiceLocatorSpecs
{
    #region Using statements

    using System;

    using Endjin.Core.Composition;
    using Endjin.Core.Specs.Helpers;

    using NUnit.Framework;

    using Should;

    #endregion

    public class when_initializing_the_service_locator_with_no_container : SpecificationsFor<ApplicationServiceLocator>
    {
        private Exception exception;

        protected override void EstablishContext()
        {
        }

        protected override void When()
        {
            try
            {
                ApplicationServiceLocator.InitializeAsync(null, null).Wait();
            }
            catch (Exception ex)
            {
                this.exception = ex;
            }
        }

        [Spec]
        public void then_an_argument_null_exception_is_thrown()
        {
            this.exception.ShouldBeType<ArgumentNullException>();
        }

        public override void TearDown()
        {
            ApplicationServiceLocator.Shutdown();
            base.TearDown();
        }
    }
}