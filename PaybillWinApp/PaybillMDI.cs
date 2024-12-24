using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaybillWinApp
{
    public partial class PaybillMDI : Form
    {
        public PaybillMDI()
        {
            InitializeComponent();
            //Models.SkinManager.Instance.MaterialManager.AddFormToManage(this);
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Show();
        }

    }
}
