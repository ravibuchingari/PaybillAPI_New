namespace PaybillWinApp
{
    partial class InputForm
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
            LblInput = new Label();
            panel1 = new Panel();
            TxtInput = new TextBox();
            ButtonClose = new Button();
            BtnOK = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // LblInput
            // 
            LblInput.AutoSize = true;
            LblInput.ForeColor = Color.White;
            LblInput.Location = new Point(30, 28);
            LblInput.Name = "LblInput";
            LblInput.Size = new Size(55, 20);
            LblInput.TabIndex = 0;
            LblInput.Text = "label1";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(TxtInput);
            panel1.Location = new Point(30, 51);
            panel1.Name = "panel1";
            panel1.Size = new Size(577, 46);
            panel1.TabIndex = 1;
            panel1.TabStop = true;
            // 
            // TxtInput
            // 
            TxtInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TxtInput.BorderStyle = BorderStyle.None;
            TxtInput.Location = new Point(11, 12);
            TxtInput.MaxLength = 250;
            TxtInput.Name = "TxtInput";
            TxtInput.Size = new Size(553, 21);
            TxtInput.TabIndex = 0;
            // 
            // ButtonClose
            // 
            ButtonClose.BackColor = Color.Green;
            ButtonClose.FlatStyle = FlatStyle.System;
            ButtonClose.ForeColor = Color.White;
            ButtonClose.Location = new Point(487, 125);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(120, 48);
            ButtonClose.TabIndex = 16;
            ButtonClose.Text = "Cance&l";
            ButtonClose.UseVisualStyleBackColor = false;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // BtnOK
            // 
            BtnOK.BackColor = Color.Green;
            BtnOK.FlatStyle = FlatStyle.System;
            BtnOK.ForeColor = Color.White;
            BtnOK.Location = new Point(364, 125);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(120, 48);
            BtnOK.TabIndex = 15;
            BtnOK.Text = "&OK";
            BtnOK.UseVisualStyleBackColor = false;
            BtnOK.Click += BtnOK_Click;
            // 
            // InputForm
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(637, 206);
            Controls.Add(ButtonClose);
            Controls.Add(BtnOK);
            Controls.Add(panel1);
            Controls.Add(LblInput);
            Font = new Font("Roboto", 10.2F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "InputForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "InputForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblInput;
        private Panel panel1;
        private TextBox TxtInput;
        private Button ButtonClose;
        private Button BtnOK;
    }
}