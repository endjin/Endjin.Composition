namespace Endjin.Core.Container
{
    #region Using statements

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    #endregion

    public class DesktopBootstrapper : IBootstrapper
    {
        public Task<IEnumerable<IInstaller>> GetInstallersAsync()
        {
            return InstallerHelpers.GetInstallersAsync(AssemblyHelpers.GetAssemblyList(AppDomain.CurrentDomain.BaseDirectory));
        }
    }
}