using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _321GeneriranjeIzlazaIzAkcijskihMetoda.Controllers
{
    public class KalkulatorController : Controller
    {
        // GET: Kalkulator
        public ViewResult Izracunaj()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Izracunaj(decimal br1, decimal br2, string op)
        {
            ViewBag.Br1 = br1;
            ViewBag.Br2 = br2;
            return View((object)op);
        }
    }
}