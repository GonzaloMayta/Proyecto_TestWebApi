using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.FrontEnd.Models
{
    public class Cuenta
    { 
        [Required]
        public string NroCuenta { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Moneda { get; set; }
        [Required]
        public string Nombre { get; set; }
            
        }

}
