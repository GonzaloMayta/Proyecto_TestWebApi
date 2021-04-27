using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Data.Access.DAL;
using WebApi.Models.Cuenta;

namespace WebApi.Data.Business
{
    public class Cuenta
    {
        
        public static IEnumerable<CuentaModels> ListCuentas()
        {
            try
            {
                //Retornamos la lista de valores del método ListUsers() que invocamos
                return CuentasDAL.ListaCuentas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static float ConsultaSaldo(String Id)
        {

             return CuentasDAL.ConsultaSaldoAsync(Id);

           // return 0;
        }



            public  static CuentaModels InsertarCuenta(CuentaModels cuentamodelo)
        {

            return CuentasDAL.Inserta(cuentamodelo);
           
        }
    }
}
