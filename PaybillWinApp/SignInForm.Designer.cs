namespace PaybillWinApp
{
    partial class SignInForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignInForm));
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            TxtUserId = new TextBox();
            panel2 = new Panel();
            TxtPassword = new TextBox();
            BtnClose = new Button();
            BtnSignIn = new Button();
            LinkLabelServerConfig = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 161);
            label1.Name = "label1";
            label1.Size = new Size(57, 19);
            label1.TabIndex = 0;
            label1.Text = "User Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 245);
            label2.Name = "label2";
            label2.Size = new Size(79, 19);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(147, 38);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(213, 71);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(TxtUserId);
            panel1.Location = new Point(36, 185);
            panel1.Name = "panel1";
            panel1.Size = new Size(433, 46);
            panel1.TabIndex = 0;
            panel1.TabStop = true;
            panel1.Click += panel1_Click;
            // 
            // TxtUserId
            // 
            TxtUserId.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TxtUserId.BorderStyle = BorderStyle.None;
            TxtUserId.Location = new Point(12, 13);
            TxtUserId.MaxLength = 30;
            TxtUserId.Name = "TxtUserId";
            TxtUserId.Size = new Size(406, 20);
            TxtUserId.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(TxtPassword);
            panel2.Location = new Point(36, 269);
            panel2.Name = "panel2";
            panel2.Size = new Size(433, 46);
            panel2.TabIndex = 1;
            panel2.Click += panel2_Click;
            // 
            // TxtPassword
            // 
            TxtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TxtPassword.BorderStyle = BorderStyle.None;
            TxtPassword.Location = new Point(12, 13);
            TxtPassword.MaxLength = 50;
            TxtPassword.Name = "TxtPassword";
            TxtPassword.Size = new Size(407, 20);
            TxtPassword.TabIndex = 0;
            TxtPassword.UseSystemPasswordChar = true;
            // 
            // BtnClose
            // 
            BtnClose.BackColor = Color.Green;
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(359, 357);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(110, 44);
            BtnClose.TabIndex = 3;
            BtnClose.Text = "&Close";
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += ButtonClose_Click;
            // 
            // BtnSignIn
            // 
            BtnSignIn.BackColor = Color.Green;
            BtnSignIn.ForeColor = Color.White;
            BtnSignIn.Location = new Point(243, 357);
            BtnSignIn.Name = "BtnSignIn";
            BtnSignIn.Size = new Size(110, 44);
            BtnSignIn.TabIndex = 2;
            BtnSignIn.Text = "Login";
            BtnSignIn.UseVisualStyleBackColor = false;
            BtnSignIn.Click += ButtonLogin_Click;
            // 
            // LinkLabelServerConfig
            // 
            LinkLabelServerConfig.AutoSize = true;
            LinkLabelServerConfig.Location = new Point(36, 370);
            LinkLabelServerConfig.Name = "LinkLabelServerConfig";
            LinkLabelServerConfig.Size = new Size(103, 19);
            LinkLabelServerConfig.TabIndex = 8;
            LinkLabelServerConfig.TabStop = true;
            LinkLabelServerConfig.Text = "Config Server";
            LinkLabelServerConfig.Click += LinkLabelServerConfig_Click;
            // 
            // SignInForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 447);
            ControlBox = false;
            Controls.Add(LinkLabelServerConfig);
            Controls.Add(BtnClose);
            Controls.Add(BtnSignIn);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            Name = "SignInForm";
            Padding = new Padding(3, 61, 3, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += FormLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Panel panel1;
        private TextBox TxtUserId;
        private Panel panel2;
        private TextBox TxtPassword;
        private Button BtnClose;
        private Button BtnSignIn;
        private LinkLabel LinkLabelServerConfig;
    }
}
