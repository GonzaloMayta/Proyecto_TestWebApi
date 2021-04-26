using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.FrontEnd.Models
{
    public class Cuenta
    {
        public string NroCuenta { get; set; }
        public string Tipo { get; set; }
        public string Moneda { get; set; }
        public string Nombre { get; set; }
        public float Saldo { get; set; }


    }

    public class Movimiento
    {

        public string NroCuenta { get; set; }
        public string Fecha { get; set; }

        public string Tipo { get; set; }
        public float importe { get; set; }

    }



    public class Moneda
    {
        public string    Id_moneda { get; set; }
        public string pais { get; set; }

    }

    public class Tipo_Cambio
    {
        public string Id_moneda { get; set; }
        public string fecha { get; set; }
        public float valor_compra { get; set; }
        public float valor_venta { get; set; }
    }


    public class Transferencia
    {
        public string Cuenta1 { get; set; }
        public string Cuenta2 { get; set; }

        public string Fecha { get; set; }
        public string Tipo1 { get; set; }
        public string Tipo2 { get; set; }
        public float Importe { get; set; }

    }

   

}
