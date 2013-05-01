namespace Endjin.Core.Specs.Composition.ApplicationServiceLocatorSpecs
{
    #region Using statements

    using System;

    using Endjin.Core.Composition;
    using Endjin.Core.Container;
    using Endjin.Core.Specs.Composition.ApplicationServiceLocatorSpecs.Context;
    using Endjin.Core.Specs.Helpers;

    using Should;

    #endregion

    public class when_initializing_the_service_locator_twice : SpecificationsFor<ApplicationServiceLocator>
    {
        private Exception exception;

        protected override void EstablishContext()
        {
            this.Given<the_service_locator_has_been_initialized>();
        }

        protected override void When()
        {
            try
            {
                ApplicationServiceLocator.InitializeAsync(this.GetMockFor<IContainer>().Object, null).Wait();
            }
            catch (Exception ex)
            {
                this.exception = ex;
            }
        }

        [Spec]
        public void then_an_invalid_operation_exception_is_thrown()
        {
            this.exception.ShouldBeType<InvalidOperationException>();
        }

        public override void TearDown()
        {
            ApplicationServiceLocator.Shutdown();
            base.TearDown();
        }
    }
}