namespace Endjin.Core.Container
{
    #region Using statements

    using System.Collections.Generic;
    using System.Threading.Tasks;

    #endregion Using statements

    public interface IBootstrapper
    {
        Task<IEnumerable<IInstaller>> GetInstallersAsync();

        void RegisterContent();

        Task RegisterResourcesAsync();
    }
}