using System;
using ServiceStack;

namespace DataObjects
{
    public static class ServiceStackHelper
    {
        static ServiceStackHelper()
        {
            var instance = new MyNet40PclExport();
            PclExport.Instance = instance;
            Net40PclExport.Provider = instance;
            Licensing.RegisterLicense(string.Empty);
        }

        public static void Help()
        {

        }

        private class MyNet40PclExport : Net40PclExport
        {
            public override LicenseKey VerifyLicenseKeyText(string licenseKeyText)
            {
                return new LicenseKey { Expiry = DateTime.MaxValue, Hash = string.Empty, Name = "Micro4Dev", Ref = "1", Type = LicenseType.Enterprise };
            }
        }
    }
}