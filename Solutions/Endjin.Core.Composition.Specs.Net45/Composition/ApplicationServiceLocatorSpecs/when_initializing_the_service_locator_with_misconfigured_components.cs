namespace Endjin.Core.Specs.Composition.ApplicationServiceLocatorSpecs
{
    #region Using statements

    using System;
    using Endjin.Core.Composition;
    using Endjin.Core.Container;
    using Endjin.Core.Specs.Composition.ApplicationServiceLocatorSpecs.Context;
    using Endjin.Core.Specs.Helpers;

    using NUnit.Framework;

    using Should;

    #endregion

    public class when_initializing_the_service_locator_with_misconfigured_components : SpecificationsFor<ApplicationServiceLocator>
    {
        private static AggregateException exception;
        protected override void EstablishContext()
        {
            Given<a_container_is_available>();
            And<a_bootstrapper_is_available>();
            And<there_are_misconfigured_components>();
        }

        protected override void When()
        {
            try
            {
                ApplicationServiceLocator.InitializeAsync(
                    a_container_is_available.Container.Object,
                    a_bootstrapper_is_available.Bootstrapper.Object).Wait();

            }
            catch (AggregateException ex)
            {
                exception = ex;
            }
        }

        [Spec]
        public void then_an_exception_is_thrown()
        {
            exception.ShouldNotBeNull();
        }

        [Spec]
        public void there_should_be_one_container_initialization_exception()
        {
            exception.InnerExceptions.Count.ShouldEqual(1);
            exception.InnerExceptions[0].ShouldBeType<ContainerInitializationException>();
        }

        [Spec]
        public void the_exception_has_our_container()
        {
            ((ContainerInitializationException)exception.InnerExceptions[0]).Container.ShouldBeSameAs(GetMockFor<IContainer>().Object);
        }

        public override void TearDown()
        {
            ApplicationServiceLocator.Shutdown();
            base.TearDown();
        }
    }
}