using System.Web;
using System.Web.Mvc;

namespace _3._1._1.Kreiranje_kontrolera
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
