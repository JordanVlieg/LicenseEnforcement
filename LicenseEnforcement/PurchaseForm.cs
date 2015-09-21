using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LicenseEnforcement
{
    public partial class PurchaseForm : Form
    {
        public PurchaseForm()
        {
            InitializeComponent();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (cxbPaymentInfo.SelectedItem != null)
            {
                if (cxbLicenseDuration.SelectedItem != null)
                {
                    LicenseConfirm.GenerateLicense(Int32.Parse(cxbLicenseDuration.Text.Substring(0, cxbLicenseDuration.Text.IndexOf("m"))));
                    Close();
                }
            }
            
        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            List<Int32> paymentInfoInts = new List<Int32>{1, 2, 3, 4, 5, 6, 7, 8, 9};
            List<string> licenseDurations = new List<string> {"1 month", "3 months", "6 months", "12 months"};
            cxbPaymentInfo.DataSource = paymentInfoInts;
            cxbLicenseDuration.DataSource = licenseDurations;
        }
    }
}
