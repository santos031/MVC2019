using System.Web;
using System.Web.Mvc;

namespace _531_Stranice_s_layoutom
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
