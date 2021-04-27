using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Models.Consulta
{
     public  class ConsultaModels 
    {

        public ConsultaModels() { }

        public string Tipo  { get; set; }
        public string Moneda { get; set; }
        public string NRO_CUENTA { get; set; }
        public string NOMBRE { get; set; }
        public float Saldo { get; set; }


    }
}
