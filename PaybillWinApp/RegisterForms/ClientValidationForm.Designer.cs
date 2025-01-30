namespace PaybillWinApp.RegisterForms
{
    partial class ClientValidationForm
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
            label2 = new Label();
            TxtMobile = new TextBox();
            PnlMobile = new Panel();
            BtnValidate = new Button();
            ButtonClose = new Button();
            PnlMobile.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 89);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 10;
            label1.Text = "Mobile";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto Black", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(29, 33);
            label2.Name = "label2";
            label2.Size = new Size(195, 29);
            label2.TabIndex = 4;
            label2.Text = "Client Validation";
            // 
            // TxtMobile
            // 
            TxtMobile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TxtMobile.BorderStyle = BorderStyle.None;
            TxtMobile.Location = new Point(12, 13);
            TxtMobile.MaxLength = 10;
            TxtMobile.Name = "TxtMobile";
            TxtMobile.Size = new Size(315, 21);
            TxtMobile.TabIndex = 0;
            TxtMobile.KeyDown += TxtMobile_KeyDown;
            TxtMobile.KeyPress += TxtMobile_KeyPress;
            // 
            // PnlMobile
            // 
            PnlMobile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PnlMobile.BackColor = Color.White;
            PnlMobile.BorderStyle = BorderStyle.FixedSingle;
            PnlMobile.Controls.Add(TxtMobile);
            PnlMobile.Location = new Point(32, 116);
            PnlMobile.Name = "PnlMobile";
            PnlMobile.Size = new Size(341, 47);
            PnlMobile.TabIndex = 0;
            PnlMobile.TabStop = true;
            PnlMobile.Click += PnlMobile_Click;
            // 
            // BtnValidate
            // 
            BtnValidate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnValidate.BackColor = Color.Green;
            BtnValidate.FlatStyle = FlatStyle.System;
            BtnValidate.ForeColor = Color.White;
            BtnValidate.Location = new Point(129, 202);
            BtnValidate.Name = "BtnValidate";
            BtnValidate.Size = new Size(120, 40);
            BtnValidate.TabIndex = 2;
            BtnValidate.Text = "&Validate";
            BtnValidate.UseVisualStyleBackColor = false;
            BtnValidate.Click += ButtonSet_Click;
            // 
            // ButtonClose
            // 
            ButtonClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonClose.BackColor = Color.Green;
            ButtonClose.FlatStyle = FlatStyle.System;
            ButtonClose.ForeColor = Color.White;
            ButtonClose.Location = new Point(252, 202);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(120, 40);
            ButtonClose.TabIndex = 3;
            ButtonClose.Text = "&Close";
            ButtonClose.UseVisualStyleBackColor = false;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // ClientValidationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 280);
            Controls.Add(ButtonClose);
            Controls.Add(BtnValidate);
            Controls.Add(PnlMobile);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Roboto", 10.2F);
            ForeColor = Color.Black;
            Name = "ClientValidationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ServerForm";
            Load += ServerForm_Load;
            PnlMobile.ResumeLayout(false);
            PnlMobile.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox TxtMobile;
        private Panel PnlMobile;
        private Button BtnValidate;
        private Button ButtonClose;
    }
}