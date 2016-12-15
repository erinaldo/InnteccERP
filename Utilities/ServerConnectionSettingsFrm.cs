using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Npgsql;

namespace Utilities
{
    public partial class ServerConnectionSettingsFrm : XtraForm
    {
        public bool IsConfig { get; set; }
        public string TypeDataBase { get; set; }

        public ServerConnectionSettingsFrm()
        {
            InitializeComponent();
            TypeDataBase = ConfigurationManager.AppSettings.Get("TypeDataBase");
            ShowSavedConnectionSettings();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            string connectionString = null;
            switch (TypeDataBase.ToLower())
            {
                case "postgresql":
                    var builderPostgreSql = new NpgsqlConnectionStringBuilder
                    {
                        Host = connectionServerTextEdit.EditValue.ToString(),
                        Database = connectionDatabaseTextEdit.EditValue.ToString(),
                        UserName = connectionUsernameTextEdit.EditValue.ToString(),
                        Password = connectionPasswordTextEdit.EditValue.ToString()
                    };

                    connectionString = string.Format("Server={0};Port=5432;Database={1};User ID={2};Password={3};",
                                                            builderPostgreSql.Host, builderPostgreSql.Database, builderPostgreSql.UserName,
                                                            System.Text.Encoding.UTF8.GetString(builderPostgreSql.PasswordAsByteArray));

                    //Probar cadena de conexion para postgresql
                    try
                    {
                        var connection = new NpgsqlConnection(connectionString);
                        connection.Open();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case "sqlserver":
                    var builderSqlServer = new SqlConnectionStringBuilder
                    {
                        DataSource = connectionServerTextEdit.EditValue.ToString(),
                        InitialCatalog = connectionDatabaseTextEdit.EditValue.ToString(),
                        UserID = connectionUsernameTextEdit.EditValue.ToString(),
                        Password = connectionPasswordTextEdit.EditValue.ToString()
                    };

                    connectionString = string.Format("Server={0};Database={1};User ID={2};Password={3};",
                                                            builderSqlServer.DataSource, builderSqlServer.InitialCatalog, builderSqlServer.UserID,
                                                            builderSqlServer.Password);

                    //Probar cadena de conexion para postgresql
                    try
                    {
                        var connection = new SqlConnection(connectionString);
                        connection.Open();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    break;
            }



            ConnectionStringManager.SaveConnectionString("MainConnection", Cryptography.EncryptStringAes(connectionString));
            ConfigurationManager.RefreshSection("connectionStrings");

            IsConfig = true;
            XtraMessageBox.Show("Se actualizo la información de conexion", "Configuración de conexion", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            Close();
        }

        public static List<string> GetConnectionStringNames()
        {
            Configuration appconfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return (from ConnectionStringSettings cn in appconfig.ConnectionStrings.ConnectionStrings select cn.Name).ToList();
        }

        public static string GetFirstConnectionStringName()
        {
            return GetConnectionStringNames().FirstOrDefault();
        }

        public static string GetFirstConnectionString()
        {
            return ConnectionStringManager.GetConnectionString(GetFirstConnectionStringName());
        }

        private void ShowSavedConnectionSettings()
        {
            switch (TypeDataBase.ToLower())
            {
                case "postgresql":
                    var builderPostgreSql = new NpgsqlConnectionStringBuilder(ConnectionStringManager.GetFirstConnectionString());
                    connectionServerTextEdit.EditValue = builderPostgreSql.Host;
                    connectionDatabaseTextEdit.EditValue = builderPostgreSql.Database;
                    connectionUsernameTextEdit.Text = builderPostgreSql.UserName;
                    connectionPasswordTextEdit.Text = System.Text.Encoding.UTF8.GetString(builderPostgreSql.PasswordAsByteArray);

                    break;
                case "sqlserver":
                    var builderSqlServer = new SqlConnectionStringBuilder(ConnectionStringManager.GetFirstConnectionString());
                    connectionServerTextEdit.EditValue = builderSqlServer.DataSource;
                    connectionDatabaseTextEdit.EditValue = builderSqlServer.InitialCatalog;
                    connectionUsernameTextEdit.Text = builderSqlServer.UserID;
                    connectionPasswordTextEdit.Text = builderSqlServer.Password;

                    break;
            }


        }

        private void ServerConnectionSettingsFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            IsConfig = false;
            Close();
        }

        private void ServerConnectionSettingsFrm_Load(object sender, EventArgs e)
        {
            BringToFront();
        }

    }
}