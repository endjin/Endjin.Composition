using System.Web;
using System.Web.Mvc;

namespace Endjin.Core.Composition.Samples.Mvc5.Net45
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
