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
            TextBoxServerUrl = new MaterialSkin.Controls.MaterialTextBox2();
            ButtonClose = new MaterialSkin.Controls.MaterialButton();
            ButtonSet = new MaterialSkin.Controls.MaterialButton();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 89);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 0;
            label1.Text = "Server Url";
            // 
            // TextBoxServerUrl
            // 
            TextBoxServerUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxServerUrl.AnimateReadOnly = false;
            TextBoxServerUrl.BackgroundImageLayout = ImageLayout.None;
            TextBoxServerUrl.CharacterCasing = CharacterCasing.Normal;
            TextBoxServerUrl.Depth = 0;
            TextBoxServerUrl.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            TextBoxServerUrl.HideSelection = true;
            TextBoxServerUrl.LeadingIcon = null;
            TextBoxServerUrl.Location = new Point(29, 114);
            TextBoxServerUrl.MaxLength = 250;
            TextBoxServerUrl.MouseState = MaterialSkin.MouseState.OUT;
            TextBoxServerUrl.Name = "TextBoxServerUrl";
            TextBoxServerUrl.PasswordChar = '\0';
            TextBoxServerUrl.PrefixSuffixText = null;
            TextBoxServerUrl.ReadOnly = false;
            TextBoxServerUrl.RightToLeft = RightToLeft.No;
            TextBoxServerUrl.SelectedText = "";
            TextBoxServerUrl.SelectionLength = 0;
            TextBoxServerUrl.SelectionStart = 0;
            TextBoxServerUrl.ShortcutsEnabled = true;
            TextBoxServerUrl.Size = new Size(656, 48);
            TextBoxServerUrl.TabIndex = 1;
            TextBoxServerUrl.TabStop = false;
            TextBoxServerUrl.TextAlign = HorizontalAlignment.Left;
            TextBoxServerUrl.TrailingIcon = null;
            TextBoxServerUrl.UseSystemPasswordChar = false;
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
            ButtonClose.Location = new Point(583, 207);
            ButtonClose.Margin = new Padding(3, 6, 3, 6);
            ButtonClose.MouseState = MaterialSkin.MouseState.HOVER;
            ButtonClose.Name = "ButtonClose";
            ButtonClose.NoAccentTextColor = Color.Empty;
            ButtonClose.Size = new Size(100, 36);
            ButtonClose.TabIndex = 2;
            ButtonClose.Text = "&Close";
            ButtonClose.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            ButtonClose.UseAccentColor = true;
            ButtonClose.UseVisualStyleBackColor = true;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // ButtonSet
            // 
            ButtonSet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonSet.AutoSize = false;
            ButtonSet.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ButtonSet.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            ButtonSet.Depth = 0;
            ButtonSet.HighEmphasis = true;
            ButtonSet.Icon = null;
            ButtonSet.Location = new Point(475, 207);
            ButtonSet.Margin = new Padding(3, 6, 3, 6);
            ButtonSet.MouseState = MaterialSkin.MouseState.HOVER;
            ButtonSet.Name = "ButtonSet";
            ButtonSet.NoAccentTextColor = Color.Empty;
            ButtonSet.Size = new Size(100, 36);
            ButtonSet.TabIndex = 3;
            ButtonSet.Text = "Config";
            ButtonSet.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            ButtonSet.UseAccentColor = true;
            ButtonSet.UseVisualStyleBackColor = true;
            ButtonSet.Click += ButtonSet_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto Black", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 33);
            label2.Name = "label2";
            label2.Size = new Size(240, 29);
            label2.TabIndex = 4;
            label2.Text = "Server Configuration";
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = ButtonClose;
            ClientSize = new Size(722, 280);
            Controls.Add(label2);
            Controls.Add(ButtonSet);
            Controls.Add(ButtonClose);
            Controls.Add(TextBoxServerUrl);
            Controls.Add(label1);
            Font = new Font("Roboto", 10.2F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ServerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ServerForm";
            Load += ServerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private MaterialSkin.Controls.MaterialTextBox2 TextBoxServerUrl;
        private MaterialSkin.Controls.MaterialButton ButtonClose;
        private MaterialSkin.Controls.MaterialButton ButtonSet;
        private Label label2;
    }
}