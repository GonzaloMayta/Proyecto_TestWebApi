using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Data.Access.DAL;
using WebApi.Models.Cuenta;
using WebApi.Models.Movimiento;

namespace WebApi.Data.Business
{
    public class Movimiento
    {
        public static MovimientoModels Retiro(MovimientoModels movimientomodelo)
        {
            
            return MovimientoDAL.Retiro(movimientomodelo);
        }

        public static MovimientoModels Deposito(MovimientoModels movimientomodelo)
        {
            return MovimientoDAL.Deposito(movimientomodelo);

        }
    }
}
