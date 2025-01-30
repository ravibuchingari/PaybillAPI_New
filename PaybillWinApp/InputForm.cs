using PaybillWinApp.UserControls;
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
    public partial class InputForm : RoundedForm
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ServiceUrl
        {
            get { return TxtInput.Text.Trim(); }
            set { TxtInput.Text = value; }
        }


        public InputForm(string lable)
        {
            InitializeComponent();
            LblInput.Text = lable;
        }

       

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if(TxtInput.Text.Trim().Length == 0)
            {
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
