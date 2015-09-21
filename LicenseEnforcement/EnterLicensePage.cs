using System;
using System.Windows.Forms;

namespace LicenseEnforcement
{
    public partial class EnterLicensePage : Form
    {
        public EnterLicensePage()
        {
            InitializeComponent();
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
    }
}
