namespace PaybillWinApp.MasterForms
{
    partial class CategoryForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label1 = new Label();
            panel1 = new Panel();
            TxtUserId = new TextBox();
            BtnClose = new Button();
            BtnSave = new Button();
            BtnCancel = new Button();
            GvwAssets = new DataGridView();
            ColumnAllocatedAssetId = new DataGridViewTextBoxColumn();
            Location = new DataGridViewTextBoxColumn();
            ManufacturerName = new DataGridViewTextBoxColumn();
            ColumnItemName = new DataGridViewTextBoxColumn();
            ColumnSubItemName = new DataGridViewTextBoxColumn();
            ColumnProductCode = new DataGridViewTextBoxColumn();
            ColumnSerialNo = new DataGridViewTextBoxColumn();
            CreatedBy = new DataGridViewTextBoxColumn();
            ColumnRepair = new DataGridViewButtonColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GvwAssets).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 25);
            label1.Name = "label1";
            label1.Size = new Size(127, 20);
            label1.TabIndex = 0;
            label1.Text = "Category Name";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(TxtUserId);
            panel1.Location = new Point(23, 53);
            panel1.Name = "panel1";
            panel1.Size = new Size(450, 46);
            panel1.TabIndex = 1;
            panel1.TabStop = true;
            // 
            // TxtUserId
            // 
            TxtUserId.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TxtUserId.BorderStyle = BorderStyle.None;
            TxtUserId.Location = new Point(12, 12);
            TxtUserId.MaxLength = 30;
            TxtUserId.Name = "TxtUserId";
            TxtUserId.Size = new Size(425, 21);
            TxtUserId.TabIndex = 0;
            // 
            // BtnClose
            // 
            BtnClose.BackColor = Color.Green;
            BtnClose.FlatStyle = FlatStyle.Popup;
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(611, 51);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(110, 48);
            BtnClose.TabIndex = 5;
            BtnClose.Text = "&Close";
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += BtnClose_Click;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.Green;
            BtnSave.FlatStyle = FlatStyle.Popup;
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(493, 51);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(110, 48);
            BtnSave.TabIndex = 4;
            BtnSave.Text = "&Save";
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnCancel
            // 
            BtnCancel.BackColor = Color.Green;
            BtnCancel.FlatStyle = FlatStyle.Popup;
            BtnCancel.ForeColor = Color.White;
            BtnCancel.Location = new Point(729, 51);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(110, 48);
            BtnCancel.TabIndex = 20;
            BtnCancel.Text = "Cance&l";
            BtnCancel.UseVisualStyleBackColor = false;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // GvwAssets
            // 
            GvwAssets.AllowUserToAddRows = false;
            GvwAssets.AllowUserToDeleteRows = false;
            GvwAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GvwAssets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GvwAssets.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            GvwAssets.BackgroundColor = Color.White;
            GvwAssets.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            GvwAssets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            GvwAssets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GvwAssets.Columns.AddRange(new DataGridViewColumn[] { ColumnAllocatedAssetId, Location, ManufacturerName, ColumnItemName, ColumnSubItemName, ColumnProductCode, ColumnSerialNo, CreatedBy, ColumnRepair });
            GvwAssets.EnableHeadersVisualStyles = false;
            GvwAssets.GridColor = Color.Silver;
            GvwAssets.Location = new Point(25, 115);
            GvwAssets.MultiSelect = false;
            GvwAssets.Name = "GvwAssets";
            GvwAssets.ReadOnly = true;
            GvwAssets.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            GvwAssets.RowHeadersVisible = false;
            GvwAssets.RowHeadersWidth = 51;
            dataGridViewCellStyle5.SelectionBackColor = Color.DarkRed;
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            GvwAssets.RowsDefaultCellStyle = dataGridViewCellStyle5;
            GvwAssets.RowTemplate.Height = 50;
            GvwAssets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GvwAssets.ShowCellToolTips = false;
            GvwAssets.Size = new Size(814, 218);
            GvwAssets.TabIndex = 21;
            // 
            // ColumnAllocatedAssetId
            // 
            ColumnAllocatedAssetId.DataPropertyName = "AllocatedAssetId";
            ColumnAllocatedAssetId.HeaderText = "AllocatedAssetId";
            ColumnAllocatedAssetId.MinimumWidth = 6;
            ColumnAllocatedAssetId.Name = "ColumnAllocatedAssetId";
            ColumnAllocatedAssetId.ReadOnly = true;
            ColumnAllocatedAssetId.Visible = false;
            // 
            // Location
            // 
            Location.DataPropertyName = "Location";
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            Location.DefaultCellStyle = dataGridViewCellStyle2;
            Location.HeaderText = "Location";
            Location.MinimumWidth = 6;
            Location.Name = "Location";
            Location.ReadOnly = true;
            // 
            // ManufacturerName
            // 
            ManufacturerName.DataPropertyName = "ManufacturerName";
            ManufacturerName.HeaderText = "Mfn";
            ManufacturerName.MinimumWidth = 6;
            ManufacturerName.Name = "ManufacturerName";
            ManufacturerName.ReadOnly = true;
            // 
            // ColumnItemName
            // 
            ColumnItemName.DataPropertyName = "ItemName";
            ColumnItemName.HeaderText = "Category";
            ColumnItemName.MinimumWidth = 6;
            ColumnItemName.Name = "ColumnItemName";
            ColumnItemName.ReadOnly = true;
            ColumnItemName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnSubItemName
            // 
            ColumnSubItemName.DataPropertyName = "SubItemName";
            ColumnSubItemName.HeaderText = "Specification";
            ColumnSubItemName.MinimumWidth = 6;
            ColumnSubItemName.Name = "ColumnSubItemName";
            ColumnSubItemName.ReadOnly = true;
            ColumnSubItemName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnProductCode
            // 
            ColumnProductCode.DataPropertyName = "ProductCode";
            ColumnProductCode.HeaderText = "ProductCode";
            ColumnProductCode.MinimumWidth = 6;
            ColumnProductCode.Name = "ColumnProductCode";
            ColumnProductCode.ReadOnly = true;
            ColumnProductCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnSerialNo
            // 
            ColumnSerialNo.DataPropertyName = "SerialNo";
            ColumnSerialNo.HeaderText = "SerialNo";
            ColumnSerialNo.MinimumWidth = 6;
            ColumnSerialNo.Name = "ColumnSerialNo";
            ColumnSerialNo.ReadOnly = true;
            ColumnSerialNo.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // CreatedBy
            // 
            CreatedBy.DataPropertyName = "CreatedBy";
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            CreatedBy.DefaultCellStyle = dataGridViewCellStyle3;
            CreatedBy.HeaderText = "CreatedBy";
            CreatedBy.MinimumWidth = 6;
            CreatedBy.Name = "CreatedBy";
            CreatedBy.ReadOnly = true;
            // 
            // ColumnRepair
            // 
            ColumnRepair.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            dataGridViewCellStyle4.Padding = new Padding(4);
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            ColumnRepair.DefaultCellStyle = dataGridViewCellStyle4;
            ColumnRepair.HeaderText = "";
            ColumnRepair.MinimumWidth = 6;
            ColumnRepair.Name = "ColumnRepair";
            ColumnRepair.ReadOnly = true;
            ColumnRepair.Text = "Repair";
            ColumnRepair.UseColumnTextForButtonValue = true;
            ColumnRepair.Width = 135;
            // 
            // CategoryForm
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 358);
            Controls.Add(GvwAssets);
            Controls.Add(BtnCancel);
            Controls.Add(BtnClose);
            Controls.Add(BtnSave);
            Controls.Add(panel1);
            Controls.Add(label1);
            Font = new Font("Roboto", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CategoryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Category Registration";
            Load += CategoryForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GvwAssets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TextBox TxtUserId;
        private Button BtnClose;
        private Button BtnSave;
        private Button button1;
        private Button BtnCancel;
        private DataGridView GvwAssets;
        private DataGridViewTextBoxColumn ColumnAllocatedAssetId;
        private DataGridViewTextBoxColumn Location;
        private DataGridViewTextBoxColumn ManufacturerName;
        private DataGridViewTextBoxColumn ColumnItemName;
        private DataGridViewTextBoxColumn ColumnSubItemName;
        private DataGridViewTextBoxColumn ColumnProductCode;
        private DataGridViewTextBoxColumn ColumnSerialNo;
        private DataGridViewTextBoxColumn CreatedBy;
        private DataGridViewButtonColumn ColumnRepair;
    }
}