using System;
using System.Windows.Forms;

namespace LicenseEnforcement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //LicenseConfirm.GenerateLicense(3);
            //LicenseConfirm.VerifyLicense();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EnterLicensePage());
        }
    }
}
