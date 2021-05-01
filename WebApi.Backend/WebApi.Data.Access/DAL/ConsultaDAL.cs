using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WebApi.Models.Consulta;

namespace WebApi.Data.Access.DAL
{
    public class ConsultaDAL
    {
        
        public List< ConsultaModels>  consulta()
        {
            var configuracion = Config_StringDB.GetConfiguration();

            using (SqlConnection sql = new SqlConnection(configuracion.GetSection("ConnectionStrings").GetSection("DefaultConnection11").Value))

            {
                sql.Open();
                
                using (SqlCommand cmd = new SqlCommand("sp_Transferencias", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   // cmd.Parameters.Add(new SqlParameter("@saldo", c.Saldo));
                    cmd.ExecuteReader();

                   //ConsultaModels[] response = new ConsultaModels[100];

                    
                   // var respo = List<new ConsultaModels>();
                    
                     sql.OpenAsync();

                    using (var reader =  cmd.ExecuteReader())
                    {
                        while ( reader.Read())
                        {



                     //       respo.Add(MapToValue(reader));
                        }
                    }
                    //cmd.Connection = sql;
                    //ConsultaModels response = new ConsultaModels();

                    /* ConsultaModels c = new ConsultaModels();
                     DataSet ds = new DataSet();
                     SqlDataAdapter da = new SqlDataAdapter(cmd);
                     da.Fill(ds);
                     c = da;
                     i = 1;*/
                }
                //sql.Close();
                

            }


            return null;
        }

        private ConsultaModels MapToValue(SqlDataReader reader)
        {
            return new ConsultaModels()
            {
                Tipo = reader["nrocuenta"].ToString(),
                Moneda = reader["tipo"].ToString(),
                NRO_CUENTA = reader["moneda"].ToString(),
                NOMBRE = reader["nombre"].ToString(),
                Saldo = (int)reader["saldo"]

            };
        }
    }
}
