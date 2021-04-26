using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Models.Cuenta
{
    public class CuentaModels
    {
        public string NroCuenta { get; set; }
        public string Tipo { get; set; }
        public string Moneda { get; set; }
        public string Nombre { get; set; }
        public float Saldo { get; set; }

    }
}
