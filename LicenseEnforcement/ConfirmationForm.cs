using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace LicenseEnforcement
{
    public partial class ConfirmationForm : Form
    {
        public ConfirmationForm()
        {
            InitializeComponent();
        }

        private void ConfirmationForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Environment.CurrentDirectory + @"\licenseinfo.xml"))
            {
                lblValidity.Text = @"Please purchase a license";
            }
            else
            {
                XmlDocument licenseFile = new XmlDocument();
                licenseFile.Load(Environment.CurrentDirectory + @"\licenseinfo.xml");
                string licenseKey = licenseFile.DocumentElement.SelectSingleNode(@"/LicenseInfo/KEY").InnerText;
                string licenseExpiry = licenseKey.Substring(0, licenseKey.LastIndexOf(@"/") + 5);
                lblExpiryDate.Text = licenseExpiry;
                
                if (Convert.ToDateTime(licenseExpiry) < DateTime.Today)
                {
                    if (!LicenseConfirm.VerifyLicense())
                    {
                        lblValidity.Text = @"License Key Is Invalid";
                    }
                    else
                    {
                        lblValidity.Text = @"License is Expired";
                    }
                }
            }
            
        }
    }
}
