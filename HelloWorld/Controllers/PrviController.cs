using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class PrviController : Controller
    {
        // GET: Prvi/MetodaSParametrima/1349
        public ActionResult MetodaSaParametrima(int id)
        {
            //return View(); //ne treba pregled, nego izlistavam podatke kao text
            return Content(id.ToString());
        }
        // GET: Drugi/MetodaSParametrima/54321
        public ViewResult DrugaMetodaSaParametrima(int id)
        {
            return View((object)id); //parametar ID mora se spakirati u OBJECT ako ga isporuzcujemo u Viewu 
            //return Content(id.ToString());
        }
    }
}