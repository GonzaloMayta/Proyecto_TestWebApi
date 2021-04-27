using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.FrontEnd.Models
{
    public class Movimientos
    {
        [Required]
       //[StringLength(14, ErrorMessage = "Description too long (40 char).")]
        [MaxLength(14)]
        [MinLength(13)]
        public string NroCuenta { get; set; }
        [Required]
        public float Importe { get; set; }
    }
}
