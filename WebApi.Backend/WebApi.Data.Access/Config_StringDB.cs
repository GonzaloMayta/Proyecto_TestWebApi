using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebApi.Data.Access
{
    public class Config_StringDB
    {
        private static string _connectionString;

        public Config_StringDB()
        {
            var configuracion = GetConfiguration();
            //_connectionString = configuracion.GetConnectionString("DefaultConnection11");
        }
        public static  IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
