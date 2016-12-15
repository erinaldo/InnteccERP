using System.Configuration;
using System.Data.SqlClient;
using DevExpress.XtraSplashScreen;

namespace Utilities
{
    public class SqlServerConnectionUtil : IConnectionUtil
    {
        private string _connectionStringVerification;
        public bool CheckConnectionString()
        {
            bool estadoConexion;
            _connectionStringVerification = Cryptography.DecryptStringAes(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString);

            var connection = new SqlConnection(_connectionStringVerification);

            try
            {
                connection.Open();
                estadoConexion = true;
            }
            catch
            {

                SplashScreenManager.CloseForm();
                var serverConnectionSettingsFrm = new ServerConnectionSettingsFrm();
                serverConnectionSettingsFrm.ShowDialog();
                serverConnectionSettingsFrm.BringToFront();
                if (serverConnectionSettingsFrm.IsConfig)
                {
                    SplashScreenManager.ShowForm(typeof(SplashScreenFrm),false,false);
                    estadoConexion = true;
                }
                else
                {
                    _connectionStringVerification = null;                    
                    estadoConexion = false;
                }
            }
            finally
            {
                connection.Close();
            }
            return estadoConexion;
        }
    }
}