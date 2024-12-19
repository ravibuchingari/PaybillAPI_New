using PayBillApp.WinApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PayBillApp.WinApp
{
    public partial class EditedItemForm : Form
    {
        private readonly int borderRadius = 10;
        private readonly int borderSize = 1;
        private readonly Color borderColor = Color.WhiteSmoke;

        public List<Items> CodeItems { get; set; }
        public int SelectedItemId { get; set; }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams createParams = base.CreateParams;
                createParams.ClassStyle |= CS_DROPSHADOW;
                return createParams;
            }
        }

        public int Quantity { get; set; }

        public EditedItemForm(string itemName)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.lblItemName.Text = itemName;

        }

        private void EditedItemForm_Paint(object sender, PaintEventArgs e)
        {
            ReuseMethods.SetFormBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Trim().Length == 0 || int.Parse(txtQuantity.Text) < 1)
            {
                MessageBox.Show("Quantity cannot be empty.", ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.SelectAll();
                txtQuantity.Focus();
                return;
            }
            this.Quantity = int.Parse(txtQuantity.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TxtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void EditedItemForm_Load(object sender, EventArgs e)
        {
            txtQuantity.Text = Quantity.ToString();
            txtQuantity.SelectAll();
        }
    }
}
