using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Adresar.WcfService.Models
{
    [DataContract]
    public class Kontakt
    {
        [DataMember]
        [Key] //primary key, atribut koji definira svojstvo
        public int Id { get; set; }

        [DataMember]
        [Required] //atribut koji ne dozvoljava unos NULL
        [StringLength(25, ErrorMessage ="Ime ne smije biti veće od 25 znakova")]
        public string Ime { get; set; }

        [DataMember]
        [Required]
        [StringLength(25)] //atribut kojim definiramo duljinu polja u tablici, po defaultu bude NVARCHAR(MAX)
        public string Prezime { get; set; }

        [DataMember]
        [StringLength(100)]
        public string Adresa { get; set; }

        [DataMember]
        [StringLength(20)]
        public string Telefon { get; set; }

        [DataMember]
        [StringLength(20)]
        public string Mobitel { get; set; }

        [DataMember]
        [StringLength(30)]
        public string Email { get; set; }

        [DataMember]
        public string Napomena { get; set; }

        [DataMember]
        public bool Aktivan { get; set; }
    }
}