using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Utilities
{
    public class ConnectionStringManager
    {
        public static string GetConnectionString(string connectionStringName)
        {
            Configuration appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringSettings connStringSettings = appconfig.ConnectionStrings.ConnectionStrings[connectionStringName];
            return connStringSettings.ConnectionString;
        }

        public static void SaveConnectionString(string connectionStringName, string connectionString)
        {
            Configuration appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            appconfig.ConnectionStrings.ConnectionStrings[connectionStringName].ConnectionString = connectionString;
            appconfig.Save(ConfigurationSaveMode.Modified);
        }

        public static List<string> GetConnectionStringNames()
        {
            Configuration appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var cns = (from ConnectionStringSettings cn in appconfig.ConnectionStrings.ConnectionStrings select cn.Name).ToList();
            cns.RemoveAll(s => s != "MainConnection");

            return cns;
        }

        public static string GetFirstConnectionStringName()
        {
            return GetConnectionStringNames().FirstOrDefault();
        }

        public static string GetFirstConnectionString()
        {
            return Cryptography.DecryptStringAes(GetConnectionString(GetFirstConnectionStringName()));
        }
    }
}