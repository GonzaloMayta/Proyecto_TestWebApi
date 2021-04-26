using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Data.Business;
using WebApi.Models.Cuenta;
using WebApi.Models.Movimiento;

namespace WebApi.Domain
{
    public class MovimientoDomain
    {
        public static int Retiro(MovimientoModels movimientomodelo)
        {

            return Movimiento.Retiro(movimientomodelo);
               
        }
    }
}
