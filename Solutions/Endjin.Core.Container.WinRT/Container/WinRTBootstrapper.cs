namespace Endjin.Core.Container
{
    #region Using statements

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    #endregion

    public class WinRtBootstrapper : IBootstrapper
    {
        public async Task<IEnumerable<IInstaller>> GetInstallersAsync()
        {
            var installers = await AssemblyHelpers.GetAssemblyList();
            return await InstallerHelpers.GetInstallersAsync(installers);
        }
    }
}