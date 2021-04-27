using System.Threading.Tasks;
using WebApi.Models.Cuenta;
//using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Configuration;

using System.IO;
using System.Data;
using System;
using Microsoft.Data.SqlClient;

namespace WebApi.Data.Access.DAL
{
    public class CuentasDAL
    {
        private static string _connectionString ;


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
                int i = 0;
                using (SqlCommand cmd = new SqlCommand("adicion", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NRO_CUENTA", c.NroCuenta));
                    cmd.Parameters.Add(new SqlParameter("@tipo", c.Tipo));
                    cmd.Parameters.Add(new SqlParameter("@moneda", c.Moneda));
                    cmd.Parameters.Add(new SqlParameter("@nombre", c.Nombre));

                   // cmd.Parameters.Add(new SqlParameter("@saldo", c.Saldo));
                    cmd.ExecuteNonQuery();

                    i = 1;
                }
                //sql.Close();
                return c;
            }
        }


        
        public static  float ConsultaSaldoAsync(string ID)
        {
            var configuracion = Config_StringDB.GetConfiguration();
            float saldo = 0;
            CuentaModels ccc = new CuentaModels();
            float response = 0;
            using (SqlConnection sql = new SqlConnection(configuracion.GetSection("ConnectionStrings").GetSection("DefaultConnection11").Value))
            {
                sql.Open();

               
                using (SqlCommand cmd= new SqlCommand("sp_ConsultaSaldo", sql))
                {
                    
                    
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter paramID =
                    new SqlParameter("@NRO_CUENTA", SqlDbType.VarChar, 14 );
                    paramID.Value = ID;
                    cmd.Parameters.Add(paramID);
                   

                    //cmd.Parameters.Add(new SqlParameter("@NRO_CUENTA", ID));

                   // cmd.Parameters.Add(new SqlParameter("@saldo", SqlDbType.Decimal).Direction = ParameterDirection.Output);

                    SqlParameter paramSumary = new SqlParameter("@saldo", SqlDbType.Decimal);
                    paramSumary.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramSumary);

                    cmd.ExecuteNonQuery();
                    //SqlDataReader read = cmd.ExecuteReader();

                    response = (float)Convert.ToDouble(cmd.ExecuteScalar());
                    
/*
                    SqlParameterCollection paramCollection = cmd.Parameters;
                    string parameterList = "";

                    string result = "";
                    while (read.Read())
                    {
                         result = (string)read["saldo"];

                    }



                    /*
                    for (int i = 0; i < paramCollection.Count; i++)
                    {
                        parameterList += String.Format("  {0}, {1}, {2}\n",
                            paramCollection[i], paramCollection[i].DbType,
                            paramCollection[i].Direction);
                    }
                    Console.WriteLine("Parameter Collection:\n" + parameterList);
                    */
                    // Execute the stored procedure; retrieve
                    // and display the output parameter value.
                    // cmd.ExecuteNonQuery();
                    //Console.WriteLine((String)(paramSumary.Value));
                    //response = (float)Convert.ToDecimal(result);



                    /*
                    SqlDataReader r=cmd.ExecuteReader();
                    while (r.Read()) {
                        Console.WriteLine(r["saldo"]);
                        response = (float)r["saldo"];

                    }

                    Console.WriteLine(r["saldo"]);



                    // cmd.Parameters.Add(new SqlParameter("@saldo", SqlDbType.Decimal).Direction = ParameterDirection.Output);
                    // Value response = null;
                    //await sql.OpenAsync();
                    /*
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while ( await reader.ReadAsync())
                        {
                            saldo = (float)reader["saldo"];
                           // response = MapToValue(reader);
                        }
                    }






                    /*int fila = cmd.ExecuteNonQuery();
                    if (fila>0)
                    {
                        saldo = ((float)cmd.Parameters["@saldo"].Value);
                    }*/

                }

            }




                return response;
        }

        
    }
}
