using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ispit.Models
{
    public class Pokloni
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Ime { get; set; }
        public bool Stanje { get; set; }
    }
}