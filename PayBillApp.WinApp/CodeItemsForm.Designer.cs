namespace PayBillApp.WinApp
{
    partial class CodeItemsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gvwItems = new System.Windows.Forms.DataGridView();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemMRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemAaliasNname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDiscountPer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemGSTPer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalLanguage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvwItems)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnCancel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(623, 431);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 58);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // gvwItems
            // 
            this.gvwItems.AllowUserToAddRows = false;
            this.gvwItems.AllowUserToDeleteRows = false;
            this.gvwItems.AllowUserToResizeRows = false;
            this.gvwItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvwItems.BackgroundColor = System.Drawing.Color.White;
            this.gvwItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvwItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gvwItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvwItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvwItems.ColumnHeadersHeight = 30;
            this.gvwItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemId,
            this.ItemCode,
            this.ItemName,
            this.ItemMRP,
            this.ItemPrice,
            this.ItemAaliasNname,
            this.ItemDiscountPer,
            this.ItemGSTPer,
            this.LocalLanguage});
            this.gvwItems.GridColor = System.Drawing.Color.WhiteSmoke;
            this.gvwItems.Location = new System.Drawing.Point(18, 21);
            this.gvwItems.MultiSelect = false;
            this.gvwItems.Name = "gvwItems";
            this.gvwItems.ReadOnly = true;
            this.gvwItems.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.gvwItems.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gvwItems.RowTemplate.Height = 40;
            this.gvwItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvwItems.Size = new System.Drawing.Size(709, 386);
            this.gvwItems.TabIndex = 0;
            this.gvwItems.DoubleClick += new System.EventHandler(this.GvwItems_DoubleClick);
            this.gvwItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GvwItems_KeyDown);
            // 
            // ItemId
            // 
            this.ItemId.DataPropertyName = "ItemId";
            this.ItemId.HeaderText = "ItemId";
            this.ItemId.Name = "ItemId";
            this.ItemId.ReadOnly = true;
            this.ItemId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ItemId.Visible = false;
            // 
            // ItemCode
            // 
            this.ItemCode.DataPropertyName = "ItemCode";
            this.ItemCode.HeaderText = "Code";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.ReadOnly = true;
            this.ItemCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ItemCode.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ItemMRP
            // 
            this.ItemMRP.DataPropertyName = "ItemMRP";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ItemMRP.DefaultCellStyle = dataGridViewCellStyle2;
            this.ItemMRP.HeaderText = "MRP";
            this.ItemMRP.Name = "ItemMRP";
            this.ItemMRP.ReadOnly = true;
            this.ItemMRP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ItemPrice
            // 
            this.ItemPrice.DataPropertyName = "ItemPrice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ItemPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.ItemPrice.HeaderText = "Price";
            this.ItemPrice.Name = "ItemPrice";
            this.ItemPrice.ReadOnly = true;
            this.ItemPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ItemAaliasNname
            // 
            this.ItemAaliasNname.DataPropertyName = "ItemAaliasNname";
            this.ItemAaliasNname.HeaderText = "ItemAaliasNname";
            this.ItemAaliasNname.Name = "ItemAaliasNname";
            this.ItemAaliasNname.ReadOnly = true;
            this.ItemAaliasNname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ItemAaliasNname.Visible = false;
            // 
            // ItemDiscountPer
            // 
            this.ItemDiscountPer.DataPropertyName = "ItemDiscountPer";
            this.ItemDiscountPer.HeaderText = "ItemDiscountPer";
            this.ItemDiscountPer.Name = "ItemDiscountPer";
            this.ItemDiscountPer.ReadOnly = true;
            this.ItemDiscountPer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ItemDiscountPer.Visible = false;
            // 
            // ItemGSTPer
            // 
            this.ItemGSTPer.DataPropertyName = "ItemGSTPer";
            this.ItemGSTPer.HeaderText = "ItemGSTPer";
            this.ItemGSTPer.Name = "ItemGSTPer";
            this.ItemGSTPer.ReadOnly = true;
            this.ItemGSTPer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ItemGSTPer.Visible = false;
            // 
            // LocalLanguage
            // 
            this.LocalLanguage.DataPropertyName = "LocalLanguage";
            this.LocalLanguage.HeaderText = "LocalLanguage";
            this.LocalLanguage.Name = "LocalLanguage";
            this.LocalLanguage.ReadOnly = true;
            this.LocalLanguage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LocalLanguage.Visible = false;
            // 
            // CodeItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(746, 506);
            this.ControlBox = false;
            this.Controls.Add(this.gvwItems);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CodeItemsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CodeItemsForm";
            this.Load += new System.EventHandler(this.CodeItemsForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CodeItemsForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.gvwItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView gvwItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemMRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemAaliasNname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemDiscountPer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemGSTPer;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalLanguage;
    }
}