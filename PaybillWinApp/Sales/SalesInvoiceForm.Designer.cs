namespace PayBillApp.WinApp
{
    partial class SalesInvoiceForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesInvoiceForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            lblClientName = new Label();
            chkBarcodeOnly = new CheckBox();
            lblInvoiceNo = new Label();
            lblInvoiceDate = new Label();
            panelRounded1 = new UserControls.PanelRounded();
            groupBox3 = new GroupBox();
            txtQuantity = new TextBox();
            groupBox2 = new GroupBox();
            txtSearch = new TextBox();
            btnAddItem = new Button();
            groupBox1 = new GroupBox();
            pnlKeypboard = new TableLayoutPanel();
            btnExit = new Button();
            btnSave = new Button();
            btnMenu = new Button();
            button37 = new Button();
            button36 = new Button();
            button35 = new Button();
            button34 = new Button();
            button33 = new Button();
            button32 = new Button();
            button31 = new Button();
            button30 = new Button();
            button29 = new Button();
            button28 = new Button();
            button27 = new Button();
            button26 = new Button();
            button25 = new Button();
            button24 = new Button();
            button23 = new Button();
            button22 = new Button();
            button21 = new Button();
            button20 = new Button();
            button19 = new Button();
            button18 = new Button();
            button17 = new Button();
            button16 = new Button();
            button15 = new Button();
            button14 = new Button();
            button13 = new Button();
            btnSpace = new Button();
            button12 = new Button();
            button11 = new Button();
            button10 = new Button();
            button9 = new Button();
            button8 = new Button();
            btnBack = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button7 = new Button();
            chkCapsLock = new CheckBox();
            pnlParticulars = new FlowLayoutPanel();
            gvwItems = new DataGridView();
            ItemId = new DataGridViewTextBoxColumn();
            ItemCode = new DataGridViewTextBoxColumn();
            ItemName = new DataGridViewTextBoxColumn();
            ItemMRP = new DataGridViewTextBoxColumn();
            ItemPrice = new DataGridViewTextBoxColumn();
            ItemAaliasNname = new DataGridViewTextBoxColumn();
            ItemDiscountPer = new DataGridViewTextBoxColumn();
            ItemGSTPer = new DataGridViewTextBoxColumn();
            LocalLanguage = new DataGridViewTextBoxColumn();
            pnlProcess = new Panel();
            btnExitProcess = new Button();
            label1 = new Label();
            btnEditItem = new Button();
            btnResetForm = new Button();
            pnlCashReceived = new UserControls.PanelRounded();
            lblBalance = new Label();
            label6 = new Label();
            lblCashReceived = new Label();
            label4 = new Label();
            lblInvoiceAmount = new Label();
            label2 = new Label();
            btnViewSales = new Button();
            btnClear = new Button();
            MenuStrip = new ContextMenuStrip(components);
            MenuItemMaster = new ToolStripMenuItem();
            MenuItemCategory = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripMenuItem();
            MenuItemVendor = new ToolStripMenuItem();
            MenuItemMessage = new ToolStripMenuItem();
            MenuItemUser = new ToolStripMenuItem();
            MenuItemSales = new ToolStripMenuItem();
            MenuItemPurchase = new ToolStripMenuItem();
            MenuItemUtilities = new ToolStripMenuItem();
            MenuItemReports = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelRounded1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            pnlKeypboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvwItems).BeginInit();
            pnlProcess.SuspendLayout();
            pnlCashReceived.SuspendLayout();
            MenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1328, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(117, 99);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // lblClientName
            // 
            lblClientName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblClientName.BackColor = SystemColors.Control;
            lblClientName.BorderStyle = BorderStyle.Fixed3D;
            lblClientName.Font = new Font("Microsoft Sans Serif", 18F);
            lblClientName.Location = new Point(923, 8);
            lblClientName.Name = "lblClientName";
            lblClientName.Size = new Size(399, 56);
            lblClientName.TabIndex = 6;
            lblClientName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chkBarcodeOnly
            // 
            chkBarcodeOnly.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkBarcodeOnly.Appearance = Appearance.Button;
            chkBarcodeOnly.BackColor = Color.DarkGreen;
            chkBarcodeOnly.FlatStyle = FlatStyle.Popup;
            chkBarcodeOnly.ForeColor = Color.White;
            chkBarcodeOnly.Location = new Point(923, 72);
            chkBarcodeOnly.Name = "chkBarcodeOnly";
            chkBarcodeOnly.Size = new Size(107, 33);
            chkBarcodeOnly.TabIndex = 7;
            chkBarcodeOnly.Text = "Barcode Only";
            chkBarcodeOnly.TextAlign = ContentAlignment.MiddleCenter;
            chkBarcodeOnly.UseVisualStyleBackColor = false;
            chkBarcodeOnly.Click += ChkBarcodeOnly_Click;
            // 
            // lblInvoiceNo
            // 
            lblInvoiceNo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblInvoiceNo.BackColor = SystemColors.Control;
            lblInvoiceNo.BorderStyle = BorderStyle.Fixed3D;
            lblInvoiceNo.Font = new Font("Roboto", 10F, FontStyle.Bold);
            lblInvoiceNo.ForeColor = Color.White;
            lblInvoiceNo.Location = new Point(1036, 72);
            lblInvoiceNo.Name = "lblInvoiceNo";
            lblInvoiceNo.Size = new Size(138, 33);
            lblInvoiceNo.TabIndex = 8;
            lblInvoiceNo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblInvoiceDate
            // 
            lblInvoiceDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblInvoiceDate.BackColor = SystemColors.Control;
            lblInvoiceDate.BorderStyle = BorderStyle.Fixed3D;
            lblInvoiceDate.Font = new Font("Roboto", 10F);
            lblInvoiceDate.Location = new Point(1182, 72);
            lblInvoiceDate.Name = "lblInvoiceDate";
            lblInvoiceDate.Size = new Size(141, 33);
            lblInvoiceDate.TabIndex = 9;
            lblInvoiceDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelRounded1
            // 
            panelRounded1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelRounded1.BackColor = Color.White;
            panelRounded1.Controls.Add(groupBox3);
            panelRounded1.Controls.Add(groupBox2);
            panelRounded1.Controls.Add(btnAddItem);
            panelRounded1.Location = new Point(10, 8);
            panelRounded1.Name = "panelRounded1";
            panelRounded1.Size = new Size(901, 99);
            panelRounded1.TabIndex = 10;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox3.Controls.Add(txtQuantity);
            groupBox3.Location = new Point(714, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(71, 79);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            // 
            // txtQuantity
            // 
            txtQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtQuantity.BorderStyle = BorderStyle.None;
            txtQuantity.Font = new Font("Microsoft Sans Serif", 21.75F);
            txtQuantity.Location = new Point(6, 26);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(59, 42);
            txtQuantity.TabIndex = 0;
            txtQuantity.TextAlign = HorizontalAlignment.Center;
            txtQuantity.KeyDown += TxtQuantity_KeyDown;
            txtQuantity.KeyPress += TxtQuantity_KeyPress;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(txtSearch);
            groupBox2.Location = new Point(13, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(696, 79);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Microsoft Sans Serif", 21.75F);
            txtSearch.Location = new Point(17, 26);
            txtSearch.MaxLength = 50;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(663, 42);
            txtSearch.TabIndex = 0;
            // 
            // btnAddItem
            // 
            btnAddItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddItem.BackColor = Color.FromArgb(224, 224, 224);
            btnAddItem.Font = new Font("Roboto", 10F, FontStyle.Bold);
            btnAddItem.ForeColor = Color.Gray;
            btnAddItem.Location = new Point(789, 12);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(97, 74);
            btnAddItem.TabIndex = 2;
            btnAddItem.Text = "ADD";
            btnAddItem.UseVisualStyleBackColor = false;
            btnAddItem.Click += BtnAddItem_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(pnlKeypboard);
            groupBox1.Location = new Point(10, 106);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(901, 620);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            // 
            // pnlKeypboard
            // 
            pnlKeypboard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlKeypboard.ColumnCount = 6;
            pnlKeypboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            pnlKeypboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66666F));
            pnlKeypboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66666F));
            pnlKeypboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66666F));
            pnlKeypboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66666F));
            pnlKeypboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66666F));
            pnlKeypboard.Controls.Add(btnExit, 5, 6);
            pnlKeypboard.Controls.Add(btnSave, 4, 6);
            pnlKeypboard.Controls.Add(btnMenu, 3, 6);
            pnlKeypboard.Controls.Add(button37, 1, 6);
            pnlKeypboard.Controls.Add(button36, 0, 6);
            pnlKeypboard.Controls.Add(button35, 5, 5);
            pnlKeypboard.Controls.Add(button34, 4, 5);
            pnlKeypboard.Controls.Add(button33, 3, 5);
            pnlKeypboard.Controls.Add(button32, 2, 5);
            pnlKeypboard.Controls.Add(button31, 1, 5);
            pnlKeypboard.Controls.Add(button30, 0, 5);
            pnlKeypboard.Controls.Add(button29, 5, 4);
            pnlKeypboard.Controls.Add(button28, 4, 4);
            pnlKeypboard.Controls.Add(button27, 3, 4);
            pnlKeypboard.Controls.Add(button26, 2, 4);
            pnlKeypboard.Controls.Add(button25, 1, 4);
            pnlKeypboard.Controls.Add(button24, 0, 4);
            pnlKeypboard.Controls.Add(button23, 5, 3);
            pnlKeypboard.Controls.Add(button22, 4, 3);
            pnlKeypboard.Controls.Add(button21, 3, 3);
            pnlKeypboard.Controls.Add(button20, 2, 3);
            pnlKeypboard.Controls.Add(button19, 1, 3);
            pnlKeypboard.Controls.Add(button18, 0, 3);
            pnlKeypboard.Controls.Add(button17, 5, 2);
            pnlKeypboard.Controls.Add(button16, 4, 2);
            pnlKeypboard.Controls.Add(button15, 3, 2);
            pnlKeypboard.Controls.Add(button14, 2, 2);
            pnlKeypboard.Controls.Add(button13, 1, 2);
            pnlKeypboard.Controls.Add(btnSpace, 5, 1);
            pnlKeypboard.Controls.Add(button12, 4, 1);
            pnlKeypboard.Controls.Add(button11, 3, 1);
            pnlKeypboard.Controls.Add(button10, 2, 1);
            pnlKeypboard.Controls.Add(button9, 1, 1);
            pnlKeypboard.Controls.Add(button8, 0, 1);
            pnlKeypboard.Controls.Add(btnBack, 5, 0);
            pnlKeypboard.Controls.Add(button6, 4, 0);
            pnlKeypboard.Controls.Add(button5, 3, 0);
            pnlKeypboard.Controls.Add(button4, 2, 0);
            pnlKeypboard.Controls.Add(button3, 1, 0);
            pnlKeypboard.Controls.Add(button2, 0, 0);
            pnlKeypboard.Controls.Add(button7, 0, 2);
            pnlKeypboard.Controls.Add(chkCapsLock, 2, 6);
            pnlKeypboard.Location = new Point(7, 16);
            pnlKeypboard.Name = "pnlKeypboard";
            pnlKeypboard.RowCount = 7;
            pnlKeypboard.RowStyles.Add(new RowStyle(SizeType.Percent, 17.95F));
            pnlKeypboard.RowStyles.Add(new RowStyle(SizeType.Percent, 17.95F));
            pnlKeypboard.RowStyles.Add(new RowStyle(SizeType.Percent, 12.82F));
            pnlKeypboard.RowStyles.Add(new RowStyle(SizeType.Percent, 12.82F));
            pnlKeypboard.RowStyles.Add(new RowStyle(SizeType.Percent, 12.82F));
            pnlKeypboard.RowStyles.Add(new RowStyle(SizeType.Percent, 12.82F));
            pnlKeypboard.RowStyles.Add(new RowStyle(SizeType.Percent, 12.82F));
            pnlKeypboard.Size = new Size(886, 597);
            pnlKeypboard.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.DarkRed;
            btnExit.Dock = DockStyle.Fill;
            btnExit.Font = new Font("Roboto", 10F, FontStyle.Bold);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(738, 521);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(145, 73);
            btnExit.TabIndex = 41;
            btnExit.Tag = "0";
            btnExit.Text = "EXIT";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += BtnExit_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(63, 81, 181);
            btnSave.Dock = DockStyle.Fill;
            btnSave.Font = new Font("Roboto", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(591, 521);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(141, 73);
            btnSave.TabIndex = 40;
            btnSave.Tag = "0";
            btnSave.Text = "&SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnMenu
            // 
            btnMenu.Dock = DockStyle.Fill;
            btnMenu.Font = new Font("Microsoft Sans Serif", 14F);
            btnMenu.Image = (Image)resources.GetObject("btnMenu.Image");
            btnMenu.Location = new Point(444, 521);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(141, 73);
            btnMenu.TabIndex = 39;
            btnMenu.Tag = "0";
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += BtnMenu_Click;
            // 
            // button37
            // 
            button37.Dock = DockStyle.Fill;
            button37.Font = new Font("Microsoft Sans Serif", 18F);
            button37.Location = new Point(150, 521);
            button37.Name = "button37";
            button37.Size = new Size(141, 73);
            button37.TabIndex = 37;
            button37.Tag = "char";
            button37.Text = "Z";
            button37.UseVisualStyleBackColor = true;
            button37.Click += BtnChars_Click;
            // 
            // button36
            // 
            button36.Dock = DockStyle.Fill;
            button36.Font = new Font("Microsoft Sans Serif", 18F);
            button36.Location = new Point(3, 521);
            button36.Name = "button36";
            button36.Size = new Size(141, 73);
            button36.TabIndex = 36;
            button36.Tag = "char";
            button36.Text = "Y";
            button36.UseVisualStyleBackColor = true;
            button36.Click += BtnChars_Click;
            // 
            // button35
            // 
            button35.Dock = DockStyle.Fill;
            button35.Font = new Font("Microsoft Sans Serif", 18F);
            button35.Location = new Point(738, 445);
            button35.Name = "button35";
            button35.Size = new Size(145, 70);
            button35.TabIndex = 35;
            button35.Tag = "char";
            button35.Text = "X";
            button35.UseVisualStyleBackColor = true;
            button35.Click += BtnChars_Click;
            // 
            // button34
            // 
            button34.Dock = DockStyle.Fill;
            button34.Font = new Font("Microsoft Sans Serif", 18F);
            button34.Location = new Point(591, 445);
            button34.Name = "button34";
            button34.Size = new Size(141, 70);
            button34.TabIndex = 34;
            button34.Tag = "char";
            button34.Text = "W";
            button34.UseVisualStyleBackColor = true;
            button34.Click += BtnChars_Click;
            // 
            // button33
            // 
            button33.Dock = DockStyle.Fill;
            button33.Font = new Font("Microsoft Sans Serif", 18F);
            button33.Location = new Point(444, 445);
            button33.Name = "button33";
            button33.Size = new Size(141, 70);
            button33.TabIndex = 33;
            button33.Tag = "char";
            button33.Text = "V";
            button33.UseVisualStyleBackColor = true;
            button33.Click += BtnChars_Click;
            // 
            // button32
            // 
            button32.Dock = DockStyle.Fill;
            button32.Font = new Font("Microsoft Sans Serif", 18F);
            button32.Location = new Point(297, 445);
            button32.Name = "button32";
            button32.Size = new Size(141, 70);
            button32.TabIndex = 32;
            button32.Tag = "char";
            button32.Text = "U";
            button32.UseVisualStyleBackColor = true;
            button32.Click += BtnChars_Click;
            // 
            // button31
            // 
            button31.Dock = DockStyle.Fill;
            button31.Font = new Font("Microsoft Sans Serif", 18F);
            button31.Location = new Point(150, 445);
            button31.Name = "button31";
            button31.Size = new Size(141, 70);
            button31.TabIndex = 31;
            button31.Tag = "char";
            button31.Text = "T";
            button31.UseVisualStyleBackColor = true;
            button31.Click += BtnChars_Click;
            // 
            // button30
            // 
            button30.Dock = DockStyle.Fill;
            button30.Font = new Font("Microsoft Sans Serif", 18F);
            button30.Location = new Point(3, 445);
            button30.Name = "button30";
            button30.Size = new Size(141, 70);
            button30.TabIndex = 30;
            button30.Tag = "char";
            button30.Text = "S";
            button30.UseVisualStyleBackColor = true;
            button30.Click += BtnChars_Click;
            // 
            // button29
            // 
            button29.Dock = DockStyle.Fill;
            button29.Font = new Font("Microsoft Sans Serif", 18F);
            button29.Location = new Point(738, 369);
            button29.Name = "button29";
            button29.Size = new Size(145, 70);
            button29.TabIndex = 29;
            button29.Tag = "char";
            button29.Text = "R";
            button29.UseVisualStyleBackColor = true;
            button29.Click += BtnChars_Click;
            // 
            // button28
            // 
            button28.Dock = DockStyle.Fill;
            button28.Font = new Font("Microsoft Sans Serif", 18F);
            button28.Location = new Point(591, 369);
            button28.Name = "button28";
            button28.Size = new Size(141, 70);
            button28.TabIndex = 28;
            button28.Tag = "char";
            button28.Text = "Q";
            button28.UseVisualStyleBackColor = true;
            button28.Click += BtnChars_Click;
            // 
            // button27
            // 
            button27.Dock = DockStyle.Fill;
            button27.Font = new Font("Microsoft Sans Serif", 18F);
            button27.Location = new Point(444, 369);
            button27.Name = "button27";
            button27.Size = new Size(141, 70);
            button27.TabIndex = 27;
            button27.Tag = "char";
            button27.Text = "P";
            button27.UseVisualStyleBackColor = true;
            button27.Click += BtnChars_Click;
            // 
            // button26
            // 
            button26.Dock = DockStyle.Fill;
            button26.Font = new Font("Microsoft Sans Serif", 18F);
            button26.Location = new Point(297, 369);
            button26.Name = "button26";
            button26.Size = new Size(141, 70);
            button26.TabIndex = 26;
            button26.Tag = "char";
            button26.Text = "O";
            button26.UseVisualStyleBackColor = true;
            button26.Click += BtnChars_Click;
            // 
            // button25
            // 
            button25.Dock = DockStyle.Fill;
            button25.Font = new Font("Microsoft Sans Serif", 18F);
            button25.Location = new Point(150, 369);
            button25.Name = "button25";
            button25.Size = new Size(141, 70);
            button25.TabIndex = 25;
            button25.Tag = "char";
            button25.Text = "N";
            button25.UseVisualStyleBackColor = true;
            button25.Click += BtnChars_Click;
            // 
            // button24
            // 
            button24.Dock = DockStyle.Fill;
            button24.Font = new Font("Microsoft Sans Serif", 18F);
            button24.Location = new Point(3, 369);
            button24.Name = "button24";
            button24.Size = new Size(141, 70);
            button24.TabIndex = 24;
            button24.Tag = "char";
            button24.Text = "M";
            button24.UseVisualStyleBackColor = true;
            button24.Click += BtnChars_Click;
            // 
            // button23
            // 
            button23.Dock = DockStyle.Fill;
            button23.Font = new Font("Microsoft Sans Serif", 18F);
            button23.Location = new Point(738, 293);
            button23.Name = "button23";
            button23.Size = new Size(145, 70);
            button23.TabIndex = 23;
            button23.Tag = "char";
            button23.Text = "L";
            button23.UseVisualStyleBackColor = true;
            button23.Click += BtnChars_Click;
            // 
            // button22
            // 
            button22.Dock = DockStyle.Fill;
            button22.Font = new Font("Microsoft Sans Serif", 18F);
            button22.Location = new Point(591, 293);
            button22.Name = "button22";
            button22.Size = new Size(141, 70);
            button22.TabIndex = 22;
            button22.Tag = "char";
            button22.Text = "K";
            button22.UseVisualStyleBackColor = true;
            button22.Click += BtnChars_Click;
            // 
            // button21
            // 
            button21.Dock = DockStyle.Fill;
            button21.Font = new Font("Microsoft Sans Serif", 18F);
            button21.Location = new Point(444, 293);
            button21.Name = "button21";
            button21.Size = new Size(141, 70);
            button21.TabIndex = 21;
            button21.Tag = "char";
            button21.Text = "J";
            button21.UseVisualStyleBackColor = true;
            button21.Click += BtnChars_Click;
            // 
            // button20
            // 
            button20.Dock = DockStyle.Fill;
            button20.Font = new Font("Microsoft Sans Serif", 18F);
            button20.Location = new Point(297, 293);
            button20.Name = "button20";
            button20.Size = new Size(141, 70);
            button20.TabIndex = 20;
            button20.Tag = "char";
            button20.Text = "I";
            button20.UseVisualStyleBackColor = true;
            button20.Click += BtnChars_Click;
            // 
            // button19
            // 
            button19.Dock = DockStyle.Fill;
            button19.Font = new Font("Microsoft Sans Serif", 18F);
            button19.Location = new Point(150, 293);
            button19.Name = "button19";
            button19.Size = new Size(141, 70);
            button19.TabIndex = 19;
            button19.Tag = "char";
            button19.Text = "H";
            button19.UseVisualStyleBackColor = true;
            button19.Click += BtnChars_Click;
            // 
            // button18
            // 
            button18.Dock = DockStyle.Fill;
            button18.Font = new Font("Microsoft Sans Serif", 18F);
            button18.Location = new Point(3, 293);
            button18.Name = "button18";
            button18.Size = new Size(141, 70);
            button18.TabIndex = 18;
            button18.Tag = "char";
            button18.Text = "G";
            button18.UseVisualStyleBackColor = true;
            button18.Click += BtnChars_Click;
            // 
            // button17
            // 
            button17.Dock = DockStyle.Fill;
            button17.Font = new Font("Microsoft Sans Serif", 18F);
            button17.Location = new Point(738, 217);
            button17.Name = "button17";
            button17.Size = new Size(145, 70);
            button17.TabIndex = 17;
            button17.Tag = "char";
            button17.Text = "F";
            button17.UseVisualStyleBackColor = true;
            button17.Click += BtnChars_Click;
            // 
            // button16
            // 
            button16.Dock = DockStyle.Fill;
            button16.Font = new Font("Microsoft Sans Serif", 18F);
            button16.Location = new Point(591, 217);
            button16.Name = "button16";
            button16.Size = new Size(141, 70);
            button16.TabIndex = 16;
            button16.Tag = "char";
            button16.Text = "E";
            button16.UseVisualStyleBackColor = true;
            button16.Click += BtnChars_Click;
            // 
            // button15
            // 
            button15.Dock = DockStyle.Fill;
            button15.Font = new Font("Microsoft Sans Serif", 18F);
            button15.Location = new Point(444, 217);
            button15.Name = "button15";
            button15.Size = new Size(141, 70);
            button15.TabIndex = 15;
            button15.Tag = "char";
            button15.Text = "D";
            button15.UseVisualStyleBackColor = true;
            button15.Click += BtnChars_Click;
            // 
            // button14
            // 
            button14.Dock = DockStyle.Fill;
            button14.Font = new Font("Microsoft Sans Serif", 18F);
            button14.Location = new Point(297, 217);
            button14.Name = "button14";
            button14.Size = new Size(141, 70);
            button14.TabIndex = 14;
            button14.Tag = "char";
            button14.Text = "C";
            button14.UseVisualStyleBackColor = true;
            button14.Click += BtnChars_Click;
            // 
            // button13
            // 
            button13.Dock = DockStyle.Fill;
            button13.Font = new Font("Microsoft Sans Serif", 18F);
            button13.Location = new Point(150, 217);
            button13.Name = "button13";
            button13.Size = new Size(141, 70);
            button13.TabIndex = 13;
            button13.Tag = "char";
            button13.Text = "B";
            button13.UseVisualStyleBackColor = true;
            button13.Click += BtnChars_Click;
            // 
            // btnSpace
            // 
            btnSpace.Dock = DockStyle.Fill;
            btnSpace.Font = new Font("Roboto", 12F);
            btnSpace.Location = new Point(738, 110);
            btnSpace.Name = "btnSpace";
            btnSpace.Size = new Size(145, 101);
            btnSpace.TabIndex = 11;
            btnSpace.Tag = "0";
            btnSpace.Text = "Space";
            btnSpace.UseVisualStyleBackColor = true;
            btnSpace.Click += BtnSpace_Click;
            // 
            // button12
            // 
            button12.Dock = DockStyle.Fill;
            button12.Font = new Font("Roboto", 30F);
            button12.Location = new Point(591, 110);
            button12.Name = "button12";
            button12.Size = new Size(141, 101);
            button12.TabIndex = 10;
            button12.Tag = "0";
            button12.Text = "0";
            button12.UseVisualStyleBackColor = true;
            button12.Click += BtnNumbers_Click;
            // 
            // button11
            // 
            button11.Dock = DockStyle.Fill;
            button11.Font = new Font("Roboto", 30F);
            button11.Location = new Point(444, 110);
            button11.Name = "button11";
            button11.Size = new Size(141, 101);
            button11.TabIndex = 9;
            button11.Tag = "0";
            button11.Text = "9";
            button11.UseVisualStyleBackColor = true;
            button11.Click += BtnNumbers_Click;
            // 
            // button10
            // 
            button10.Dock = DockStyle.Fill;
            button10.Font = new Font("Roboto", 30F);
            button10.Location = new Point(297, 110);
            button10.Name = "button10";
            button10.Size = new Size(141, 101);
            button10.TabIndex = 8;
            button10.Tag = "0";
            button10.Text = "8";
            button10.UseVisualStyleBackColor = true;
            button10.Click += BtnNumbers_Click;
            // 
            // button9
            // 
            button9.Dock = DockStyle.Fill;
            button9.Font = new Font("Roboto", 30F);
            button9.Location = new Point(150, 110);
            button9.Name = "button9";
            button9.Size = new Size(141, 101);
            button9.TabIndex = 7;
            button9.Tag = "0";
            button9.Text = "7";
            button9.UseVisualStyleBackColor = true;
            button9.Click += BtnNumbers_Click;
            // 
            // button8
            // 
            button8.Dock = DockStyle.Fill;
            button8.Font = new Font("Roboto", 30F);
            button8.Location = new Point(3, 110);
            button8.Name = "button8";
            button8.Size = new Size(141, 101);
            button8.TabIndex = 6;
            button8.Tag = "0";
            button8.Text = "6";
            button8.UseVisualStyleBackColor = true;
            button8.Click += BtnNumbers_Click;
            // 
            // btnBack
            // 
            btnBack.Dock = DockStyle.Fill;
            btnBack.Font = new Font("Roboto", 12F);
            btnBack.Location = new Point(738, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(145, 101);
            btnBack.TabIndex = 5;
            btnBack.Tag = "0";
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += BtnBack_Click;
            // 
            // button6
            // 
            button6.Dock = DockStyle.Fill;
            button6.Font = new Font("Roboto", 30F);
            button6.Location = new Point(591, 3);
            button6.Name = "button6";
            button6.Size = new Size(141, 101);
            button6.TabIndex = 4;
            button6.Tag = "0";
            button6.Text = "5";
            button6.UseVisualStyleBackColor = true;
            button6.Click += BtnNumbers_Click;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Fill;
            button5.Font = new Font("Roboto", 30F);
            button5.Location = new Point(444, 3);
            button5.Name = "button5";
            button5.Size = new Size(141, 101);
            button5.TabIndex = 3;
            button5.Tag = "0";
            button5.Text = "4";
            button5.UseVisualStyleBackColor = true;
            button5.Click += BtnNumbers_Click;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Fill;
            button4.Font = new Font("Roboto", 30F);
            button4.Location = new Point(297, 3);
            button4.Name = "button4";
            button4.Size = new Size(141, 101);
            button4.TabIndex = 2;
            button4.Tag = "0";
            button4.Text = "3";
            button4.UseVisualStyleBackColor = true;
            button4.Click += BtnNumbers_Click;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.Font = new Font("Roboto", 30F);
            button3.Location = new Point(150, 3);
            button3.Name = "button3";
            button3.Size = new Size(141, 101);
            button3.TabIndex = 1;
            button3.Tag = "0";
            button3.Text = "2";
            button3.UseVisualStyleBackColor = true;
            button3.Click += BtnNumbers_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.Font = new Font("Roboto", 30F);
            button2.Location = new Point(3, 3);
            button2.Name = "button2";
            button2.Size = new Size(141, 101);
            button2.TabIndex = 0;
            button2.Tag = "0";
            button2.Text = "1";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BtnNumbers_Click;
            // 
            // button7
            // 
            button7.Dock = DockStyle.Fill;
            button7.Font = new Font("Microsoft Sans Serif", 18F);
            button7.Location = new Point(3, 217);
            button7.Name = "button7";
            button7.Size = new Size(141, 70);
            button7.TabIndex = 12;
            button7.Tag = "char";
            button7.Text = "A";
            button7.UseVisualStyleBackColor = true;
            button7.Click += BtnChars_Click;
            // 
            // chkCapsLock
            // 
            chkCapsLock.Appearance = Appearance.Button;
            chkCapsLock.AutoSize = true;
            chkCapsLock.Checked = true;
            chkCapsLock.CheckState = CheckState.Checked;
            chkCapsLock.Dock = DockStyle.Fill;
            chkCapsLock.Location = new Point(297, 521);
            chkCapsLock.Name = "chkCapsLock";
            chkCapsLock.Size = new Size(141, 73);
            chkCapsLock.TabIndex = 42;
            chkCapsLock.Text = "Caps\r\nLock\r\n";
            chkCapsLock.TextAlign = ContentAlignment.MiddleCenter;
            chkCapsLock.UseVisualStyleBackColor = true;
            chkCapsLock.Click += ChkCapsLock_Click;
            // 
            // pnlParticulars
            // 
            pnlParticulars.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlParticulars.AutoScroll = true;
            pnlParticulars.BackColor = Color.White;
            pnlParticulars.FlowDirection = FlowDirection.TopDown;
            pnlParticulars.Location = new Point(923, 116);
            pnlParticulars.Name = "pnlParticulars";
            pnlParticulars.Padding = new Padding(0, 0, 50, 0);
            pnlParticulars.Size = new Size(522, 610);
            pnlParticulars.TabIndex = 12;
            pnlParticulars.WrapContents = false;
            // 
            // gvwItems
            // 
            gvwItems.AllowUserToAddRows = false;
            gvwItems.AllowUserToDeleteRows = false;
            gvwItems.AllowUserToResizeRows = false;
            gvwItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            gvwItems.BackgroundColor = Color.White;
            gvwItems.BorderStyle = BorderStyle.None;
            gvwItems.CellBorderStyle = DataGridViewCellBorderStyle.None;
            gvwItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Roboto", 10F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gvwItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gvwItems.ColumnHeadersHeight = 30;
            gvwItems.Columns.AddRange(new DataGridViewColumn[] { ItemId, ItemCode, ItemName, ItemMRP, ItemPrice, ItemAaliasNname, ItemDiscountPer, ItemGSTPer, LocalLanguage });
            gvwItems.GridColor = Color.WhiteSmoke;
            gvwItems.Location = new Point(923, 118);
            gvwItems.MultiSelect = false;
            gvwItems.Name = "gvwItems";
            gvwItems.ReadOnly = true;
            gvwItems.RowHeadersVisible = false;
            gvwItems.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Font = new Font("Roboto", 9.75F);
            dataGridViewCellStyle4.SelectionBackColor = Color.AliceBlue;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ActiveCaptionText;
            gvwItems.RowsDefaultCellStyle = dataGridViewCellStyle4;
            gvwItems.RowTemplate.Height = 40;
            gvwItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gvwItems.Size = new Size(520, 611);
            gvwItems.TabIndex = 13;
            gvwItems.Visible = false;
            gvwItems.DoubleClick += GvwItems_DoubleClick;
            gvwItems.KeyDown += GvwItems_KeyDown;
            // 
            // ItemId
            // 
            ItemId.DataPropertyName = "ItemId";
            ItemId.HeaderText = "ItemId";
            ItemId.MinimumWidth = 6;
            ItemId.Name = "ItemId";
            ItemId.ReadOnly = true;
            ItemId.SortMode = DataGridViewColumnSortMode.NotSortable;
            ItemId.Visible = false;
            ItemId.Width = 125;
            // 
            // ItemCode
            // 
            ItemCode.DataPropertyName = "ItemCode";
            ItemCode.HeaderText = "Code";
            ItemCode.MinimumWidth = 6;
            ItemCode.Name = "ItemCode";
            ItemCode.ReadOnly = true;
            ItemCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            ItemCode.Width = 125;
            // 
            // ItemName
            // 
            ItemName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ItemName.DataPropertyName = "ItemName";
            ItemName.HeaderText = "Name";
            ItemName.MinimumWidth = 6;
            ItemName.Name = "ItemName";
            ItemName.ReadOnly = true;
            ItemName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ItemMRP
            // 
            ItemMRP.DataPropertyName = "ItemMRP";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            ItemMRP.DefaultCellStyle = dataGridViewCellStyle2;
            ItemMRP.HeaderText = "MRP";
            ItemMRP.MinimumWidth = 6;
            ItemMRP.Name = "ItemMRP";
            ItemMRP.ReadOnly = true;
            ItemMRP.SortMode = DataGridViewColumnSortMode.NotSortable;
            ItemMRP.Width = 125;
            // 
            // ItemPrice
            // 
            ItemPrice.DataPropertyName = "ItemPrice";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            ItemPrice.DefaultCellStyle = dataGridViewCellStyle3;
            ItemPrice.HeaderText = "Price";
            ItemPrice.MinimumWidth = 6;
            ItemPrice.Name = "ItemPrice";
            ItemPrice.ReadOnly = true;
            ItemPrice.SortMode = DataGridViewColumnSortMode.NotSortable;
            ItemPrice.Width = 125;
            // 
            // ItemAaliasNname
            // 
            ItemAaliasNname.DataPropertyName = "ItemAaliasNname";
            ItemAaliasNname.HeaderText = "ItemAaliasNname";
            ItemAaliasNname.MinimumWidth = 6;
            ItemAaliasNname.Name = "ItemAaliasNname";
            ItemAaliasNname.ReadOnly = true;
            ItemAaliasNname.SortMode = DataGridViewColumnSortMode.NotSortable;
            ItemAaliasNname.Visible = false;
            ItemAaliasNname.Width = 125;
            // 
            // ItemDiscountPer
            // 
            ItemDiscountPer.DataPropertyName = "ItemDiscountPer";
            ItemDiscountPer.HeaderText = "ItemDiscountPer";
            ItemDiscountPer.MinimumWidth = 6;
            ItemDiscountPer.Name = "ItemDiscountPer";
            ItemDiscountPer.ReadOnly = true;
            ItemDiscountPer.SortMode = DataGridViewColumnSortMode.NotSortable;
            ItemDiscountPer.Visible = false;
            ItemDiscountPer.Width = 125;
            // 
            // ItemGSTPer
            // 
            ItemGSTPer.DataPropertyName = "ItemGSTPer";
            ItemGSTPer.HeaderText = "ItemGSTPer";
            ItemGSTPer.MinimumWidth = 6;
            ItemGSTPer.Name = "ItemGSTPer";
            ItemGSTPer.ReadOnly = true;
            ItemGSTPer.SortMode = DataGridViewColumnSortMode.NotSortable;
            ItemGSTPer.Visible = false;
            ItemGSTPer.Width = 125;
            // 
            // LocalLanguage
            // 
            LocalLanguage.DataPropertyName = "LocalLanguage";
            LocalLanguage.HeaderText = "LocalLanguage";
            LocalLanguage.MinimumWidth = 6;
            LocalLanguage.Name = "LocalLanguage";
            LocalLanguage.ReadOnly = true;
            LocalLanguage.SortMode = DataGridViewColumnSortMode.NotSortable;
            LocalLanguage.Visible = false;
            LocalLanguage.Width = 125;
            // 
            // pnlProcess
            // 
            pnlProcess.Controls.Add(btnExitProcess);
            pnlProcess.Controls.Add(label1);
            pnlProcess.Location = new Point(0, 0);
            pnlProcess.Name = "pnlProcess";
            pnlProcess.Size = new Size(0, 0);
            pnlProcess.TabIndex = 14;
            pnlProcess.Visible = false;
            // 
            // btnExitProcess
            // 
            btnExitProcess.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExitProcess.BackColor = Color.DarkRed;
            btnExitProcess.Font = new Font("Roboto", 10F, FontStyle.Bold);
            btnExitProcess.ForeColor = Color.White;
            btnExitProcess.Location = new Point(-119, -71);
            btnExitProcess.Margin = new Padding(4);
            btnExitProcess.Name = "btnExitProcess";
            btnExitProcess.Size = new Size(104, 58);
            btnExitProcess.TabIndex = 3;
            btnExitProcess.Text = "EXIT";
            btnExitProcess.UseVisualStyleBackColor = false;
            btnExitProcess.Click += BtnExitProcess_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 36F);
            label1.ForeColor = Color.FromArgb(0, 192, 192);
            label1.Location = new Point(-142, -21);
            label1.Name = "label1";
            label1.Size = new Size(376, 72);
            label1.TabIndex = 0;
            label1.Text = "Processing...";
            // 
            // btnEditItem
            // 
            btnEditItem.Location = new Point(-20, 0);
            btnEditItem.Name = "btnEditItem";
            btnEditItem.Size = new Size(0, 0);
            btnEditItem.TabIndex = 15;
            btnEditItem.TabStop = false;
            btnEditItem.Text = "&E";
            btnEditItem.UseVisualStyleBackColor = true;
            btnEditItem.Click += BtnEditItem_Click;
            // 
            // btnResetForm
            // 
            btnResetForm.Location = new Point(0, 0);
            btnResetForm.Name = "btnResetForm";
            btnResetForm.Size = new Size(0, 0);
            btnResetForm.TabIndex = 16;
            btnResetForm.Text = "&l";
            btnResetForm.UseVisualStyleBackColor = true;
            btnResetForm.Click += BtnResetForm_Click;
            // 
            // pnlCashReceived
            // 
            pnlCashReceived.Anchor = AnchorStyles.Right;
            pnlCashReceived.BackColor = Color.FromArgb(0, 64, 0);
            pnlCashReceived.Controls.Add(lblBalance);
            pnlCashReceived.Controls.Add(label6);
            pnlCashReceived.Controls.Add(lblCashReceived);
            pnlCashReceived.Controls.Add(label4);
            pnlCashReceived.Controls.Add(lblInvoiceAmount);
            pnlCashReceived.Controls.Add(label2);
            pnlCashReceived.Location = new Point(948, 319);
            pnlCashReceived.Name = "pnlCashReceived";
            pnlCashReceived.Size = new Size(470, 166);
            pnlCashReceived.TabIndex = 17;
            pnlCashReceived.Visible = false;
            pnlCashReceived.Click += PnlCashReceived;
            // 
            // lblBalance
            // 
            lblBalance.Font = new Font("Roboto", 15.75F, FontStyle.Bold);
            lblBalance.ForeColor = Color.YellowGreen;
            lblBalance.Location = new Point(238, 108);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(190, 30);
            lblBalance.TabIndex = 5;
            lblBalance.Text = "500.00";
            lblBalance.TextAlign = ContentAlignment.TopRight;
            // 
            // label6
            // 
            label6.Font = new Font("Roboto", 14.25F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(25, 106);
            label6.Name = "label6";
            label6.Size = new Size(176, 30);
            label6.TabIndex = 4;
            label6.Text = "Balance";
            // 
            // lblCashReceived
            // 
            lblCashReceived.Font = new Font("Roboto", 15.75F, FontStyle.Bold);
            lblCashReceived.ForeColor = Color.White;
            lblCashReceived.Location = new Point(238, 68);
            lblCashReceived.Name = "lblCashReceived";
            lblCashReceived.Size = new Size(190, 30);
            lblCashReceived.TabIndex = 3;
            lblCashReceived.Text = "500.00";
            lblCashReceived.TextAlign = ContentAlignment.TopRight;
            // 
            // label4
            // 
            label4.Font = new Font("Roboto", 14.25F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(25, 66);
            label4.Name = "label4";
            label4.Size = new Size(201, 30);
            label4.TabIndex = 2;
            label4.Text = "Cash Received";
            // 
            // lblInvoiceAmount
            // 
            lblInvoiceAmount.Font = new Font("Roboto", 15.75F, FontStyle.Bold);
            lblInvoiceAmount.ForeColor = Color.Orange;
            lblInvoiceAmount.Location = new Point(239, 25);
            lblInvoiceAmount.Name = "lblInvoiceAmount";
            lblInvoiceAmount.Size = new Size(190, 30);
            lblInvoiceAmount.TabIndex = 1;
            lblInvoiceAmount.Text = "500.00";
            lblInvoiceAmount.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.Font = new Font("Roboto", 14.25F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(26, 23);
            label2.Name = "label2";
            label2.Size = new Size(200, 30);
            label2.TabIndex = 0;
            label2.Text = "Invoice Amount";
            // 
            // btnViewSales
            // 
            btnViewSales.Location = new Point(-10, 0);
            btnViewSales.Name = "btnViewSales";
            btnViewSales.Size = new Size(0, 0);
            btnViewSales.TabIndex = 18;
            btnViewSales.TabStop = false;
            btnViewSales.Text = "&W";
            btnViewSales.UseVisualStyleBackColor = true;
            btnViewSales.Click += BtnViewSales_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(-10, 0);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(0, 0);
            btnClear.TabIndex = 19;
            btnClear.TabStop = false;
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // MenuStrip
            // 
            MenuStrip.Font = new Font("Roboto", 12F);
            MenuStrip.ImageScalingSize = new Size(20, 20);
            MenuStrip.Items.AddRange(new ToolStripItem[] { MenuItemMaster, MenuItemSales, MenuItemPurchase, MenuItemUtilities, MenuItemReports });
            MenuStrip.Name = "contextMenuStrip1";
            MenuStrip.Size = new Size(211, 232);
            // 
            // MenuItemMaster
            // 
            MenuItemMaster.DropDownItems.AddRange(new ToolStripItem[] { MenuItemCategory, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem6, MenuItemVendor, MenuItemMessage, MenuItemUser });
            MenuItemMaster.Margin = new Padding(0, 6, 0, 6);
            MenuItemMaster.Name = "MenuItemMaster";
            MenuItemMaster.Size = new Size(210, 28);
            MenuItemMaster.Text = "Master";
            // 
            // MenuItemCategory
            // 
            MenuItemCategory.Margin = new Padding(0, 6, 0, 6);
            MenuItemCategory.Name = "MenuItemCategory";
            MenuItemCategory.Size = new Size(224, 28);
            MenuItemCategory.Text = "Category";
            MenuItemCategory.Click += MenuItemCategory_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Margin = new Padding(0, 6, 0, 6);
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(224, 28);
            toolStripMenuItem2.Text = "GST";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Margin = new Padding(0, 6, 0, 6);
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(224, 28);
            toolStripMenuItem3.Text = "Item";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Margin = new Padding(0, 6, 0, 6);
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(224, 28);
            toolStripMenuItem4.Text = "Service";
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Margin = new Padding(0, 6, 0, 6);
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(224, 28);
            toolStripMenuItem6.Text = "Party";
            // 
            // MenuItemVendor
            // 
            MenuItemVendor.Margin = new Padding(0, 6, 0, 6);
            MenuItemVendor.Name = "MenuItemVendor";
            MenuItemVendor.Size = new Size(224, 28);
            MenuItemVendor.Text = "Vendor";
            // 
            // MenuItemMessage
            // 
            MenuItemMessage.Margin = new Padding(0, 6, 0, 6);
            MenuItemMessage.Name = "MenuItemMessage";
            MenuItemMessage.Size = new Size(224, 28);
            MenuItemMessage.Text = "Message";
            // 
            // MenuItemUser
            // 
            MenuItemUser.Margin = new Padding(0, 6, 0, 6);
            MenuItemUser.Name = "MenuItemUser";
            MenuItemUser.Size = new Size(224, 28);
            MenuItemUser.Text = "User";
            // 
            // MenuItemSales
            // 
            MenuItemSales.Margin = new Padding(0, 6, 0, 6);
            MenuItemSales.Name = "MenuItemSales";
            MenuItemSales.Size = new Size(210, 28);
            MenuItemSales.Text = "Sales";
            // 
            // MenuItemPurchase
            // 
            MenuItemPurchase.Margin = new Padding(0, 6, 0, 6);
            MenuItemPurchase.Name = "MenuItemPurchase";
            MenuItemPurchase.Size = new Size(210, 28);
            MenuItemPurchase.Text = "Purchase";
            // 
            // MenuItemUtilities
            // 
            MenuItemUtilities.Margin = new Padding(0, 6, 0, 6);
            MenuItemUtilities.Name = "MenuItemUtilities";
            MenuItemUtilities.Size = new Size(210, 28);
            MenuItemUtilities.Text = "Utilities";
            // 
            // MenuItemReports
            // 
            MenuItemReports.Margin = new Padding(0, 6, 0, 6);
            MenuItemReports.Name = "MenuItemReports";
            MenuItemReports.Size = new Size(210, 28);
            MenuItemReports.Text = "Reports";
            // 
            // SalesInvoiceForm
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            CancelButton = btnClear;
            ClientSize = new Size(1454, 736);
            ControlBox = false;
            Controls.Add(pnlProcess);
            Controls.Add(btnClear);
            Controls.Add(btnViewSales);
            Controls.Add(pnlCashReceived);
            Controls.Add(btnResetForm);
            Controls.Add(btnEditItem);
            Controls.Add(gvwItems);
            Controls.Add(pnlParticulars);
            Controls.Add(groupBox1);
            Controls.Add(panelRounded1);
            Controls.Add(lblInvoiceDate);
            Controls.Add(lblInvoiceNo);
            Controls.Add(chkBarcodeOnly);
            Controls.Add(lblClientName);
            Controls.Add(pictureBox1);
            Font = new Font("Roboto", 10F);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "SalesInvoiceForm";
            Text = "Sales Invoice";
            WindowState = FormWindowState.Maximized;
            Load += SalesInvoice_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelRounded1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            pnlKeypboard.ResumeLayout(false);
            pnlKeypboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvwItems).EndInit();
            pnlProcess.ResumeLayout(false);
            pnlProcess.PerformLayout();
            pnlCashReceived.ResumeLayout(false);
            MenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.CheckBox chkBarcodeOnly;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Label lblInvoiceDate;
        private UserControls.PanelRounded panelRounded1;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel pnlKeypboard;
        private System.Windows.Forms.Button btnSpace;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Button button36;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.FlowLayoutPanel pnlParticulars;
        private System.Windows.Forms.DataGridView gvwItems;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel pnlProcess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExitProcess;
        private System.Windows.Forms.CheckBox chkCapsLock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemMRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemAaliasNname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemDiscountPer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemGSTPer;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalLanguage;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Button btnResetForm;
        private UserControls.PanelRounded pnlCashReceived;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCashReceived;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInvoiceAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnViewSales;
        private System.Windows.Forms.Button btnClear;
        private ContextMenuStrip MenuStrip;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem salesToolStripMenuItem;
        private ToolStripMenuItem purchaseToolStripMenuItem;
        private ToolStripMenuItem utilitiesToolStripMenuItem;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem MenuItemMaster;
        private ToolStripMenuItem MenuItemSales;
        private ToolStripMenuItem MenuItemPurchase;
        private ToolStripMenuItem MenuItemUtilities;
        private ToolStripMenuItem MenuItemReports;
        private ToolStripMenuItem MenuItemCategory;
        private ToolStripMenuItem MenuItemVendor;
        private ToolStripMenuItem MenuItemMessage;
        private ToolStripMenuItem MenuItemUser;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem6;
    }
}