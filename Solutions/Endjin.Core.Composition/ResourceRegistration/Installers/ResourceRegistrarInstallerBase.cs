namespace Endjin.Core.ResourceRegistration.Installers
{
    #region Using directives

    using Endjin.Core.Installers;
    using Endjin.Core.ResourceRegistration.Contracts;

    #endregion

    /// <summary>
    /// A base class for resource registrar installers
    /// </summary>
    public abstract class ResourceRegistrarInstallerBase<TMarker> : InstallerBase<IResourceRegistrar, TMarker>
    {      
    }
}