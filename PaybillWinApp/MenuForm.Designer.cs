namespace PayBillApp.WinApp
{
    partial class MenuForm
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
            lbnDismiss = new LinkLabel();
            btnViewSales = new Button();
            btnLoadUtilities = new Button();
            lblUserName = new Label();
            btnReset = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lbnDismiss
            // 
            lbnDismiss.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbnDismiss.AutoSize = true;
            lbnDismiss.Font = new Font("Roboto", 12F);
            lbnDismiss.LinkBehavior = LinkBehavior.NeverUnderline;
            lbnDismiss.LinkColor = Color.DarkRed;
            lbnDismiss.Location = new Point(980, 640);
            lbnDismiss.Name = "lbnDismiss";
            lbnDismiss.Size = new Size(81, 24);
            lbnDismiss.TabIndex = 3;
            lbnDismiss.TabStop = true;
            lbnDismiss.Text = "Dismiss";
            lbnDismiss.Click += CloseMenu_Click;
            // 
            // btnViewSales
            // 
            btnViewSales.BackColor = Color.Gray;
            btnViewSales.Font = new Font("Roboto", 9.75F, FontStyle.Bold);
            btnViewSales.ForeColor = Color.White;
            btnViewSales.Location = new Point(28, 65);
            btnViewSales.Name = "btnViewSales";
            btnViewSales.Size = new Size(143, 92);
            btnViewSales.TabIndex = 0;
            btnViewSales.Text = "VIEW SALES";
            btnViewSales.UseVisualStyleBackColor = false;
            btnViewSales.Click += BtnViewSales_Click;
            // 
            // btnLoadUtilities
            // 
            btnLoadUtilities.BackColor = Color.Gray;
            btnLoadUtilities.Font = new Font("Roboto", 9.75F, FontStyle.Bold);
            btnLoadUtilities.ForeColor = Color.White;
            btnLoadUtilities.Location = new Point(28, 165);
            btnLoadUtilities.Name = "btnLoadUtilities";
            btnLoadUtilities.Size = new Size(143, 92);
            btnLoadUtilities.TabIndex = 1;
            btnLoadUtilities.Text = "LOAD UTILITIES";
            btnLoadUtilities.UseVisualStyleBackColor = false;
            btnLoadUtilities.Click += BtnLoadUtilities_Click;
            // 
            // lblUserName
            // 
            lblUserName.Font = new Font("Roboto", 12F);
            lblUserName.ForeColor = Color.FromArgb(63, 81, 181);
            lblUserName.Location = new Point(21, 22);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(430, 27);
            lblUserName.TabIndex = 5;
            lblUserName.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.Gray;
            btnReset.Font = new Font("Roboto", 9.75F, FontStyle.Bold);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(28, 266);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(143, 92);
            btnReset.TabIndex = 2;
            btnReset.Text = "RESET SALES FORM";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += BtnReset_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(-10, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(0, 0);
            btnCancel.TabIndex = 7;
            btnCancel.TabStop = false;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(1077, 684);
            ControlBox = false;
            Controls.Add(btnCancel);
            Controls.Add(btnReset);
            Controls.Add(lblUserName);
            Controls.Add(btnLoadUtilities);
            Controls.Add(btnViewSales);
            Controls.Add(lbnDismiss);
            Font = new Font("Roboto", 9.75F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MenuForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "MenuForm";
            Load += MenuForm_Load;
            Paint += Menu_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.LinkLabel lbnDismiss;
        private System.Windows.Forms.Button btnViewSales;
        private System.Windows.Forms.Button btnLoadUtilities;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCancel;
    }
}