using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Data.Business;
using WebApi.Models.Cuenta;

namespace WebApi.Domain
{
    public class CuentaDomain
    {

        public IEnumerable<CuentaModels> ListCuentas()
        {
            try
            {//Invocamos al método listar de la capa negocio "Data.Business"
                return Cuenta.ListCuentas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int InsertarCuenta(CuentaModels cm)
        {

            return Cuenta.InsertarCuenta(cm);
        }
    }
}
