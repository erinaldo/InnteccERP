using System;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraSplashScreen;
using Log4NetLibrary;
using Utilities;

namespace WinFormsApp
{
    static class Program
    {

        public static ILogService LogService;
        private static string _appSkinStyle;
        private static UsuarioIngresoFrm _usuarioIngresoFrm;
        private static CacheObjects _cacheObjects;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ApplicationOnThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

            SplashScreenManager.RegisterUserSkins(typeof (DevExpress.UserSkins.BonusSkins).Assembly);

            SplashScreenManager.ShowForm(typeof (SplashScreenFrm),false,false);

            _appSkinStyle = ConfigurationManager.AppSettings["AppSkinStyle"];

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();

            string typeDataBase = ConfigurationManager.AppSettings.Get("TypeDataBase");
            IConnectionUtil connectionUtil = null;

            switch (typeDataBase.ToLower())
            {
                case "postgresql":
                    connectionUtil = new NpgsqlConnectionUtil();
                    break;
                case "sqlserver":
                    connectionUtil = new SqlServerConnectionUtil();
                    break;
            }

            if (connectionUtil != null)
            {
                if (!connectionUtil.CheckConnectionString())
                {
                    return; 
                }
            }

            string versionApp = ConfigurationManager.AppSettings.Get("VersionApp");

            switch (versionApp)
            {
                case "PRINCIPAL":
                    UserLookAndFeel.Default.SetSkinStyle(_appSkinStyle);
                    break;
                case "CLINICA":
                    UserLookAndFeel.Default.SetSkinStyle("Office 2007 Green");
                    break;

            }
            

            CacheObjects cacheObjects = new CacheObjects();
            _cacheObjects = cacheObjects;
            _cacheObjects.Inicializar();

            SplashScreenManager.CloseForm();

            SessionApp.SucursalSel = null;
            SessionApp.EmpresaSel = null;
            SessionApp.UsuarioSel = null;
            SessionApp.GrupoUsarioSel = null;
            SessionApp.EmpleadoSel = null;
            SessionApp.VersionApp = versionApp;

            _usuarioIngresoFrm = new UsuarioIngresoFrm();
            if (_usuarioIngresoFrm.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            switch (versionApp)
            {
                case "PRINCIPAL":
                    Application.Run(new Principal());
                    break;
                case "CLINICA":
                    Application.Run(new ModuloClinica());
                    break;

            }                                    
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = (Exception) e.ExceptionObject;
            LogService = new FileLogService(typeof(Program));
            LogService.Error(ex.Message);
            LogService.Info(ex.StackTrace);

            ErrorUtility.DisplayOptionsButton = false;
            ErrorUtility.EnableSendMail = false;
            ErrorUtility.EnableWriteLog = false;
            ErrorUtility.Exception = ex;
            ErrorUtility.Form = null;
            ErrorUtility.ShowError();
        }

        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            LogService = new FileLogService(typeof(Program));
            LogService.Error(e.Exception.Message);
            LogService.Info(e.Exception.StackTrace);

            ErrorUtility.DisplayOptionsButton = false;
            ErrorUtility.EnableSendMail = false;
            ErrorUtility.EnableWriteLog = false;
            ErrorUtility.Exception = e.Exception;
            ErrorUtility.Form = null;
            ErrorUtility.ShowError();
        }
    }
}