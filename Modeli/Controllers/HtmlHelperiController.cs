﻿using Modeli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modeli.Controllers
{
    public class HtmlHelperiController : Controller
    {
        // GET: HtmlHelperi
        public ActionResult Index()
        {
            return View();
        }

        private string[] mjesta = new string[]
        {
            "Split", "Osijek", "Zadar", "Rijeka"
        };
        public ViewResult FormHelper()
        {
            ViewBag.Mjesta = this.mjesta;
            return View(new Osoba());
        }

        [HttpPost]
        public ViewResult FormHelper(Osoba osoba)
        {
            ViewBag.Mjesta = this.mjesta;
            ViewBag.Poruka = "Ovo je poruka";
            return View(new Osoba());
        }
    }

}