using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;

namespace Utilities
{
    public class WaitDialogUtil
    {
        public static void CreateWaitDialog()
        {
            SplashScreenManager.ShowForm(typeof(DemoWaitForm), false, false);
        }

        public static void SetWaitDialogCaption(string description)
        {
            if (SplashScreenManager.Default != null)
            {
                SplashScreenManager.Default.SetWaitFormCaption("Espere por favor.");
                SplashScreenManager.Default.SetWaitFormDescription(description);
            }
        }
        public static void CloseForm()
        {
            if (SplashScreenManager.Default != null)
            {
                SplashScreenManager.CloseForm();
            }
        }
    }
}