using System.Web;
using System.Web.Mvc;

namespace Adonet_spajanje_na_bazu
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
