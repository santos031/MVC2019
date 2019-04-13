using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Models
{
    public class Osoba
    {
        public int OsobaId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string MjestoStanovanja { get; set; }
        public bool Zaposlen { get; set; }
        public string Spol { get; set; }
        public int BrojCipela { get; set; }  //dodano bezveze
        public string Napomena { get; set; }
        public Adresa AdresaOsobe { get; set; }
    }
}