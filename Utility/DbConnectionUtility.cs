using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Utility
{
    static class DbConnectionUtility
    {
        private static IConfiguration _iconfiguration;

        static DbConnectionUtility()
        {
            GetAppSettings();
        }

        static void GetAppSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _iconfiguration = builder.Build();
        }

        public static string GetConnectionString()
        {
            return _iconfiguration.GetConnectionString("LocalConnectionString");
        }

        public static SqlConnection GetSqlConnectionObject()
        {
            SqlConnection sqlConn = new SqlConnection(GetConnectionString());
            return sqlConn;
        }
    }
}
