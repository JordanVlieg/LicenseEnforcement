using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using LicenseEnforcement;

namespace LicenceEnforcement
{
    public partial class EnterLicencePage : Form
    {
        public EnterLicencePage()
        {
            InitializeComponent();
        }


        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            DisplayValidity();
        }

        private void txtDay_TextChanged(object sender, EventArgs e)
        {
            DisplayValidity();
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            DisplayValidity();
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            DisplayValidity();
        }

        private void DisplayValidity()
        {
            if (LicenseConfirm.VerifyLicense())
            {
                lblInvalid.Visible = false;
                lblValid.Visible = true;
            }
            else
            {
                lblValid.Visible = false;
                lblInvalid.Visible = true;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ConfirmationForm confirmationForm = new ConfirmationForm();
            confirmationForm.ShowDialog();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm();
            purchaseForm.ShowDialog();
        }

        private void EnterLicencePage_Load(object sender, EventArgs e)
        {
            XmlDocument licenseFile = new XmlDocument();
            licenseFile.Load(Environment.CurrentDirectory + @"\licenseinfo.xml");
            string licenseKey = licenseFile.DocumentElement.SelectSingleNode(@"/LicenseInfo/KEY").InnerText;
            txtMonth.Text = licenseKey.Substring(0, 2);
            txtDay.Text = licenseKey.Substring(3, 2);
            txtYear.Text = licenseKey.Substring(6, 4);
            txtKey.Text = licenseKey.Substring(10, 10);

        }
    }
}
