namespace Endjin.Core.Composition.Samples.WP8.Installers
{
    using Endjin.Core.Installers;

    public class StorageInstaller : NamespaceInstallerBase<StorageInstaller>
    {
        public StorageInstaller() : base(".Storage")
        {
        }
    }
}