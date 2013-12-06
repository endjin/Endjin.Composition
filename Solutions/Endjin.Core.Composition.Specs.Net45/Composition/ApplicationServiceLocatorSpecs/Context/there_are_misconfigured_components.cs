namespace Endjin.Core.Specs.Composition.ApplicationServiceLocatorSpecs.Context
{
    #region Using statements

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Endjin.Core.Composition;
    using Endjin.Core.Container;
    using Endjin.Core.Specs.Composition.Context;
    using Endjin.Core.Specs.Helpers;

    #endregion

    public class there_are_misconfigured_components : SharedContext<ApplicationServiceLocator>
    {
        protected override void Initialize(ITestStateWithContext<ApplicationServiceLocator> state)
        {
            var container = state.GetMockFor<IContainer>();
            container.SetupGet(c => c.MisconfiguredComponents).Returns(new ReadOnlyCollection<ComponentRegistration>(new List<ComponentRegistration> { new ComponentRegistration() }));
        }
    }
}