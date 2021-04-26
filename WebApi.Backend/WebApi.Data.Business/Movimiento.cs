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
        public static int Retiro(MovimientoModels movimientomodelo)
        {
            CuentaModels cuenta = new CuentaModels();
            cuenta.NroCuenta=movimientomodelo.NroCuenta;
            return MovimientoDAL.Retiro(movimientomodelo, cuenta);
        }
        }
}
