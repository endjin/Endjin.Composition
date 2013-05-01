namespace Endjin.Core.Composition.Samples.Net40.Installers
{
    using Endjin.Core.Installers;

    public class StorageInstaller : NamespaceInstallerBase<StorageInstaller>
    {
        public StorageInstaller() : base(".Storage")
        {
        }
    }
}