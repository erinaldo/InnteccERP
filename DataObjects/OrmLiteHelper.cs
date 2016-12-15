using System.Configuration;
using ServiceStack.OrmLite;
using Utilities;

namespace DataObjects
{
    public class OrmLiteHelper
    {
        public static OrmLiteConnectionFactory DbFactory { get; set; }

        private static readonly string TypeDataBase = ConfigurationManager.AppSettings.Get("TypeDataBase");
        private static readonly string ConnectionString = Cryptography.DecryptStringAes(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString);
        static OrmLiteHelper()
        {
            ServiceStackHelper.Help();

            switch (TypeDataBase.ToLower())
            {
                case "postgresql":
                    DbFactory = new OrmLiteConnectionFactory(ConnectionString, PostgreSqlDialect.Provider);
                    break;
                case "sqlserver":
                    //DbFactory = new OrmLiteConnectionFactory(ConnectionString, SqlServerDialect.Provider);
                    break;
            }            
            //Debug.WriteLine("Se creo la instancia");
        }
    }
}