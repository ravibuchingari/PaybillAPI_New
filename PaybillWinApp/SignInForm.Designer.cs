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
            TextBoxUserId = new MaterialSkin.Controls.MaterialTextBox2();
            ButtonClose = new MaterialSkin.Controls.MaterialButton();
            ButtonLogin = new MaterialSkin.Controls.MaterialButton();
            label1 = new Label();
            label2 = new Label();
            TextBoxPassword = new MaterialSkin.Controls.MaterialTextBox2();
            pictureBox1 = new PictureBox();
            LinkLabelServerConfig = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // TextBoxUserId
            // 
            TextBoxUserId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxUserId.AnimateReadOnly = false;
            TextBoxUserId.BackgroundImageLayout = ImageLayout.None;
            TextBoxUserId.CharacterCasing = CharacterCasing.Normal;
            TextBoxUserId.Depth = 0;
            TextBoxUserId.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TextBoxUserId.HideSelection = true;
            TextBoxUserId.LeadingIcon = null;
            TextBoxUserId.Location = new Point(41, 184);
            TextBoxUserId.MaxLength = 50;
            TextBoxUserId.MouseState = MaterialSkin.MouseState.OUT;
            TextBoxUserId.Name = "TextBoxUserId";
            TextBoxUserId.PasswordChar = '\0';
            TextBoxUserId.PrefixSuffixText = null;
            TextBoxUserId.ReadOnly = false;
            TextBoxUserId.RightToLeft = RightToLeft.No;
            TextBoxUserId.SelectedText = "";
            TextBoxUserId.SelectionLength = 0;
            TextBoxUserId.SelectionStart = 0;
            TextBoxUserId.ShortcutsEnabled = true;
            TextBoxUserId.Size = new Size(480, 48);
            TextBoxUserId.TabIndex = 1;
            TextBoxUserId.TabStop = false;
            TextBoxUserId.TextAlign = HorizontalAlignment.Left;
            TextBoxUserId.TrailingIcon = null;
            TextBoxUserId.UseSystemPasswordChar = false;
            // 
            // ButtonClose
            // 
            ButtonClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonClose.AutoSize = false;
            ButtonClose.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ButtonClose.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            ButtonClose.Depth = 0;
            ButtonClose.HighEmphasis = true;
            ButtonClose.Icon = null;
            ButtonClose.Location = new Point(421, 370);
            ButtonClose.Margin = new Padding(4, 6, 4, 6);
            ButtonClose.MouseState = MaterialSkin.MouseState.HOVER;
            ButtonClose.Name = "ButtonClose";
            ButtonClose.NoAccentTextColor = Color.Empty;
            ButtonClose.Size = new Size(100, 34);
            ButtonClose.TabIndex = 5;
            ButtonClose.Text = "Close";
            ButtonClose.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            ButtonClose.UseAccentColor = true;
            ButtonClose.UseVisualStyleBackColor = true;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // ButtonLogin
            // 
            ButtonLogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonLogin.AutoSize = false;
            ButtonLogin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ButtonLogin.BackColor = Color.Green;
            ButtonLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            ButtonLogin.Depth = 0;
            ButtonLogin.HighEmphasis = true;
            ButtonLogin.Icon = null;
            ButtonLogin.Location = new Point(312, 370);
            ButtonLogin.Margin = new Padding(4, 6, 4, 6);
            ButtonLogin.MouseState = MaterialSkin.MouseState.HOVER;
            ButtonLogin.Name = "ButtonLogin";
            ButtonLogin.NoAccentTextColor = Color.Empty;
            ButtonLogin.Size = new Size(100, 34);
            ButtonLogin.TabIndex = 4;
            ButtonLogin.Text = "Login";
            ButtonLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            ButtonLogin.UseAccentColor = true;
            ButtonLogin.UseVisualStyleBackColor = false;
            ButtonLogin.Click += ButtonLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 162);
            label1.Name = "label1";
            label1.Size = new Size(57, 19);
            label1.TabIndex = 0;
            label1.Text = "User Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 244);
            label2.Name = "label2";
            label2.Size = new Size(79, 19);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // TextBoxPassword
            // 
            TextBoxPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxPassword.AnimateReadOnly = false;
            TextBoxPassword.BackgroundImageLayout = ImageLayout.None;
            TextBoxPassword.CharacterCasing = CharacterCasing.Normal;
            TextBoxPassword.Depth = 0;
            TextBoxPassword.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TextBoxPassword.HideSelection = true;
            TextBoxPassword.LeadingIcon = null;
            TextBoxPassword.Location = new Point(41, 267);
            TextBoxPassword.MaxLength = 30;
            TextBoxPassword.MouseState = MaterialSkin.MouseState.OUT;
            TextBoxPassword.Name = "TextBoxPassword";
            TextBoxPassword.PasswordChar = '●';
            TextBoxPassword.PrefixSuffixText = null;
            TextBoxPassword.ReadOnly = false;
            TextBoxPassword.RightToLeft = RightToLeft.No;
            TextBoxPassword.SelectedText = "";
            TextBoxPassword.SelectionLength = 0;
            TextBoxPassword.SelectionStart = 0;
            TextBoxPassword.ShortcutsEnabled = true;
            TextBoxPassword.Size = new Size(480, 48);
            TextBoxPassword.TabIndex = 3;
            TextBoxPassword.TabStop = false;
            TextBoxPassword.TextAlign = HorizontalAlignment.Left;
            TextBoxPassword.TrailingIcon = null;
            TextBoxPassword.UseSystemPasswordChar = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(175, 49);
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
            LinkLabelServerConfig.Location = new Point(41, 378);
            LinkLabelServerConfig.Name = "LinkLabelServerConfig";
            LinkLabelServerConfig.Size = new Size(103, 19);
            LinkLabelServerConfig.TabIndex = 8;
            LinkLabelServerConfig.TabStop = true;
            LinkLabelServerConfig.Text = "Server Config";
            LinkLabelServerConfig.Click += LinkLabelServerConfig_Click;
            // 
            // SignInForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = ButtonClose;
            ClientSize = new Size(563, 447);
            ControlBox = false;
            Controls.Add(LinkLabelServerConfig);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(TextBoxPassword);
            Controls.Add(label1);
            Controls.Add(ButtonLogin);
            Controls.Add(ButtonClose);
            Controls.Add(TextBoxUserId);
            Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SignInForm";
            Padding = new Padding(3, 61, 3, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += FormLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaterialSkin.Controls.MaterialTextBox2 TextBoxUserId;
        private MaterialSkin.Controls.MaterialButton ButtonClose;
        private MaterialSkin.Controls.MaterialButton ButtonLogin;
        private Label label1;
        private Label label2;
        private MaterialSkin.Controls.MaterialTextBox2 TextBoxPassword;
        private PictureBox pictureBox1;
        private LinkLabel LinkLabelServerConfig;
    }
}
