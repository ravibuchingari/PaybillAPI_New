using PayBillApp.WinApp.Models;
using PaybillWinApp.Models;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PayBillApp.WinApp
{
    public partial class ExitConfirmForm : Form
    {
        private readonly int borderRadius = 15;
        private readonly int borderSize = 0;
        private readonly Color borderColor = Color.Silver;

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

        public ExitConfirmForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ExitConfirm_Paint(object sender, PaintEventArgs e)
        {
            ReuseMethods.SetFormBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }
    }
}
