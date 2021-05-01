using System.Threading.Tasks;
using WebApi.Models.Cuenta;
using Microsoft.Extensions.Configuration;
using System.Configuration;

using System.IO;
using System.Data;
using System;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace WebApi.Data.Access.DAL
{
    public class CuentasDAL
    {
        private static string _connectionString;


        public static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }



        public CuentasDAL()
        {
            var configuracion = GetConfiguration();
            _connectionString = configuracion.GetConnectionString("DefaultConnection11");
        }


        public static System.Collections.Generic.IEnumerable<CuentaModels> ListaCuentas()
        {
            CuentaModels[] resultCuentas = new CuentaModels[] {

                new CuentaModels{NroCuenta="123455", Tipo="idn", Moneda="bol", Nombre ="Gonzalo" },
                new CuentaModels{NroCuenta="1236889", Tipo="idn", Moneda="bol", Nombre ="Celeste" }

            };

            return resultCuentas;
        }


        //*MOdelo1*/
        public static CuentaModels Inserta(CuentaModels c)
        {
            var configuracion = GetConfiguration();

            using (SqlConnection sql = new SqlConnection(configuracion.GetSection("ConnectionStrings").GetSection("DefaultConnection11").Value))

            {
                sql.Open();
               
                using (SqlCommand cmd = new SqlCommand("adicion", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NRO_CUENTA", c.NroCuenta));
                    cmd.Parameters.Add(new SqlParameter("@tipo", c.Tipo));
                    cmd.Parameters.Add(new SqlParameter("@moneda", c.Moneda));
                    cmd.Parameters.Add(new SqlParameter("@nombre", c.Nombre));

                    // cmd.Parameters.Add(new SqlParameter("@saldo", c.Saldo));
                    cmd.ExecuteNonQuery();

                  
                }
                sql.Close();
                return c;
            }
        }



        // Consulta Saldo
        public static float ConsultaSaldoAsync(string ID)
        {
            var configuracion = Config_StringDB.GetConfiguration();
       

            float req = 0;

          
            using (SqlConnection sql = new SqlConnection(configuracion.GetSection("ConnectionStrings").GetSection("DefaultConnection11").Value))
            {
                /*/https://localhost:44320/api/Cuenta/10000000000001 */


                using (SqlCommand cmd = new SqlCommand("sp_ConsultaSaldo", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter paramID =
                    new SqlParameter("@nro_cuenta", SqlDbType.VarChar, 14);
                    paramID.Value = ID;
                    cmd.Parameters.Add(paramID);
                
                  
                    SqlParameter paramSumary = new SqlParameter("@saldo", SqlDbType.Decimal) { Precision=12, Scale=2};
                    paramSumary.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramSumary);
                    sql.Open();

                    cmd.ExecuteScalar();
                    Debug.WriteLine(paramSumary.Value);
                    req = (float)Convert.ToDecimal(cmd.Parameters["@saldo"].Value);
                    sql.Close();
                }

            }

            return req;
        }
    }
}


