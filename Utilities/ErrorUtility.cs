using System;
using System.Reflection;
using System.Windows.Forms;
using Softgroup.NetError;

namespace Utilities
{
    public class ErrorUtility
    {
        public static bool EnableSendMail { get; set; }
        public static bool EnableWriteLog { get; set; }
        public static bool DisplayOptionsButton { get; set; }
        public static Exception Exception { get; set; }
        public static Form Form { get; set; }


        public static void ShowError()
        {
            License.LicenseName = "Micro4Dev";
            License.LicenseUser = "carlos_z18@msn.com";
            License.LicenseKey = "Y6ASKTV1T9AUXKBJBSFXJ4UYI";

            ErrorInfo.Localize(LocaleStringsEnum.lseButtonContinue, "Continuar");
            ErrorInfo.Localize(LocaleStringsEnum.lseTitle, "Información de error");
            ErrorInfo.OptionsButton = DisplayOptionsButton;
            ErrorInfo.ShowError(Assembly.GetCallingAssembly(), Exception, Form, EnableSendMail, EnableWriteLog);
        }

    }
}
