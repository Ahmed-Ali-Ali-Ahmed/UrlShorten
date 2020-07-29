using System.Web;
using System.Web.Mvc;
using Shortnr.Web.Filters;

namespace Shortnr.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new Shortnr.Web.Filters.ShortnrExceptionFilter());
        }
    }
}
