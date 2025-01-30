namespace PaybillWinApp.RegisterForms
{
    partial class OTPValidationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OTPValidationForm));
            label2 = new Label();
            LblBusinessType = new Label();
            LblClientName = new Label();
            LblMobile = new Label();
            LblAddress = new Label();
            LblEmail = new Label();
            TxtOTP = new TextBox();
            label1 = new Label();
            ButtonClose = new Button();
            BtnVerify = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            LblApiUrl = new Label();
            PicEditApiUrl = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PicEditApiUrl).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto Black", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(31, 33);
            label2.Name = "label2";
            label2.Size = new Size(157, 29);
            label2.TabIndex = 5;
            label2.Text = "Client Profile";
            // 
            // LblBusinessType
            // 
            LblBusinessType.BackColor = Color.White;
            LblBusinessType.BorderStyle = BorderStyle.FixedSingle;
            LblBusinessType.FlatStyle = FlatStyle.Popup;
            LblBusinessType.Location = new Point(38, 121);
            LblBusinessType.Name = "LblBusinessType";
            LblBusinessType.Padding = new Padding(10);
            LblBusinessType.Size = new Size(463, 44);
            LblBusinessType.TabIndex = 6;
            LblBusinessType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblClientName
            // 
            LblClientName.BackColor = Color.White;
            LblClientName.BorderStyle = BorderStyle.FixedSingle;
            LblClientName.FlatStyle = FlatStyle.Popup;
            LblClientName.Location = new Point(38, 201);
            LblClientName.Name = "LblClientName";
            LblClientName.Padding = new Padding(10);
            LblClientName.Size = new Size(463, 44);
            LblClientName.TabIndex = 7;
            LblClientName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblMobile
            // 
            LblMobile.BackColor = Color.White;
            LblMobile.BorderStyle = BorderStyle.FixedSingle;
            LblMobile.FlatStyle = FlatStyle.Popup;
            LblMobile.Location = new Point(38, 281);
            LblMobile.Name = "LblMobile";
            LblMobile.Padding = new Padding(10);
            LblMobile.Size = new Size(463, 44);
            LblMobile.TabIndex = 8;
            LblMobile.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblAddress
            // 
            LblAddress.BackColor = Color.White;
            LblAddress.BorderStyle = BorderStyle.FixedSingle;
            LblAddress.FlatStyle = FlatStyle.Popup;
            LblAddress.Location = new Point(539, 121);
            LblAddress.Name = "LblAddress";
            LblAddress.Padding = new Padding(10);
            LblAddress.Size = new Size(463, 124);
            LblAddress.TabIndex = 9;
            // 
            // LblEmail
            // 
            LblEmail.BackColor = Color.White;
            LblEmail.BorderStyle = BorderStyle.FixedSingle;
            LblEmail.FlatStyle = FlatStyle.Popup;
            LblEmail.Location = new Point(38, 360);
            LblEmail.Name = "LblEmail";
            LblEmail.Padding = new Padding(10);
            LblEmail.Size = new Size(463, 44);
            LblEmail.TabIndex = 10;
            LblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TxtOTP
            // 
            TxtOTP.BackColor = SystemColors.Info;
            TxtOTP.BorderStyle = BorderStyle.FixedSingle;
            TxtOTP.Font = new Font("Roboto", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtOTP.Location = new Point(539, 360);
            TxtOTP.MaxLength = 6;
            TxtOTP.Name = "TxtOTP";
            TxtOTP.Size = new Size(214, 44);
            TxtOTP.TabIndex = 0;
            TxtOTP.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(539, 335);
            label1.Name = "label1";
            label1.Size = new Size(42, 20);
            label1.TabIndex = 12;
            label1.Text = "OTP";
            // 
            // ButtonClose
            // 
            ButtonClose.BackColor = Color.Green;
            ButtonClose.FlatStyle = FlatStyle.System;
            ButtonClose.ForeColor = Color.White;
            ButtonClose.Location = new Point(882, 357);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(120, 48);
            ButtonClose.TabIndex = 14;
            ButtonClose.Text = "&Close";
            ButtonClose.UseVisualStyleBackColor = false;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // BtnVerify
            // 
            BtnVerify.BackColor = Color.Green;
            BtnVerify.FlatStyle = FlatStyle.System;
            BtnVerify.ForeColor = Color.White;
            BtnVerify.Location = new Point(759, 357);
            BtnVerify.Name = "BtnVerify";
            BtnVerify.Size = new Size(120, 48);
            BtnVerify.TabIndex = 13;
            BtnVerify.Text = "&Verify";
            BtnVerify.UseVisualStyleBackColor = false;
            BtnVerify.Click += BtnVerify_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 96);
            label3.Name = "label3";
            label3.Size = new Size(118, 20);
            label3.TabIndex = 15;
            label3.Text = "Business Type";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 176);
            label4.Name = "label4";
            label4.Size = new Size(101, 20);
            label4.TabIndex = 16;
            label4.Text = "Client Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 256);
            label5.Name = "label5";
            label5.Size = new Size(61, 20);
            label5.TabIndex = 17;
            label5.Text = "Mobile";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(38, 335);
            label6.Name = "label6";
            label6.Size = new Size(51, 20);
            label6.TabIndex = 18;
            label6.Text = "Email";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(539, 96);
            label7.Name = "label7";
            label7.Size = new Size(73, 20);
            label7.TabIndex = 19;
            label7.Text = "Address";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(539, 256);
            label8.Name = "label8";
            label8.Size = new Size(61, 20);
            label8.TabIndex = 21;
            label8.Text = "API Url";
            // 
            // LblApiUrl
            // 
            LblApiUrl.BackColor = Color.White;
            LblApiUrl.BorderStyle = BorderStyle.FixedSingle;
            LblApiUrl.FlatStyle = FlatStyle.Popup;
            LblApiUrl.Location = new Point(539, 281);
            LblApiUrl.Name = "LblApiUrl";
            LblApiUrl.Padding = new Padding(10);
            LblApiUrl.Size = new Size(413, 44);
            LblApiUrl.TabIndex = 22;
            LblApiUrl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PicEditApiUrl
            // 
            PicEditApiUrl.Image = (Image)resources.GetObject("PicEditApiUrl.Image");
            PicEditApiUrl.Location = new Point(958, 281);
            PicEditApiUrl.Name = "PicEditApiUrl";
            PicEditApiUrl.Size = new Size(44, 44);
            PicEditApiUrl.SizeMode = PictureBoxSizeMode.StretchImage;
            PicEditApiUrl.TabIndex = 23;
            PicEditApiUrl.TabStop = false;
            PicEditApiUrl.Click += PicEditApiUrl_Click;
            // 
            // OTPValidationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1048, 452);
            Controls.Add(PicEditApiUrl);
            Controls.Add(LblApiUrl);
            Controls.Add(label8);
            Controls.Add(TxtOTP);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(ButtonClose);
            Controls.Add(BtnVerify);
            Controls.Add(label1);
            Controls.Add(LblEmail);
            Controls.Add(LblAddress);
            Controls.Add(LblMobile);
            Controls.Add(LblClientName);
            Controls.Add(LblBusinessType);
            Controls.Add(label2);
            Font = new Font("Roboto", 10.2F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "OTPValidationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OTPValidationForm";
            ((System.ComponentModel.ISupportInitialize)PicEditApiUrl).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label LblBusinessType;
        private Label LblClientName;
        private Label LblMobile;
        private Label LblAddress;
        private Label LblEmail;
        private TextBox TxtOTP;
        private Label label1;
        private Button ButtonClose;
        private Button BtnVerify;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label LblApiUrl;
        private PictureBox PicEditApiUrl;
    }
}