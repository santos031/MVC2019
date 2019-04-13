using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Validacija.Models.Validacije;
using System.ComponentModel.DataAnnotations;

namespace Validacija.Models
{
    [NeViseOdTriDana(ErrorMessage ="Datum ne smije biti manji za vise od 3 dana!")]
    public class MetaRacun
    {

        [Required(ErrorMessage ="Broj racuna je obavezan!")]
        [StringLength(10, MinimumLength =3, ErrorMessage ="Duljina racuna mora biti izmedju 3 i 10 znakova!")]
        public string BrojRacuna { get; set; }

        [DisplayFormat(DataFormatString ="{0:d}", ApplyFormatInEditMode =true)]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage ="Zaposlenik je obavezan!")]
        public string Zaposlenik { get; set; }

        [Required(ErrorMessage = "Kupac je obavezan!")]
        public string Kupac { get; set; }

        [Range(1,1000, ErrorMessage ="Cijena mora biti unutar intervala [1 - 1000]!")]
        [DisplayFormat(DataFormatString ="{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Cijena { get; set; }
    }
}