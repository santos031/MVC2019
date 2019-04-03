using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modeli.Controllers
{
    public class ChildActionController : Controller
    {
        // GET: ChildAction
        public ViewResult ChildActionView()
        {
            string[] proizvodi = new string[]
            {
                "Banana", "Jabuka", "Šljiva", "Mrkva", "Kupus", "Krompir", "Čokolada"
            };
            return View(proizvodi);
        }

        // GET: ChildAction/OdrediGrupuProizvoda
        [ChildActionOnly]
        public string OdrediGrupuProizvoda(string proizvod)
        {
            switch (proizvod)
            {
                case "Jabuka":
                case "Šljiva":
                case "Banana": return "Voće";
                case "Mrkva":
                case "Kupus":
                case "Krompir":return "Povrće";
                default: return "Nepoznato";
            }
        }
    }
}