namespace Endjin.Core.Specs.Composition.DesktopBootstrapperSpecs
{
    #region Using statements

    using System.Collections.Generic;
    using System.Linq;

    using Endjin.Core.Container;
    using Endjin.Core.Specs.Helpers;

    using Should;

    #endregion

    public class when_installers_are_requested_from_the_bootstrapper : SpecificationsFor<DesktopBootstrapper>
    {
        protected override void EstablishContext()
        {
        }

        protected override void When()
        {
            this.installers = this.SUT.GetInstallersAsync().Result;
        }

        [Spec]
        public void then_multiple_installers_will_be_retrieved()
        {
            installers.Count().ShouldBeInRange(1, int.MaxValue);
        }

        private IEnumerable<IInstaller> installers;
    }
}