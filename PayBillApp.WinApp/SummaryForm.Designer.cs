namespace PayBillApp.WinApp
{
    partial class SummaryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SummaryForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrintInvoice = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnChangeUPIType = new System.Windows.Forms.Button();
            this.lblUPIType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnChangePaymentType = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPaymentType = new System.Windows.Forms.Label();
            this.pnlPaymentTypes = new System.Windows.Forms.Panel();
            this.gvwPaymentTypes = new System.Windows.Forms.DataGridView();
            this.ValueID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPaymentTypeClose = new System.Windows.Forms.Button();
            this.pnlUPIType = new System.Windows.Forms.Panel();
            this.gvwUPITypes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCloseUPIType = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblITems = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblGSTValue = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblTaxableAmount = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lblBalanceLable = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lblTotalAmount2 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtTransactionNo = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlPaymentTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvwPaymentTypes)).BeginInit();
            this.pnlUPIType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvwUPITypes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCancel.Location = new System.Drawing.Point(20, 434);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintInvoice.BackColor = System.Drawing.Color.Transparent;
            this.btnPrintInvoice.FlatAppearance.BorderSize = 0;
            this.btnPrintInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintInvoice.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPrintInvoice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnPrintInvoice.Location = new System.Drawing.Point(474, 435);
            this.btnPrintInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(130, 27);
            this.btnPrintInvoice.TabIndex = 2;
            this.btnPrintInvoice.Text = "&PRINT INVOICE";
            this.btnPrintInvoice.UseVisualStyleBackColor = false;
            this.btnPrintInvoice.Click += new System.EventHandler(this.BtnPrintInvoice_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnSearchCustomer, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCustomer, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnChangeUPIType, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblUPIType, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnChangePaymentType, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPaymentType, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(21, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(585, 127);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSearchCustomer.FlatAppearance.BorderSize = 0;
            this.btnSearchCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchCustomer.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.btnSearchCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnSearchCustomer.Location = new System.Drawing.Point(422, 84);
            this.btnSearchCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(163, 26);
            this.btnSearchCustomer.TabIndex = 2;
            this.btnSearchCustomer.Text = "Search C&ustomer";
            this.btnSearchCustomer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnSearchCustomer.UseVisualStyleBackColor = false;
            this.btnSearchCustomer.Click += new System.EventHandler(this.BtnSearchCustomer_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblCustomer.Location = new System.Drawing.Point(126, 84);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(37, 15);
            this.lblCustomer.TabIndex = 10;
            this.lblCustomer.Text = "None";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(108, 84);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 18);
            this.label8.TabIndex = 9;
            this.label8.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(2, 84);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 18);
            this.label7.TabIndex = 8;
            this.label7.Text = "Customer";
            // 
            // btnChangeUPIType
            // 
            this.btnChangeUPIType.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeUPIType.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChangeUPIType.Enabled = false;
            this.btnChangeUPIType.FlatAppearance.BorderSize = 0;
            this.btnChangeUPIType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeUPIType.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.btnChangeUPIType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnChangeUPIType.Location = new System.Drawing.Point(422, 42);
            this.btnChangeUPIType.Margin = new System.Windows.Forms.Padding(0);
            this.btnChangeUPIType.Name = "btnChangeUPIType";
            this.btnChangeUPIType.Size = new System.Drawing.Size(163, 26);
            this.btnChangeUPIType.TabIndex = 1;
            this.btnChangeUPIType.Text = "Change UP&I Type";
            this.btnChangeUPIType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnChangeUPIType.UseVisualStyleBackColor = false;
            this.btnChangeUPIType.Click += new System.EventHandler(this.BtnChangeUPIType_Click);
            // 
            // lblUPIType
            // 
            this.lblUPIType.AutoSize = true;
            this.lblUPIType.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblUPIType.Location = new System.Drawing.Point(126, 42);
            this.lblUPIType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUPIType.Name = "lblUPIType";
            this.lblUPIType.Size = new System.Drawing.Size(46, 19);
            this.lblUPIType.TabIndex = 6;
            this.lblUPIType.Text = "None";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(108, 42);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(2, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "UPI Type";
            // 
            // btnChangePaymentType
            // 
            this.btnChangePaymentType.BackColor = System.Drawing.Color.Transparent;
            this.btnChangePaymentType.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChangePaymentType.FlatAppearance.BorderSize = 0;
            this.btnChangePaymentType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePaymentType.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.btnChangePaymentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnChangePaymentType.Location = new System.Drawing.Point(422, 0);
            this.btnChangePaymentType.Margin = new System.Windows.Forms.Padding(0);
            this.btnChangePaymentType.Name = "btnChangePaymentType";
            this.btnChangePaymentType.Size = new System.Drawing.Size(163, 26);
            this.btnChangePaymentType.TabIndex = 0;
            this.btnChangePaymentType.Text = "Change Pa&yment Type";
            this.btnChangePaymentType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnChangePaymentType.UseVisualStyleBackColor = false;
            this.btnChangePaymentType.Click += new System.EventHandler(this.BtnChangePaymentType_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payment Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = ":";
            // 
            // lblPaymentType
            // 
            this.lblPaymentType.AutoSize = true;
            this.lblPaymentType.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblPaymentType.Location = new System.Drawing.Point(126, 0);
            this.lblPaymentType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaymentType.Name = "lblPaymentType";
            this.lblPaymentType.Size = new System.Drawing.Size(45, 19);
            this.lblPaymentType.TabIndex = 2;
            this.lblPaymentType.Text = "Cash";
            // 
            // pnlPaymentTypes
            // 
            this.pnlPaymentTypes.BackColor = System.Drawing.Color.White;
            this.pnlPaymentTypes.Controls.Add(this.gvwPaymentTypes);
            this.pnlPaymentTypes.Controls.Add(this.btnPaymentTypeClose);
            this.pnlPaymentTypes.Location = new System.Drawing.Point(0, 0);
            this.pnlPaymentTypes.Name = "pnlPaymentTypes";
            this.pnlPaymentTypes.Size = new System.Drawing.Size(0, 0);
            this.pnlPaymentTypes.TabIndex = 3;
            this.pnlPaymentTypes.Visible = false;
            // 
            // gvwPaymentTypes
            // 
            this.gvwPaymentTypes.AllowUserToAddRows = false;
            this.gvwPaymentTypes.AllowUserToDeleteRows = false;
            this.gvwPaymentTypes.AllowUserToResizeRows = false;
            this.gvwPaymentTypes.BackgroundColor = System.Drawing.Color.White;
            this.gvwPaymentTypes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvwPaymentTypes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gvwPaymentTypes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvwPaymentTypes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvwPaymentTypes.ColumnHeadersHeight = 30;
            this.gvwPaymentTypes.ColumnHeadersVisible = false;
            this.gvwPaymentTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ValueID,
            this.ValueName});
            this.gvwPaymentTypes.GridColor = System.Drawing.Color.WhiteSmoke;
            this.gvwPaymentTypes.Location = new System.Drawing.Point(110, 53);
            this.gvwPaymentTypes.MultiSelect = false;
            this.gvwPaymentTypes.Name = "gvwPaymentTypes";
            this.gvwPaymentTypes.ReadOnly = true;
            this.gvwPaymentTypes.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.gvwPaymentTypes.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gvwPaymentTypes.RowTemplate.Height = 40;
            this.gvwPaymentTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwPaymentTypes.Size = new System.Drawing.Size(402, 377);
            this.gvwPaymentTypes.TabIndex = 14;
            this.gvwPaymentTypes.DoubleClick += new System.EventHandler(this.GvwPaymentTypes_DoubleClick);
            this.gvwPaymentTypes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GvwPaymentTypes_KeyDown);
            // 
            // ValueID
            // 
            this.ValueID.DataPropertyName = "ValueID";
            this.ValueID.HeaderText = "ItemId";
            this.ValueID.Name = "ValueID";
            this.ValueID.ReadOnly = true;
            this.ValueID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ValueID.Visible = false;
            // 
            // ValueName
            // 
            this.ValueName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValueName.DataPropertyName = "ValueName";
            this.ValueName.HeaderText = "Name";
            this.ValueName.Name = "ValueName";
            this.ValueName.ReadOnly = true;
            this.ValueName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnPaymentTypeClose
            // 
            this.btnPaymentTypeClose.AutoSize = true;
            this.btnPaymentTypeClose.FlatAppearance.BorderSize = 0;
            this.btnPaymentTypeClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaymentTypeClose.Image = ((System.Drawing.Image)(resources.GetObject("btnPaymentTypeClose.Image")));
            this.btnPaymentTypeClose.Location = new System.Drawing.Point(683, 10);
            this.btnPaymentTypeClose.Name = "btnPaymentTypeClose";
            this.btnPaymentTypeClose.Size = new System.Drawing.Size(30, 30);
            this.btnPaymentTypeClose.TabIndex = 0;
            this.btnPaymentTypeClose.UseVisualStyleBackColor = true;
            this.btnPaymentTypeClose.Click += new System.EventHandler(this.BtnPaymentTypeClose_Click);
            // 
            // pnlUPIType
            // 
            this.pnlUPIType.BackColor = System.Drawing.Color.White;
            this.pnlUPIType.Controls.Add(this.gvwUPITypes);
            this.pnlUPIType.Controls.Add(this.btnCloseUPIType);
            this.pnlUPIType.Location = new System.Drawing.Point(0, 0);
            this.pnlUPIType.Name = "pnlUPIType";
            this.pnlUPIType.Size = new System.Drawing.Size(0, 0);
            this.pnlUPIType.TabIndex = 4;
            this.pnlUPIType.Visible = false;
            // 
            // gvwUPITypes
            // 
            this.gvwUPITypes.AllowUserToAddRows = false;
            this.gvwUPITypes.AllowUserToDeleteRows = false;
            this.gvwUPITypes.AllowUserToResizeRows = false;
            this.gvwUPITypes.BackgroundColor = System.Drawing.Color.White;
            this.gvwUPITypes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvwUPITypes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gvwUPITypes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvwUPITypes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvwUPITypes.ColumnHeadersHeight = 30;
            this.gvwUPITypes.ColumnHeadersVisible = false;
            this.gvwUPITypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.gvwUPITypes.GridColor = System.Drawing.Color.WhiteSmoke;
            this.gvwUPITypes.Location = new System.Drawing.Point(111, 52);
            this.gvwUPITypes.MultiSelect = false;
            this.gvwUPITypes.Name = "gvwUPITypes";
            this.gvwUPITypes.ReadOnly = true;
            this.gvwUPITypes.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.gvwUPITypes.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gvwUPITypes.RowTemplate.Height = 40;
            this.gvwUPITypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwUPITypes.Size = new System.Drawing.Size(402, 377);
            this.gvwUPITypes.TabIndex = 14;
            this.gvwUPITypes.DoubleClick += new System.EventHandler(this.GvwUPITypes_DoubleClick);
            this.gvwUPITypes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GvwUPITypes_KeyDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ValueID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ItemId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ValueName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnCloseUPIType
            // 
            this.btnCloseUPIType.AutoSize = true;
            this.btnCloseUPIType.FlatAppearance.BorderSize = 0;
            this.btnCloseUPIType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseUPIType.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseUPIType.Image")));
            this.btnCloseUPIType.Location = new System.Drawing.Point(683, 10);
            this.btnCloseUPIType.Name = "btnCloseUPIType";
            this.btnCloseUPIType.Size = new System.Drawing.Size(30, 30);
            this.btnCloseUPIType.TabIndex = 0;
            this.btnCloseUPIType.UseVisualStyleBackColor = true;
            this.btnCloseUPIType.Click += new System.EventHandler(this.BtnCloseUPIType_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(23, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Item(s)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(110, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = ":";
            // 
            // lblITems
            // 
            this.lblITems.Location = new System.Drawing.Point(128, 157);
            this.lblITems.Name = "lblITems";
            this.lblITems.Size = new System.Drawing.Size(109, 19);
            this.lblITems.TabIndex = 7;
            this.lblITems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(110, 186);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(12, 18);
            this.label11.TabIndex = 9;
            this.label11.Text = ":";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(23, 186);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 19);
            this.label12.TabIndex = 8;
            this.label12.Text = "Quantity";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiscount
            // 
            this.lblDiscount.Location = new System.Drawing.Point(128, 243);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(109, 19);
            this.lblDiscount.TabIndex = 16;
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(110, 243);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(12, 18);
            this.label14.TabIndex = 15;
            this.label14.Text = ":";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(23, 243);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 19);
            this.label15.TabIndex = 14;
            this.label15.Text = "Discount";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(110, 214);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(12, 18);
            this.label17.TabIndex = 12;
            this.label17.Text = ":";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(23, 214);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 19);
            this.label18.TabIndex = 11;
            this.label18.Text = "Amount";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalAmount.Location = new System.Drawing.Point(485, 242);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(121, 19);
            this.lblTotalAmount.TabIndex = 28;
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(464, 242);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(12, 18);
            this.label20.TabIndex = 27;
            this.label20.Text = ":";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(331, 242);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(125, 19);
            this.label21.TabIndex = 26;
            this.label21.Text = "Total Amount";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGSTValue
            // 
            this.lblGSTValue.Location = new System.Drawing.Point(485, 213);
            this.lblGSTValue.Name = "lblGSTValue";
            this.lblGSTValue.Size = new System.Drawing.Size(121, 19);
            this.lblGSTValue.TabIndex = 25;
            this.lblGSTValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(464, 213);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(12, 18);
            this.label23.TabIndex = 24;
            this.label23.Text = ":";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(331, 213);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(125, 19);
            this.label24.TabIndex = 23;
            this.label24.Text = "GST Value";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTaxableAmount
            // 
            this.lblTaxableAmount.Location = new System.Drawing.Point(485, 185);
            this.lblTaxableAmount.Name = "lblTaxableAmount";
            this.lblTaxableAmount.Size = new System.Drawing.Size(121, 19);
            this.lblTaxableAmount.TabIndex = 22;
            this.lblTaxableAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(464, 185);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(12, 18);
            this.label26.TabIndex = 21;
            this.label26.Text = ":";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(331, 185);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(125, 19);
            this.label27.TabIndex = 20;
            this.label27.Text = "Taxable Amount";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBalance
            // 
            this.lblBalance.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBalance.ForeColor = System.Drawing.Color.Maroon;
            this.lblBalance.Location = new System.Drawing.Point(462, 365);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(144, 27);
            this.lblBalance.TabIndex = 37;
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label29.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label29.Location = new System.Drawing.Point(438, 365);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(15, 23);
            this.label29.TabIndex = 36;
            this.label29.Text = ":";
            // 
            // lblBalanceLable
            // 
            this.lblBalanceLable.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBalanceLable.ForeColor = System.Drawing.Color.Maroon;
            this.lblBalanceLable.Location = new System.Drawing.Point(300, 365);
            this.lblBalanceLable.Name = "lblBalanceLable";
            this.lblBalanceLable.Size = new System.Drawing.Size(130, 27);
            this.lblBalanceLable.TabIndex = 35;
            this.lblBalanceLable.Text = "Balance";
            this.lblBalanceLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label32.Location = new System.Drawing.Point(438, 327);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(15, 23);
            this.label32.TabIndex = 33;
            this.label32.Text = ":";
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label33.Location = new System.Drawing.Point(300, 327);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(130, 27);
            this.label33.TabIndex = 0;
            this.label33.Text = "Paid Amount";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalAmount2
            // 
            this.lblTotalAmount2.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalAmount2.ForeColor = System.Drawing.Color.Red;
            this.lblTotalAmount2.Location = new System.Drawing.Point(462, 289);
            this.lblTotalAmount2.Name = "lblTotalAmount2";
            this.lblTotalAmount2.Size = new System.Drawing.Size(144, 27);
            this.lblTotalAmount2.TabIndex = 31;
            this.lblTotalAmount2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label35.Location = new System.Drawing.Point(438, 289);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(15, 23);
            this.label35.TabIndex = 30;
            this.label35.Text = ":";
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label36.ForeColor = System.Drawing.Color.Red;
            this.label36.Location = new System.Drawing.Point(300, 289);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(130, 27);
            this.label36.TabIndex = 29;
            this.label36.Text = "Total Amount";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPaidAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaidAmount.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPaidAmount.Location = new System.Drawing.Point(459, 327);
            this.txtPaidAmount.MaxLength = 10;
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(147, 26);
            this.txtPaidAmount.TabIndex = 1;
            this.txtPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPaidAmount.TextChanged += new System.EventHandler(this.TxtPaidAmount_TextChanged);
            this.txtPaidAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPaidAmount_KeyDown);
            this.txtPaidAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPaidAmount_KeyPress);
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(128, 186);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(109, 19);
            this.lblQuantity.TabIndex = 10;
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAmount
            // 
            this.lblAmount.Location = new System.Drawing.Point(128, 214);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(109, 19);
            this.lblAmount.TabIndex = 13;
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTransactionNo
            // 
            this.txtTransactionNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtTransactionNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTransactionNo.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.txtTransactionNo.Location = new System.Drawing.Point(282, 27);
            this.txtTransactionNo.MaxLength = 50;
            this.txtTransactionNo.Name = "txtTransactionNo";
            this.txtTransactionNo.PlaceholderText = "Transaction No.";
            this.txtTransactionNo.Size = new System.Drawing.Size(156, 20);
            this.txtTransactionNo.TabIndex = 4;
            this.txtTransactionNo.TabStop = false;
            this.txtTransactionNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTransactionNo.Visible = false;
            this.txtTransactionNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTransactionNo_KeyDown);
            // 
            // SummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(629, 484);
            this.ControlBox = false;
            this.Controls.Add(this.pnlUPIType);
            this.Controls.Add(this.pnlPaymentTypes);
            this.Controls.Add(this.txtTransactionNo);
            this.Controls.Add(this.txtPaidAmount);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.lblBalanceLable);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.lblTotalAmount2);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lblGSTValue);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.lblTaxableAmount);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblITems);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnPrintInvoice);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SummaryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SummaryForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SummaryForm_Paint);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlPaymentTypes.ResumeLayout(false);
            this.pnlPaymentTypes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvwPaymentTypes)).EndInit();
            this.pnlUPIType.ResumeLayout(false);
            this.pnlUPIType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvwUPITypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrintInvoice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnChangePaymentType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPaymentType;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnChangeUPIType;
        private System.Windows.Forms.Label lblUPIType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlPaymentTypes;
        private System.Windows.Forms.Button btnPaymentTypeClose;
        private System.Windows.Forms.DataGridView gvwPaymentTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueName;
        private System.Windows.Forms.Panel pnlUPIType;
        private System.Windows.Forms.DataGridView gvwUPITypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button btnCloseUPIType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label lblBalanceLable;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        internal System.Windows.Forms.Label lblITems;
        internal System.Windows.Forms.Label lblDiscount;
        internal System.Windows.Forms.Label lblQuantity;
        internal System.Windows.Forms.Label lblAmount;
        internal System.Windows.Forms.Label lblTotalAmount;
        internal System.Windows.Forms.Label lblGSTValue;
        internal System.Windows.Forms.Label lblTaxableAmount;
        internal System.Windows.Forms.Label lblBalance;
        internal System.Windows.Forms.Label lblTotalAmount2;
        internal System.Windows.Forms.TextBox txtPaidAmount;
        internal System.Windows.Forms.TextBox txtTransactionNo;
    }
}