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
        public static MovimientoModels Deposito(MovimientoModels mov)
        {
            var configuracion = Config_StringDB.GetConfiguration();

            using (SqlConnection sql = new SqlConnection(configuracion.GetSection("ConnectionStrings").GetSection("DefaultConnection11").Value))

            {
                sql.Open();
               
                using (SqlCommand cmd = new SqlCommand("sp_deposito", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NRO_CUENTA", mov.NroCuenta));
                    float a = mov.Importe;
                    cmd.Parameters.Add(new SqlParameter("@IMPORTEm", mov.Importe));

                   cmd.ExecuteNonQuery();

                   
                }
                sql.Close();
                return mov;
            }

        }

        public static MovimientoModels Retiro(MovimientoModels c)
        {
            var configuracion = Config_StringDB.GetConfiguration();

            using (SqlConnection sql = new SqlConnection(configuracion.GetSection("ConnectionStrings").GetSection("DefaultConnection11").Value))

            {
                sql.Open();
                        
                using (SqlCommand cmd = new SqlCommand("sp_retiro", sql))
                         {
                             cmd.CommandType = System.Data.CommandType.StoredProcedure;
                             cmd.Parameters.Add(new SqlParameter("@NRO_CUENTA", c.NroCuenta));
                             cmd.Parameters.Add(new SqlParameter("@IMPORTEm", c.Importe));

                            
                             cmd.ExecuteNonQuery();

                 }
                 sql.Close();
                return c;
            }


        }


       
    }
}


/*
 using(SqlCommand consulta=new SqlCommand("sp_ConsultaSaldo", sql))
                {
                    consulta.CommandType = System.Data.CommandType.StoredProcedure;
                    consulta.Parameters.Add(new SqlParameter("@nro_cuenta", c.NroCuenta));
                    consulta.Parameters.Add(new SqlParameter("@saldo", SqlDbType.Float).Direction=ParameterDirection.Output);

                    int fila = consulta.ExecuteNonQuery();
                    if (fila > 0)
                    {
                        flat = 1;
                    }

                    cuenta.Saldo = (float)Convert.ToDouble(consulta.Parameters["@saldo"].Value);


                }
 */