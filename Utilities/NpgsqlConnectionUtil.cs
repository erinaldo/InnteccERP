using System.Configuration;
using DevExpress.XtraSplashScreen;
//using Log4NetLibrary;
using Npgsql;

namespace Utilities
{
    public class NpgsqlConnectionUtil : IConnectionUtil
    {
        private string _connectionStringVerification;
        public bool CheckConnectionString()
        {
            bool estadoConexion;
            _connectionStringVerification = Cryptography.DecryptStringAes(ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString);
            
            var connection = new NpgsqlConnection(_connectionStringVerification);

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