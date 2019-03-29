using Modeli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modeli.Controllers
{
    public class OsobeController : Controller
    {
        // GET: Osoba/PopuniOsobu
        public ViewResult PopuniOsobu()
        {
            return View();
        }

        //POST: Osoba/PopuniOsobu
        [HttpPost]
        public ViewResult PopuniOsobu(Osoba osoba)
        {
            return View(osoba);
        }
    }
}