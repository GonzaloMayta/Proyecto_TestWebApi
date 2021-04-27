using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WebApi.Models.Transferencias;

namespace WebApi.Data.Access.DAL
{
    public class TransferenciaDAL
    {

        public static TransferenciaModels transferencia(TransferenciaModels t)
        {
            var configuracion =Config_StringDB. GetConfiguration();

            using (SqlConnection sql = new SqlConnection(configuracion.GetSection("ConnectionStrings").GetSection("DefaultConnection11").Value))

            {
                sql.Open();
                
                using (SqlCommand cmd = new SqlCommand("sp_Transferencias", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@cuenta1", t.nrocuenta1));
                    cmd.Parameters.Add(new SqlParameter("@cuenta2",t.nrocuenta2));
                    cmd.Parameters.Add(new SqlParameter("@monto", t.monto));
                    
                    cmd.ExecuteNonQuery();

                }
                sql.Close();
                return t;

            }
        }
    }
}
   
