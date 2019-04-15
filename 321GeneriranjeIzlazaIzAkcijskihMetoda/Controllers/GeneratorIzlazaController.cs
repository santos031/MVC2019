using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _321GeneriranjeIzlazaIzAkcijskihMetoda.Controllers
{
    public class GeneratorIzlazaController : Controller
    {
        // GET: GeneratorIzlaza
        public ActionResult PopisKosarice()
        {
            return View();
        }

        public ActionResult ListaArtikala()
        {
            string[] lista = new string[] { "Enciklopedije", "Zbirka Zadataka", "Radna bilježnica", "Wii Igra" };
            ViewBag.Lista = lista;
            return View();
        }

        public ActionResult RedirectNaMetodu(string id)
        {
            if (id=="Kosarica")
            {
                //GeneratorIzlaza/RedirectNaMetodu/Kosarica
                return RedirectToAction("PopisKosarice");
            }
            else
            {
                //GeneratorIzlaza/RedirectNaMetodu/Saricako
                return RedirectToAction("ListaArtikala");
            }
        }
    }


}