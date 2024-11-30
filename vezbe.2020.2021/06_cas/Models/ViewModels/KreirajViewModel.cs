using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prodavnica2.Models.ViewModels
{
    public class KreirajViewModel
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Sifra { get; set; }
    }
}
