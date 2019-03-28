using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2._1._1.Matematicki_izraz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Matematicka()
        {
            string message = "rezultat operacije 4+3*3=2";
            return View((object)message);
        }
    
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}