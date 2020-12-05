using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prodavnica2.Models
{
    public class Proizvod
    {
        public  int ProizvodID { get; set; }

        [Required (ErrorMessage = "Molimo unesite ime proizvoda.")]
        public string Ime { get; set; }
        public string Opis { get; set; }

        [Required (ErrorMessage = "Molimo unesite kategoriju.")]
        public string Kategorija { get; set; }

        [Required]
        [Range(1, (double)(decimal.MaxValue), ErrorMessage = "Molimo unesite pozitivnu cenu")]
        public decimal Cena { get; set; }
        public string SlikaPutanja { get; set; }
    }
}
