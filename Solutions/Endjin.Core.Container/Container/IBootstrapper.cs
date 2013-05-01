namespace Endjin.Core.Container
{
    #region Using statements

    using System.Collections.Generic;
    using System.Threading.Tasks;

    #endregion

    public interface IBootstrapper
    {
        Task<IEnumerable<IInstaller>> GetInstallersAsync();
    }
}