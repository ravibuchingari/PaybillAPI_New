namespace PayBillApp.WinApp
{
    partial class ViewSalesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.gvwSales = new System.Windows.Forms.DataGridView();
            this.sales_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment_type_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upi_type_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_incl_gst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit_item = new System.Windows.Forms.DataGridViewLinkColumn();
            this.is_locked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSummary = new System.Windows.Forms.Button();
            this.pnlSummary = new PayBillApp.WinApp.UserControls.PanelRounded();
            this.gvwSummary = new System.Windows.Forms.DataGridView();
            this.Trans_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trans_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvwSales)).BeginInit();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvwSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(839, 39);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd-MM-yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Roboto Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(15, 39);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(169, 33);
            this.dtpFromDate.TabIndex = 1;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd-MM-yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Roboto Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(202, 39);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(169, 33);
            this.dtpToDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(202, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "To Date";
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(388, 37);
            this.btnView.Margin = new System.Windows.Forms.Padding(4);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(104, 35);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "VIE&W";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // gvwSales
            // 
            this.gvwSales.AllowUserToAddRows = false;
            this.gvwSales.AllowUserToDeleteRows = false;
            this.gvwSales.AllowUserToResizeRows = false;
            this.gvwSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvwSales.BackgroundColor = System.Drawing.Color.White;
            this.gvwSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvwSales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gvwSales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvwSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvwSales.ColumnHeadersHeight = 30;
            this.gvwSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvwSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sales_id,
            this.invoice_date,
            this.payment_type_desc,
            this.upi_type_desc,
            this.quantity,
            this.total_incl_gst,
            this.edit_item,
            this.is_locked});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvwSales.DefaultCellStyle = dataGridViewCellStyle6;
            this.gvwSales.GridColor = System.Drawing.Color.WhiteSmoke;
            this.gvwSales.Location = new System.Drawing.Point(15, 81);
            this.gvwSales.MultiSelect = false;
            this.gvwSales.Name = "gvwSales";
            this.gvwSales.ReadOnly = true;
            this.gvwSales.RowHeadersVisible = false;
            this.gvwSales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gvwSales.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.gvwSales.RowTemplate.Height = 40;
            this.gvwSales.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gvwSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwSales.Size = new System.Drawing.Size(928, 509);
            this.gvwSales.TabIndex = 7;
            this.gvwSales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvwSales_CellContentClick);
            this.gvwSales.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GvwSales_KeyDown);
            // 
            // sales_id
            // 
            this.sales_id.DataPropertyName = "sales_id";
            this.sales_id.FillWeight = 38.69155F;
            this.sales_id.HeaderText = "Inv.No";
            this.sales_id.Name = "sales_id";
            this.sales_id.ReadOnly = true;
            this.sales_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sales_id.Width = 157;
            // 
            // invoice_date
            // 
            this.invoice_date.DataPropertyName = "invoice_date";
            dataGridViewCellStyle2.NullValue = null;
            this.invoice_date.DefaultCellStyle = dataGridViewCellStyle2;
            this.invoice_date.FillWeight = 38.69155F;
            this.invoice_date.HeaderText = "Inv.Date";
            this.invoice_date.Name = "invoice_date";
            this.invoice_date.ReadOnly = true;
            this.invoice_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.invoice_date.Width = 157;
            // 
            // payment_type_desc
            // 
            this.payment_type_desc.DataPropertyName = "payment_type_desc";
            this.payment_type_desc.FillWeight = 38.69155F;
            this.payment_type_desc.HeaderText = "Payment Type";
            this.payment_type_desc.Name = "payment_type_desc";
            this.payment_type_desc.ReadOnly = true;
            this.payment_type_desc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.payment_type_desc.Width = 158;
            // 
            // upi_type_desc
            // 
            this.upi_type_desc.DataPropertyName = "upi_type_desc";
            this.upi_type_desc.FillWeight = 38.69155F;
            this.upi_type_desc.HeaderText = "UPI Type";
            this.upi_type_desc.Name = "upi_type_desc";
            this.upi_type_desc.ReadOnly = true;
            this.upi_type_desc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.upi_type_desc.Width = 157;
            // 
            // quantity
            // 
            this.quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.quantity.DataPropertyName = "quantity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.quantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.quantity.FillWeight = 80F;
            this.quantity.HeaderText = "Qty";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            this.quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quantity.Width = 80;
            // 
            // total_incl_gst
            // 
            this.total_incl_gst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.total_incl_gst.DataPropertyName = "total_incl_gst";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.total_incl_gst.DefaultCellStyle = dataGridViewCellStyle4;
            this.total_incl_gst.FillWeight = 120F;
            this.total_incl_gst.HeaderText = "Amount";
            this.total_incl_gst.Name = "total_incl_gst";
            this.total_incl_gst.ReadOnly = true;
            this.total_incl_gst.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.total_incl_gst.Width = 120;
            // 
            // edit_item
            // 
            this.edit_item.DataPropertyName = "edit_item";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.edit_item.DefaultCellStyle = dataGridViewCellStyle5;
            this.edit_item.FillWeight = 24.41985F;
            this.edit_item.HeaderText = "";
            this.edit_item.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.edit_item.Name = "edit_item";
            this.edit_item.ReadOnly = true;
            this.edit_item.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.edit_item.VisitedLinkColor = System.Drawing.Color.Blue;
            this.edit_item.Width = 99;
            // 
            // is_locked
            // 
            this.is_locked.DataPropertyName = "is_locked";
            this.is_locked.HeaderText = "is_locked";
            this.is_locked.Name = "is_locked";
            this.is_locked.ReadOnly = true;
            this.is_locked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.is_locked.Visible = false;
            // 
            // btnSummary
            // 
            this.btnSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnSummary.FlatAppearance.BorderSize = 0;
            this.btnSummary.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSummary.ForeColor = System.Drawing.Color.White;
            this.btnSummary.Location = new System.Drawing.Point(500, 37);
            this.btnSummary.Margin = new System.Windows.Forms.Padding(4);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(104, 35);
            this.btnSummary.TabIndex = 5;
            this.btnSummary.Text = "SU&MMARY";
            this.btnSummary.UseVisualStyleBackColor = false;
            this.btnSummary.Visible = false;
            this.btnSummary.Click += new System.EventHandler(this.BtnSummary_Click);
            // 
            // pnlSummary
            // 
            this.pnlSummary.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlSummary.BackColor = System.Drawing.SystemColors.Info;
            this.pnlSummary.BorderColor = System.Drawing.Color.RosyBrown;
            this.pnlSummary.Controls.Add(this.gvwSummary);
            this.pnlSummary.Edge = 20;
            this.pnlSummary.Location = new System.Drawing.Point(288, 175);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(357, 245);
            this.pnlSummary.TabIndex = 8;
            this.pnlSummary.Visible = false;
            // 
            // gvwSummary
            // 
            this.gvwSummary.AllowUserToAddRows = false;
            this.gvwSummary.AllowUserToDeleteRows = false;
            this.gvwSummary.AllowUserToResizeRows = false;
            this.gvwSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvwSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvwSummary.BackgroundColor = System.Drawing.SystemColors.Info;
            this.gvwSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvwSummary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gvwSummary.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvwSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gvwSummary.ColumnHeadersHeight = 30;
            this.gvwSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvwSummary.ColumnHeadersVisible = false;
            this.gvwSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Trans_Type,
            this.Trans_Amount});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvwSummary.DefaultCellStyle = dataGridViewCellStyle10;
            this.gvwSummary.GridColor = System.Drawing.Color.WhiteSmoke;
            this.gvwSummary.Location = new System.Drawing.Point(18, 17);
            this.gvwSummary.MultiSelect = false;
            this.gvwSummary.Name = "gvwSummary";
            this.gvwSummary.ReadOnly = true;
            this.gvwSummary.RowHeadersVisible = false;
            this.gvwSummary.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gvwSummary.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.gvwSummary.RowTemplate.Height = 40;
            this.gvwSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
            this.gvwSummary.Size = new System.Drawing.Size(320, 211);
            this.gvwSummary.TabIndex = 8;
            // 
            // Trans_Type
            // 
            this.Trans_Type.DataPropertyName = "Trans_Type";
            this.Trans_Type.HeaderText = "upi_type_desc";
            this.Trans_Type.Name = "Trans_Type";
            this.Trans_Type.ReadOnly = true;
            this.Trans_Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Trans_Amount
            // 
            this.Trans_Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Trans_Amount.DataPropertyName = "Trans_Amount";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.Trans_Amount.DefaultCellStyle = dataGridViewCellStyle9;
            this.Trans_Amount.FillWeight = 120F;
            this.Trans_Amount.HeaderText = "Amount";
            this.Trans_Amount.Name = "Trans_Amount";
            this.Trans_Amount.ReadOnly = true;
            this.Trans_Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Trans_Amount.Width = 120;
            // 
            // ViewSalesForm
            // 
            this.AcceptButton = this.btnView;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(958, 603);
            this.ControlBox = false;
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.btnSummary);
            this.Controls.Add(this.gvwSales);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ViewSalesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ViewSalesForms";
            this.Load += new System.EventHandler(this.ViewSalesForms_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewSalesForms_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.gvwSales)).EndInit();
            this.pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvwSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DataGridView gvwSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn sales_date;
        private System.Windows.Forms.Button btnSummary;
        private UserControls.PanelRounded pnlSummary;
        private System.Windows.Forms.DataGridView gvwSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn sales_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment_type_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn upi_type_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_incl_gst;
        private System.Windows.Forms.DataGridViewLinkColumn edit_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_locked;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trans_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trans_Amount;
    }
}