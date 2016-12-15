using System;
using System.Configuration;
using System.Data;
using Utilities;

namespace DbNetLink.Data
{
    public class HelperDb
    {
        private string TypeDataBase { get; set; }
        private static string ConnectionString { get; set; }
        public HelperDb()
        {
            ConnectionString = Cryptography.DecryptStringAes(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString);
            TypeDataBase = ConfigurationManager.AppSettings.Get("TypeDataBase");
        }
        public DataTable SqlConsulta(string nameRelation,string whereList, string ordersList,string fieldsList)
        {

            if (string.IsNullOrEmpty(nameRelation))
            {
                throw new ArgumentException("nameTable");
            }

            string conditionsOrder = string.Empty;

            if (!string.IsNullOrEmpty(whereList))
            {
                conditionsOrder = " where " + whereList;
            }

            if (!string.IsNullOrEmpty(ordersList))
            {
                conditionsOrder = conditionsOrder + " order by " + ordersList;
            }

            string listFields = fieldsList ?? "*";


            string sql = string.Format("select {0} from {1} {2}", listFields, nameRelation, conditionsOrder);

            DataTable dt = null;
            switch (TypeDataBase.ToLower())
            {
                case "postgresql":
                    dt = NpgsqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql).Tables[0];
                    break;
                case "sqlserver":
                    dt = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql).Tables[0];
                    break;
            }
            return dt;
        }
        public DataSet SqlConsultaDs(string nameRelation, string whereList, string ordersList, string fieldsList)
        {

            if (string.IsNullOrEmpty(nameRelation))
            {
                throw new ArgumentException("nameTable");
            }

            string conditionsOrder = string.Empty;

            if (!string.IsNullOrEmpty(whereList))
            {
                conditionsOrder = " where " + whereList;
            }

            if (!string.IsNullOrEmpty(ordersList))
            {
                conditionsOrder = conditionsOrder + " order by " + ordersList;
            }

            string listFields = fieldsList ?? "*";


            string sql = string.Format("select {0} from {1} {2}", listFields, nameRelation, conditionsOrder);

            DataSet ds = null;
            switch (TypeDataBase.ToLower())
            {
                case "postgresql":
                    ds = NpgsqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql);
                    break;
                case "sqlserver":
                    ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql);
                    break;
            }
            return ds;
        }
        public DataTable SqlConsulta(string connectionString, string nameRelation, string whereList, string ordersList, string fieldsList)
        {
            if (string.IsNullOrEmpty(nameRelation))
            {
                throw new ArgumentException("nameTable");
            }
            string conditionsOrder = string.Empty;

            if (!string.IsNullOrEmpty(whereList))
            {
                conditionsOrder = " where " + whereList;
            }
            if (!string.IsNullOrEmpty(ordersList))
            {
                conditionsOrder = conditionsOrder + " order by " + ordersList;
            }
            string listFields = fieldsList ?? "*";
            string sql = string.Format("select {0} from {1} {2}", listFields, nameRelation, conditionsOrder);
            DataTable dt = null;
            switch (TypeDataBase.ToLower())
            {
                case "postgresql":
                    dt = NpgsqlHelper.ExecuteDataset(connectionString, CommandType.Text, sql).Tables[0];
                    break;
                case "sqlserver":
                    dt = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sql).Tables[0];
                    break;
            }
            return dt;
        }
        public DateTime FechaActualServidor()
        {
            string sqlQuery = string.Empty;

            switch (TypeDataBase.ToLower())
            {
                case "postgresql":
                    sqlQuery = "select now() as fechaservidor";
                    break;

                case "sqlserver":
                    sqlQuery = "select getdate() as fechaservidor";
                    break;
            }
            DateTime fechaServidor = (DateTime)NpgsqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, sqlQuery);
            return fechaServidor;
        }
        public DataTable ExecuteStoreProcedure(string sqlQuery, params object[] parameterValues)
        {
            DataTable dt = null;
            switch (TypeDataBase.ToLower())
            {
                case "postgresql":
                    dt = NpgsqlHelper.ExecuteDataset(ConnectionString, sqlQuery, parameterValues).Tables[0];
                    break;

                case "sqlserver":
                    dt = SqlHelper.ExecuteDataset(ConnectionString, sqlQuery, parameterValues).Tables[0];
                    break;
            }
            return dt;
        }
        public DataSet ExecuteStoreProcedureDs(string sqlQuery, params object[] parameterValues)
        {
            DataSet ds = null;
            switch (TypeDataBase.ToLower())
            {
                case "postgresql":
                    ds = NpgsqlHelper.ExecuteDataset(ConnectionString, sqlQuery, parameterValues);
                    break;

                case "sqlserver":
                    ds = SqlHelper.ExecuteDataset(ConnectionString, sqlQuery, parameterValues);
                    break;
            }
            return ds;
        }
        public IDataReader ExecuteStoreProcedureDr(string sqlQuery, params object[] parameterValues)
        {
            IDataReader dr = null;
            switch (TypeDataBase.ToLower())
            {
                case "postgresql":
                    dr = NpgsqlHelper.ExecuteReader(ConnectionString, sqlQuery, parameterValues);
                    break;
                case "sqlserver":
                    dr = SqlHelper.ExecuteReader(ConnectionString, sqlQuery, parameterValues);
                    break;
            }
            return dr;
        }
    }
}
