using System.Configuration;
using System.Data.SqlClient;
using Npgsql;

namespace Utilities
{
    public class DatosServidor
    {
        public string NombreBaseDeDato { get; set; }
        public string Servidor { get; set; }
        public string TypeDataBase { get; set; }
        public string ConnectionString { get; set; }

        public DatosServidor()
        {
            TypeDataBase = ConfigurationManager.AppSettings.Get("TypeDataBase");
            ConnectionString = ConnectionStringManager.GetFirstConnectionString();
        }

        public void ObtenerDatosServidor()
        {

            switch (TypeDataBase.ToLower())
            {
                case "postgresql":
                    var builderPostgreSql = new NpgsqlConnectionStringBuilder(ConnectionString);
                    Servidor = builderPostgreSql.Host;
                    NombreBaseDeDato = builderPostgreSql.Database;

                    break;
                case "sqlserver":
                    var builderSqlServer = new SqlConnectionStringBuilder(ConnectionString);
                    Servidor = builderSqlServer.DataSource;
                    NombreBaseDeDato = builderSqlServer.InitialCatalog;
                    break;
            }  
        }
    }
}