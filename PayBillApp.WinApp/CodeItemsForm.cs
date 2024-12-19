using PayBillApp.WinApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PayBillApp.WinApp
{
    public partial class CodeItemsForm : Form
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

        public CodeItemsForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
        }

        private void CodeItemsForm_Paint(object sender, PaintEventArgs e)
        {
            ReuseMethods.SetFormBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CodeItemsForm_Load(object sender, EventArgs e)
        {
            gvwItems.DataSource = CodeItems;
        }


        private void GvwItems_DoubleClick(object sender, EventArgs e)
        {
            if (gvwItems.CurrentRow.Selected)
                SelectItem();
        }

        private void GvwItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gvwItems.CurrentRow.Selected)
                    SelectItem();
                else
                    MessageBox.Show("Item is not selected.", ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SelectItem()
        {
            SelectedItemId = Convert.ToInt32(gvwItems.CurrentRow.Cells[0].Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
