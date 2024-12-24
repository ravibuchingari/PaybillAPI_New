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
