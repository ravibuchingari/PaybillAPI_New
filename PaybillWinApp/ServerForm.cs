using PaybillWinApp.Models;
using PaybillWinApp.Repositories;
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
    public partial class ServerForm : Form
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
            if (Properties.Settings.Default != null && Properties.Settings.Default.ApiUrl != null)
            {
                TextBoxServerUrl.Text = Properties.Settings.Default.ApiUrl;
                TextBoxServerUrl.SelectionStart = TextBoxServerUrl.Text.Length;
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void ButtonSet_Click(object sender, EventArgs e)
        {
            string url = TextBoxServerUrl.Text.Trim();
            if (url.Substring(url.Length - 1) != "/")
                url = $"{url}/";

            try
            {
                string response = await commonRepository.PingServer();

                if(DateTime.Now.Date == Convert.ToDateTime(response).Date)
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
    }
}
