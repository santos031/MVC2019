﻿using System.Web;
using System.Web.Mvc;

namespace _2._1._1.Matematicki_izraz
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
