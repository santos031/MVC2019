using System.Web;
using System.Web.Mvc;

namespace _4._2._1.Narudzba_artikala
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
