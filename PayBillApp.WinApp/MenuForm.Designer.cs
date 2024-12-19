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
            this.lbnDismiss = new System.Windows.Forms.LinkLabel();
            this.btnViewSales = new System.Windows.Forms.Button();
            this.btnLoadUtilities = new System.Windows.Forms.Button();
            this.lbnMinimise = new System.Windows.Forms.LinkLabel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbnDismiss
            // 
            this.lbnDismiss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbnDismiss.AutoSize = true;
            this.lbnDismiss.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbnDismiss.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lbnDismiss.LinkColor = System.Drawing.Color.DarkRed;
            this.lbnDismiss.Location = new System.Drawing.Point(378, 350);
            this.lbnDismiss.Name = "lbnDismiss";
            this.lbnDismiss.Size = new System.Drawing.Size(66, 19);
            this.lbnDismiss.TabIndex = 3;
            this.lbnDismiss.TabStop = true;
            this.lbnDismiss.Text = "Dismiss";
            this.lbnDismiss.Click += new System.EventHandler(this.CloseMenu_Click);
            // 
            // btnViewSales
            // 
            this.btnViewSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnViewSales.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnViewSales.ForeColor = System.Drawing.Color.White;
            this.btnViewSales.Location = new System.Drawing.Point(28, 65);
            this.btnViewSales.Name = "btnViewSales";
            this.btnViewSales.Size = new System.Drawing.Size(416, 65);
            this.btnViewSales.TabIndex = 0;
            this.btnViewSales.Text = "VIEW SALES";
            this.btnViewSales.UseVisualStyleBackColor = false;
            this.btnViewSales.Click += new System.EventHandler(this.BtnViewSales_Click);
            // 
            // btnLoadUtilities
            // 
            this.btnLoadUtilities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnLoadUtilities.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLoadUtilities.ForeColor = System.Drawing.Color.White;
            this.btnLoadUtilities.Location = new System.Drawing.Point(28, 144);
            this.btnLoadUtilities.Name = "btnLoadUtilities";
            this.btnLoadUtilities.Size = new System.Drawing.Size(416, 65);
            this.btnLoadUtilities.TabIndex = 1;
            this.btnLoadUtilities.Text = "LOAD UTILITIES";
            this.btnLoadUtilities.UseVisualStyleBackColor = false;
            this.btnLoadUtilities.Click += new System.EventHandler(this.BtnLoadUtilities_Click);
            // 
            // lbnMinimise
            // 
            this.lbnMinimise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbnMinimise.AutoSize = true;
            this.lbnMinimise.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbnMinimise.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lbnMinimise.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbnMinimise.Location = new System.Drawing.Point(28, 350);
            this.lbnMinimise.Name = "lbnMinimise";
            this.lbnMinimise.Size = new System.Drawing.Size(74, 19);
            this.lbnMinimise.TabIndex = 4;
            this.lbnMinimise.TabStop = true;
            this.lbnMinimise.Text = "Minimize";
            this.lbnMinimise.Click += new System.EventHandler(this.LbnMinimise_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.lblUserName.Location = new System.Drawing.Point(21, 22);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(430, 27);
            this.lblUserName.TabIndex = 5;
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnReset.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(28, 224);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(416, 65);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "RESET SALES FORM";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(-10, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(0, 0);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.TabStop = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(475, 394);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lbnMinimise);
            this.Controls.Add(this.btnLoadUtilities);
            this.Controls.Add(this.btnViewSales);
            this.Controls.Add(this.lbnDismiss);
            this.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Menu_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lbnDismiss;
        private System.Windows.Forms.Button btnViewSales;
        private System.Windows.Forms.Button btnLoadUtilities;
        private System.Windows.Forms.LinkLabel lbnMinimise;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCancel;
    }
}