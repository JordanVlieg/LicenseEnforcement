using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseEnforcement;

namespace LicenceEnforcement
{
    public partial class PurchaseForm : Form
    {
        public PurchaseForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cxbPaymentInfo.SelectedItem != null)
            {
                if (cxbLicenseDuration.SelectedItem != null)
                {

                    LicenseConfirm.GenerateLicense(3);
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
