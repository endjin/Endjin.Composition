namespace Endjin.Core
{
    using Windows.ApplicationModel.Resources;

    public static class ExceptionMessages
    {
        public static string WinRtBootstrapper_YouMustProvideAtLeastOneMarker
        {
            get
            {
                return GetString("WinRtBootstrapper_YouMustProvideAtLeastOneMarker");
            }
        }

        private static string GetString(string id)
        {
            var loader = new ResourceLoader("ExceptionMessages");
            return loader.GetString(id);
        } 
    }
}