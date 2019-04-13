using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4._2._1.Narudzba_artikala
{
    public class Artikal
    {
        public string Kategorija { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public int Kolicina { get; set; }
    }
}