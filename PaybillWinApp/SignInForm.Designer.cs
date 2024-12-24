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
            LinkLabelServerConfig = new LinkLabel();
            panel1 = new Panel();
            TextBoxUserId = new TextBox();
            panel2 = new Panel();
            TextBoxPassword = new TextBox();
            ButtonClose = new Button();
            ButtonLogin = new Button();
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
            // LinkLabelServerConfig
            // 
            LinkLabelServerConfig.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LinkLabelServerConfig.AutoSize = true;
            LinkLabelServerConfig.Location = new Point(36, 368);
            LinkLabelServerConfig.Name = "LinkLabelServerConfig";
            LinkLabelServerConfig.Size = new Size(103, 19);
            LinkLabelServerConfig.TabIndex = 2;
            LinkLabelServerConfig.TabStop = true;
            LinkLabelServerConfig.Text = "Server Config";
            LinkLabelServerConfig.Click += LinkLabelServerConfig_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(TextBoxUserId);
            panel1.Location = new Point(36, 185);
            panel1.Name = "panel1";
            panel1.Size = new Size(433, 46);
            panel1.TabIndex = 9;
            // 
            // TextBoxUserId
            // 
            TextBoxUserId.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxUserId.BorderStyle = BorderStyle.None;
            TextBoxUserId.Location = new Point(12, 13);
            TextBoxUserId.MaxLength = 30;
            TextBoxUserId.Name = "TextBoxUserId";
            TextBoxUserId.Size = new Size(406, 20);
            TextBoxUserId.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(TextBoxPassword);
            panel2.Location = new Point(36, 269);
            panel2.Name = "panel2";
            panel2.Size = new Size(433, 46);
            panel2.TabIndex = 10;
            // 
            // TextBoxPassword
            // 
            TextBoxPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxPassword.BorderStyle = BorderStyle.None;
            TextBoxPassword.Location = new Point(12, 13);
            TextBoxPassword.MaxLength = 50;
            TextBoxPassword.Name = "TextBoxPassword";
            TextBoxPassword.Size = new Size(407, 20);
            TextBoxPassword.TabIndex = 0;
            // 
            // ButtonClose
            // 
            ButtonClose.BackColor = Color.Green;
            ButtonClose.FlatStyle = FlatStyle.System;
            ButtonClose.ForeColor = Color.White;
            ButtonClose.Location = new Point(359, 357);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(110, 40);
            ButtonClose.TabIndex = 1;
            ButtonClose.Text = "&Close";
            ButtonClose.UseVisualStyleBackColor = false;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // ButtonLogin
            // 
            ButtonLogin.BackColor = Color.Green;
            ButtonLogin.FlatStyle = FlatStyle.System;
            ButtonLogin.ForeColor = Color.White;
            ButtonLogin.Location = new Point(243, 357);
            ButtonLogin.Name = "ButtonLogin";
            ButtonLogin.Size = new Size(110, 40);
            ButtonLogin.TabIndex = 0;
            ButtonLogin.Text = "Login";
            ButtonLogin.UseVisualStyleBackColor = false;
            // 
            // SignInForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 447);
            ControlBox = false;
            Controls.Add(ButtonClose);
            Controls.Add(ButtonLogin);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(LinkLabelServerConfig);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            FormBorderStyle = FormBorderStyle.None;
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
        private LinkLabel LinkLabelServerConfig;
        private Panel panel1;
        private TextBox TextBoxUserId;
        private Panel panel2;
        private TextBox TextBoxPassword;
        private Button ButtonClose;
        private Button ButtonLogin;
    }
}
