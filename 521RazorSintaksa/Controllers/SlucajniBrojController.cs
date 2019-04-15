using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _521RazorSintaksa.Controllers
{
    public class SlucajniBrojController : Controller
    {
        // GET: SlucajniBroj
        public ViewResult RazvrstajSlucajniBroj()
        {
            Random slucajniBroj = new Random();
            int broj = slucajniBroj.Next(1, 1000);
            return View(broj);
        }
    }
}