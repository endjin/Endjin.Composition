namespace Endjin.Core.Specs.Composition.ApplicationServiceLocatorSpecs.Context
{
    #region Using statements

    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Endjin.Core.Composition;
    using Endjin.Core.Container;

    using Moq;

    using SpecsFor;

    #endregion

    public class a_bootstrapper_is_available : IContext<ApplicationServiceLocator>
    {
        public static Mock<IBootstrapper> Bootstrapper { get; set; }

        public IInstaller[] Installers { get; set; }

        public void Initialize(ITestState<ApplicationServiceLocator> state)
        {
            Bootstrapper = state.GetMockFor<IBootstrapper>();
            this.Installers = new[] { state.GetMockFor<IInstaller>().Object };
#if NET40
            Bootstrapper.Setup(b => b.GetInstallersAsync()).Returns(TaskHelper.FromResult<IEnumerable<IInstaller>>(this.Installers));
#else
            Bootstrapper.Setup(b => b.GetInstallersAsync()).Returns(Task.FromResult<IEnumerable<IInstaller>>(this.Installers));
#endif
        }
    }
}