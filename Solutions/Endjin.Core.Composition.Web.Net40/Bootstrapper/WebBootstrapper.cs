namespace Endjin.Core.Container
{
    #region Using statements

    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web;

    #endregion

    public class WebBootstrapper : IBootstrapper
    {
        public Task<IEnumerable<IInstaller>> GetInstallersAsync()
        {
            return InstallerHelpers.GetInstallersAsync(AssemblyHelpers.GetAssemblyList(HttpRuntime.BinDirectory));
        }
    }
}