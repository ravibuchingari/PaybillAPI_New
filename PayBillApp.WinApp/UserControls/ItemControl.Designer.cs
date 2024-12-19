namespace PayBillApp.WinApp.UserControls
{
    partial class ItemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lnkModify = new System.Windows.Forms.LinkLabel();
            this.lnkRemove = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDiscountInRs = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblGSTInRS = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblItemId = new System.Windows.Forms.Label();
            this.lblMRP = new System.Windows.Forms.Label();
            this.pnlOutOfStock = new PayBillApp.WinApp.UserControls.PanelRounded();
            this.lblRemaingQuantity = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlOutOfStock.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.lblItemCode, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblItemName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lnkModify, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lnkRemove, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(492, 21);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Font = new System.Drawing.Font("Roboto Light", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblItemCode.Location = new System.Drawing.Point(3, 0);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(0, 15);
            this.lblItemCode.TabIndex = 0;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Roboto Light", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblItemName.Location = new System.Drawing.Point(9, 0);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(0, 15);
            this.lblItemName.TabIndex = 1;
            // 
            // lnkModify
            // 
            this.lnkModify.AutoSize = true;
            this.lnkModify.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkModify.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lnkModify.Location = new System.Drawing.Point(335, 0);
            this.lnkModify.Name = "lnkModify";
            this.lnkModify.Size = new System.Drawing.Size(45, 15);
            this.lnkModify.TabIndex = 2;
            this.lnkModify.TabStop = true;
            this.lnkModify.Text = "Modify";
            // 
            // lnkRemove
            // 
            this.lnkRemove.AutoSize = true;
            this.lnkRemove.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkRemove.LinkColor = System.Drawing.Color.Red;
            this.lnkRemove.Location = new System.Drawing.Point(415, 0);
            this.lnkRemove.Name = "lnkRemove";
            this.lnkRemove.Size = new System.Drawing.Size(54, 15);
            this.lnkRemove.TabIndex = 3;
            this.lnkRemove.TabStop = true;
            this.lnkRemove.Text = "Remove";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Qty";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = ":";
            // 
            // lblQuantity
            // 
            this.lblQuantity.Font = new System.Drawing.Font("Roboto Light", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblQuantity.Location = new System.Drawing.Point(72, 25);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(96, 18);
            this.lblQuantity.TabIndex = 3;
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRate
            // 
            this.lblRate.Location = new System.Drawing.Point(72, 45);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(96, 18);
            this.lblRate.TabIndex = 6;
            this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = ":";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(2, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Rate ₹";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiscountInRs
            // 
            this.lblDiscountInRs.Location = new System.Drawing.Point(72, 65);
            this.lblDiscountInRs.Name = "lblDiscountInRs";
            this.lblDiscountInRs.Size = new System.Drawing.Size(96, 18);
            this.lblDiscountInRs.TabIndex = 9;
            this.lblDiscountInRs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = ":";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(2, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 18);
            this.label7.TabIndex = 7;
            this.label7.Text = "Dis ₹";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(373, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = ":";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(278, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 18);
            this.label8.TabIndex = 10;
            this.label8.Text = "Taxable ₹";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAmount
            // 
            this.lblAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAmount.Location = new System.Drawing.Point(389, 25);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(101, 18);
            this.lblAmount.TabIndex = 12;
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGSTInRS
            // 
            this.lblGSTInRS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGSTInRS.Location = new System.Drawing.Point(389, 45);
            this.lblGSTInRS.Name = "lblGSTInRS";
            this.lblGSTInRS.Size = new System.Drawing.Size(101, 18);
            this.lblGSTInRS.TabIndex = 15;
            this.lblGSTInRS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(373, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 15);
            this.label10.TabIndex = 14;
            this.label10.Text = ":";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Location = new System.Drawing.Point(278, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 18);
            this.label11.TabIndex = 13;
            this.label11.Text = "GST ₹";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.Location = new System.Drawing.Point(389, 65);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(101, 18);
            this.lblTotalAmount.TabIndex = 18;
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(373, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 15);
            this.label12.TabIndex = 17;
            this.label12.Text = ":";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Location = new System.Drawing.Point(278, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 18);
            this.label13.TabIndex = 16;
            this.label13.Text = "Total Amount ₹";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblItemId
            // 
            this.lblItemId.AutoSize = true;
            this.lblItemId.Location = new System.Drawing.Point(191, 68);
            this.lblItemId.Name = "lblItemId";
            this.lblItemId.Size = new System.Drawing.Size(14, 15);
            this.lblItemId.TabIndex = 19;
            this.lblItemId.Text = "0";
            this.lblItemId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblItemId.Visible = false;
            // 
            // lblMRP
            // 
            this.lblMRP.AutoSize = true;
            this.lblMRP.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMRP.ForeColor = System.Drawing.Color.Blue;
            this.lblMRP.Location = new System.Drawing.Point(180, 26);
            this.lblMRP.Name = "lblMRP";
            this.lblMRP.Size = new System.Drawing.Size(28, 14);
            this.lblMRP.TabIndex = 20;
            this.lblMRP.Text = "0.00";
            this.lblMRP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlOutOfStock
            // 
            this.pnlOutOfStock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlOutOfStock.BackColor = System.Drawing.Color.SandyBrown;
            this.pnlOutOfStock.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlOutOfStock.Controls.Add(this.lblRemaingQuantity);
            this.pnlOutOfStock.Controls.Add(this.label9);
            this.pnlOutOfStock.Edge = 40;
            this.pnlOutOfStock.Location = new System.Drawing.Point(141, 20);
            this.pnlOutOfStock.Name = "pnlOutOfStock";
            this.pnlOutOfStock.Size = new System.Drawing.Size(184, 50);
            this.pnlOutOfStock.TabIndex = 22;
            this.pnlOutOfStock.Visible = false;
            // 
            // lblRemaingQuantity
            // 
            this.lblRemaingQuantity.Font = new System.Drawing.Font("Roboto Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRemaingQuantity.ForeColor = System.Drawing.Color.White;
            this.lblRemaingQuantity.Location = new System.Drawing.Point(3, 25);
            this.lblRemaingQuantity.Name = "lblRemaingQuantity";
            this.lblRemaingQuantity.Size = new System.Drawing.Size(178, 18);
            this.lblRemaingQuantity.TabIndex = 1;
            this.lblRemaingQuantity.Text = "You have only 10 number(s)";
            this.lblRemaingQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Roboto Light", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(178, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "OUT OF STOCK";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 1);
            this.panel1.TabIndex = 23;
            // 
            // ItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlOutOfStock);
            this.Controls.Add(this.lblMRP);
            this.Controls.Add(this.lblItemId);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblGSTInRS);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblDiscountInRs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Roboto Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "ItemControl";
            this.Size = new System.Drawing.Size(493, 89);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlOutOfStock.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label lblItemCode;
        internal System.Windows.Forms.Label lblItemName;
        internal System.Windows.Forms.LinkLabel lnkModify;
        internal System.Windows.Forms.LinkLabel lnkRemove;
        internal System.Windows.Forms.Label lblQuantity;
        internal System.Windows.Forms.Label lblRate;
        internal System.Windows.Forms.Label lblDiscountInRs;
        internal System.Windows.Forms.Label lblAmount;
        internal System.Windows.Forms.Label lblGSTInRS;
        internal System.Windows.Forms.Label lblTotalAmount;
        internal System.Windows.Forms.Label lblItemId;
        internal System.Windows.Forms.Label lblMRP;
        private System.Windows.Forms.Label label9;
        internal PanelRounded pnlOutOfStock;
        internal System.Windows.Forms.Label lblRemaingQuantity;
        private System.Windows.Forms.Panel panel1;
    }
}
