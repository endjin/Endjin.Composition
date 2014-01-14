namespace Endjin.Core.Composition.Samples.Mvc5.Net45.Installers
{
    using Endjin.Core.Installers;

    public class StorageInstaller : NamespaceInstallerBase<StorageInstaller>
    {
        public StorageInstaller() : base(".Storage")
        {
        }
    }
}