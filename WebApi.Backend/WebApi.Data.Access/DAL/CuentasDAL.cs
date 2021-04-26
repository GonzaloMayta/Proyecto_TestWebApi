using System.Threading.Tasks;
using WebApi.Models.Cuenta;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Configuration;

using System.IO;

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
        public static int Inserta(CuentaModels c)
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
                return i;
            }
        }


        
    }
}
