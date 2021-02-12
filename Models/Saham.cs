using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HargaSaham.Models
{
    public class Saham
    {
        public int SahamID{ get; set; }

        [Required(ErrorMessage="Silahkan masukkan nama saham" )]
        public string  NamaSaham { get; set; }

        [Required(ErrorMessage = "HargaBeli")]
        public int? Harga { get; set; }

        [Required(ErrorMessage = "Silahkan masukkan sektor")]
        public string SektorId { get; set; }
        public Sektor Sektor { get; set; }

    }
}
