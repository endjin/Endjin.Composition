namespace Endjin.Core.Composition.Samples.WinRT.Installers
{
    using Endjin.Core.Installers;

    public class StorageInstaller : NamespaceInstallerBase<StorageInstaller>
    {
        public StorageInstaller() : base(".Storage")
        {
        }
    }
}