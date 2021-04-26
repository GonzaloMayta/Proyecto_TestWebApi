using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
//using WebApi.Backend.models;
using WebApp.FrontEnd.Models;

namespace WebApi.Backend.Data
{
    public class CuentaRepository
    {
        private readonly String _connectionString;

        public CuentaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        /*public Task<List<Cuenta>> GetAll()
        {
            throw new NotImplementedException();
        }*/


        public async Task<List<WebApp.FrontEnd.Models.Cuenta>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllValues", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Cuenta>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }
                    return response;
                }

            }


        }


        private Cuenta MapToValue(SqlDataReader reader)
        {
            return new Cuenta()
            {
                NroCuenta = reader["nrocuenta"].ToString(),
                Tipo = reader["tipo"].ToString(),
                Moneda = reader["moneda"].ToString(),
                Nombre = reader["nombre"].ToString(),
                Saldo = (int)reader["saldo"]

            };
        }



     







        /*  1: Inserta una nueva cuenta  ******************************************/
        
        public async Task Insert(Cuenta c)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("adicion", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NRO_CUENTA", c.NroCuenta));
                    cmd.Parameters.Add(new SqlParameter("@tipo", c.Tipo));
                    cmd.Parameters.Add(new SqlParameter("@moneda", c.Moneda));
                    cmd.Parameters.Add(new SqlParameter("@nombre", c.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@saldo", c.Saldo));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return;
                }

            }


        }

    /********************************************************************************************************************/

        //2: Inserta movimiento
        public async Task Movimiento(Movimiento m)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spmovimiento", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NRO_CUENTA", m.NroCuenta));
                    cmd.Parameters.Add(new SqlParameter("@FECHAm", m.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@TIPOm", m.Tipo));
                    cmd.Parameters.Add(new SqlParameter("@IMPORTEm", m.importe));


                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return;
                }

            }

        }



        /*3:TRANSFERENCIAS**************************************************************************************************************/


        public async Task Transferencia(Transferencia t)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("transferencias", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@cuenta1", t.Cuenta1));
                    cmd.Parameters.Add(new SqlParameter("@cuenta2", t.Cuenta2));
                    cmd.Parameters.Add(new SqlParameter("@fecha", t.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@tipo1", t.Tipo1));
                    cmd.Parameters.Add(new SqlParameter("@tipo2", t.Tipo2));
                    cmd.Parameters.Add(new SqlParameter("@monto", t.Importe));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                
              
             }

            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand usuario1 = new SqlCommand("actualizar_saldo", sql))
                {
                    usuario1.CommandType = System.Data.CommandType.StoredProcedure;
                    usuario1.Parameters.Add(new SqlParameter("@cuenta1", t.Cuenta1));
                    await sql.OpenAsync();
                    await usuario1.ExecuteNonQueryAsync();
                }
            }

            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand usuario2 = new SqlCommand("actualizar_saldo", sql))
                {
                    usuario2.CommandType = System.Data.CommandType.StoredProcedure;
                    usuario2.Parameters.Add(new SqlParameter("@cuenta1", t.Cuenta2));
                    await sql.OpenAsync();
                    await usuario2.ExecuteNonQueryAsync();
                }

            }

                return;

        }

        /*4: CONSULTA DE SALDOS **************************************************************************************************************/
    }
}
