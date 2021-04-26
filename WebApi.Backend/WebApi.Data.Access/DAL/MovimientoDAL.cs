using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WebApi.Models.Cuenta;
using WebApi.Models.Movimiento;

namespace WebApi.Data.Access.DAL
{
    public class MovimientoDAL
    {
        /*
        public static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        */

        public static int Deposito(MovimientoModels c)
        {
            var configuracion = Config_StringDB.GetConfiguration();

            using (SqlConnection sql = new SqlConnection(configuracion.GetSection("ConnectionStrings").GetSection("DefaultConnection11").Value))

            {
                sql.Open();
                int i = 0;
                using (SqlCommand cmd = new SqlCommand("sp_deposito", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NRO_CUENTA", c.NroCuenta));
                    cmd.Parameters.Add(new SqlParameter("@IMPORTEm", c.Importe));

                    // cmd.Parameters.Add(new SqlParameter("@saldo", c.Saldo));
                    cmd.ExecuteNonQuery();

                    i = 1;
                }
                //sql.Close();
                return i;
            }

        }

        public static int Retiro(MovimientoModels c, CuentaModels cuenta)
        {
            var configuracion = Config_StringDB.GetConfiguration();

            using (SqlConnection sql = new SqlConnection(configuracion.GetSection("ConnectionStrings").GetSection("DefaultConnection11").Value))

            {
                sql.Open();
                //int i = 0;
                int flat = 0;

               using(SqlCommand consulta=new SqlCommand("sp_ConsultaSaldo", sql))
                {
                    consulta.CommandType = System.Data.CommandType.StoredProcedure;
                    consulta.Parameters.Add(new SqlParameter("@nro_cuenta", cuenta.NroCuenta));
                    consulta.Parameters.Add(new SqlParameter("@saldo", SqlDbType.Float).Direction=ParameterDirection.Output);

                    int fila = consulta.ExecuteNonQuery();
                    if (fila > 0)
                    {
                        flat = 1;
                    }

                    cuenta.Saldo = (float)Convert.ToDouble(consulta.Parameters["@saldo"].Value);


                }

                /*
                     if (flat != 0) {
                         using (SqlCommand cmd = new SqlCommand("sp_retiro", sql))
                         {
                             cmd.CommandType = System.Data.CommandType.StoredProcedure;
                             cmd.Parameters.Add(new SqlParameter("@NRO_CUENTA", c.NroCuenta));
                             cmd.Parameters.Add(new SqlParameter("@IMPORTEm", c.Importe));

                             // cmd.Parameters.Add(new SqlParameter("@saldo", c.Saldo));
                             cmd.ExecuteNonQuery();

                             i = 1;
                         } }
                 //sql.Close();
                     return i;*/

                return flat;
            }


        }
    }
}
