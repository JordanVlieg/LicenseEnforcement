namespace LicenseEnforcement
{
    partial class PurchaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cxbPaymentInfo = new System.Windows.Forms.ComboBox();
            this.cxbLicenseDuration = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cxbPaymentInfo
            // 
            this.cxbPaymentInfo.FormattingEnabled = true;
            this.cxbPaymentInfo.Location = new System.Drawing.Point(90, 58);
            this.cxbPaymentInfo.Name = "cxbPaymentInfo";
            this.cxbPaymentInfo.Size = new System.Drawing.Size(126, 21);
            this.cxbPaymentInfo.TabIndex = 0;
            // 
            // cxbLicenseDuration
            // 
            this.cxbLicenseDuration.FormattingEnabled = true;
            this.cxbLicenseDuration.Location = new System.Drawing.Point(90, 155);
            this.cxbLicenseDuration.Name = "cxbLicenseDuration";
            this.cxbLicenseDuration.Size = new System.Drawing.Size(126, 21);
            this.cxbLicenseDuration.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Payment Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "License Duration";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Purchase";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 277);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cxbLicenseDuration);
            this.Controls.Add(this.cxbPaymentInfo);
            this.Name = "PurchaseForm";
            this.Text = "PurchaseForm";
            this.Load += new System.EventHandler(this.PurchaseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cxbPaymentInfo;
        private System.Windows.Forms.ComboBox cxbLicenseDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}