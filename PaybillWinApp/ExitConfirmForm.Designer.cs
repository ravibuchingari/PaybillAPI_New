namespace PayBillApp.WinApp
{
    partial class ExitConfirmForm
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
            label1 = new Label();
            btnNo = new Button();
            btnYes = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 18F);
            label1.Location = new Point(26, 34);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(455, 37);
            label1.TabIndex = 0;
            label1.Text = "Are you sure do you want to exit?";
            // 
            // btnNo
            // 
            btnNo.BackColor = SystemColors.ActiveBorder;
            btnNo.Font = new Font("Roboto", 10F, FontStyle.Bold);
            btnNo.ForeColor = Color.White;
            btnNo.Location = new Point(412, 111);
            btnNo.Margin = new Padding(4);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(104, 58);
            btnNo.TabIndex = 1;
            btnNo.Text = "NO";
            btnNo.UseVisualStyleBackColor = false;
            btnNo.Click += BtnCancel_Click;
            // 
            // btnYes
            // 
            btnYes.BackColor = Color.Green;
            btnYes.Font = new Font("Roboto", 10F, FontStyle.Bold);
            btnYes.ForeColor = Color.White;
            btnYes.Location = new Point(530, 111);
            btnYes.Margin = new Padding(4);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(104, 58);
            btnYes.TabIndex = 1;
            btnYes.Text = "YES";
            btnYes.UseVisualStyleBackColor = false;
            btnYes.Click += BtnConfirm_Click;
            // 
            // ExitConfirmForm
            // 
            AcceptButton = btnYes;
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            CancelButton = btnNo;
            ClientSize = new Size(654, 189);
            ControlBox = false;
            Controls.Add(btnYes);
            Controls.Add(btnNo);
            Controls.Add(label1);
            Font = new Font("Roboto", 14.25F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(6, 5, 6, 5);
            Name = "ExitConfirmForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Paint += ExitConfirm_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
    }
}