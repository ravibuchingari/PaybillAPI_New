namespace PaybillWinApp
{
    partial class ServerForm
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
            TextBoxApiUrl = new TextBox();
            panel1 = new Panel();
            button1 = new Button();
            ButtonClose = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 89);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 0;
            label1.Text = "Server Url";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto Black", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(29, 33);
            label2.Name = "label2";
            label2.Size = new Size(240, 29);
            label2.TabIndex = 4;
            label2.Text = "Server Configuration";
            // 
            // TextBoxApiUrl
            // 
            TextBoxApiUrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxApiUrl.BorderStyle = BorderStyle.None;
            TextBoxApiUrl.Location = new Point(12, 13);
            TextBoxApiUrl.Name = "TextBoxApiUrl";
            TextBoxApiUrl.Size = new Size(630, 21);
            TextBoxApiUrl.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(TextBoxApiUrl);
            panel1.Location = new Point(31, 116);
            panel1.Name = "panel1";
            panel1.Size = new Size(654, 47);
            panel1.TabIndex = 6;
            // 
            // button1
            // 
            button1.BackColor = Color.Green;
            button1.FlatStyle = FlatStyle.System;
            button1.ForeColor = Color.White;
            button1.Location = new Point(442, 202);
            button1.Name = "button1";
            button1.Size = new Size(120, 40);
            button1.TabIndex = 1;
            button1.Text = "Con&fig";
            button1.UseVisualStyleBackColor = false;
            button1.Click += ButtonSet_Click;
            // 
            // ButtonClose
            // 
            ButtonClose.BackColor = Color.Green;
            ButtonClose.FlatStyle = FlatStyle.System;
            ButtonClose.ForeColor = Color.White;
            ButtonClose.Location = new Point(565, 202);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(120, 40);
            ButtonClose.TabIndex = 2;
            ButtonClose.Text = "&Close";
            ButtonClose.UseVisualStyleBackColor = false;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(722, 280);
            Controls.Add(ButtonClose);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Roboto", 10.2F);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Name = "ServerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ServerForm";
            Load += ServerForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox TextBoxApiUrl;
        private Panel panel1;
        private Button button1;
        private Button ButtonClose;
    }
}