namespace Endjin.Core.Specs.Composition.Context
{
    #region Using statements

    using System;

    using Endjin.Core.Composition;
    using Endjin.Core.Specs.Helpers;

    #endregion

    public class the_service_locator_is_initialized<T> : a_container_is_available<T>
    {
        protected override void Initialize(ITestStateWithContext<T> state)
        {            
            base.Initialize(state);
            ApplicationServiceLocator.Shutdown();
            ApplicationServiceLocator.Initialize(Container.Object);
        }
    }
}