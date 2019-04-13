using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Adresar.Models
{
    public class Kontakt
    {
        [Key] //primary key, atribut koji definira svojstvo
        public int Id { get; set; }

        [Required] //atribut koji ne dozvoljava unos NULL
        [StringLength(25, ErrorMessage ="Ime ne smije biti veće od 25 znakova")]
        public string Ime { get; set; }

        [Required]
        [StringLength(25)] //atribut kojim definiramo duljinu polja u tablici, po defaultu bude NVARCHAR(MAX)
        public string Prezime { get; set; }

        [StringLength(100)]
        public string Adresa { get; set; }

        [StringLength(20)]
        public string Telefon { get; set; }

        [StringLength(20)]
        public string Mobitel { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        public string Napomena { get; set; }

        public bool Aktivan { get; set; }
    }
}