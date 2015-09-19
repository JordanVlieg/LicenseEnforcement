using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseEnforcement;

namespace LicenceEnforcement
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
            Application.Run(new EnterLicencePage());
        }
    }
}
