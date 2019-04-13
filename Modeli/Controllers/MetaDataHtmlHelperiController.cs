using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modeli.Models;

namespace Modeli.Controllers
{
    public class MetaDataHtmlHelperiController : Controller
    {
        // GET: MetaDataHtmlHelperi
        public ActionResult MetaDataView()
        {
            return View(new OsobaMeta());
        }

        [HttpPost]
        public ActionResult MetaDataView(OsobaMeta osoba)
        {
            return View("HtmlLabelDisplay", osoba);
        }
    }
}
