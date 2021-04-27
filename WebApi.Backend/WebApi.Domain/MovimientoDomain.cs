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
        public static MovimientoModels Retiro(MovimientoModels movimientomodelo)
        {

            return Movimiento.Retiro(movimientomodelo);
        
        }

        public static MovimientoModels Deposito(MovimientoModels movimientomodels)
        {
            return Movimiento.Deposito(movimientomodels);
        }
    }
}
