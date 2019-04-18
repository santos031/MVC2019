using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ispit.Controllers
{
    public class PrviController : Controller
    {
        // GET: Prvi (kontroler/action)
        public ViewResult Prvi()
        {
            ViewBag.Vrijeme = DateTime.Now;
            return View("Prvi");
        }

    }
}