using PaybillWinApp.Repositories;
using PaybillWinApp.UserControls;
using System.Drawing.Drawing2D;

namespace PaybillWinApp
{
    public partial class ServerForm : RoundedForm
    {
        private readonly ICommonRepository commonRepository;
        private readonly ISharedRepository sharedRepository;

        public ServerForm(ICommonRepository commonRepository, ISharedRepository sharedRepository)
        {
            InitializeComponent();
            this.commonRepository = commonRepository;
            this.sharedRepository = sharedRepository;
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            //if (Properties.Settings.Default != null && Properties.Settings.Default.ApiUrl != null)
            //{
            //    TxtMobile.Text = Properties.Settings.Default.ApiUrl;
            //    TxtMobile.SelectionStart = TxtMobile.Text.Length;
            //}
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void ButtonSet_Click(object sender, EventArgs e)
        {
            string url = TxtMobile.Text.Trim();
            if (url.Substring(url.Length - 1) != "/")
                url = $"{url}/";

            try
            {
                string response = await commonRepository.TestServer();

                if (DateTime.Now.Date == Convert.ToDateTime(response).Date)
                {
                    Properties.Settings.Default.ApiUrl = url;
                    Properties.Settings.Default.Save();
                    sharedRepository.ShowSuccessMessage("Server connection established successfully.");
                    Environment.Exit(0);
                }
                else
                    sharedRepository.ShowInfoMessage("Unable to connect the server. Please the url and try again!");

            }
            catch (Exception ex)
            {
                sharedRepository.ShowErrorMessage(ex.Message.ToString());
            }
        }

        private void PnlMobile_Click(object sender, EventArgs e)
        {
            TxtMobile.Focus();
        }
    }
}
