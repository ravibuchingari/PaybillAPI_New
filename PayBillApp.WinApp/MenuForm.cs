using PayBillApp.WinApp.Models;
using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PayBillApp.WinApp
{
    public partial class MenuForm : Form
    {
        private readonly int borderRadius = 10;
        private readonly int borderSize = 1;
        private readonly Color borderColor = Color.WhiteSmoke;

        public int SelectedItem { get; set; }

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
        public MenuForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
        }

        private void Menu_Paint(object sender, PaintEventArgs e)
        {
            ReuseMethods.SetFormBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void CloseMenu_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnLoadUtilities_Click(object sender, EventArgs e)
        {
            this.SelectedItem = (int)EnumClass.MenuItem.LoadUtilities;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LbnMinimise_Click(object sender, EventArgs e)
        {
            this.SelectedItem = (int)EnumClass.MenuItem.Minimize;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            lblUserName.Text = $"Hi {new CultureInfo("en-US", false).TextInfo.ToTitleCase(ConstantVariables.DISPLAY_NAME)}";
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            this.SelectedItem = (int)EnumClass.MenuItem.Reset;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnViewSales_Click(object sender, EventArgs e)
        {
            this.SelectedItem = (int)EnumClass.MenuItem.ViewSales;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            this.SelectedItem = (int)EnumClass.MenuItem.Settings;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
