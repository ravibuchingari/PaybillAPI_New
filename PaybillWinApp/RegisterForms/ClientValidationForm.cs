using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PaybillWinApp.Models;
using PaybillWinApp.Repositories;
using PaybillWinApp.UserControls;
using System.Drawing.Drawing2D;
using System.Text.Json.Serialization;

namespace PaybillWinApp.RegisterForms
{
    public partial class ClientValidationForm : RoundedForm
    {
        private readonly IProviderRepository providerRepository;
        private readonly ISharedRepository sharedRepository;
        private readonly IServiceProvider serviceProvider;

        public ClientValidationForm(ISharedRepository sharedRepository, IProviderRepository providerRepository, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.providerRepository = providerRepository;
            this.sharedRepository = sharedRepository;
            this.serviceProvider = serviceProvider;
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            //Properties.Settings.Default.ApiUrl = "http://localhost/paybillapi/api/";
            //Properties.Settings.Default.Save();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private async void ButtonSet_Click(object sender, EventArgs e)
        {
            if (TxtMobile.Text.Trim().Length == 0)
            {
                sharedRepository.ShowInfoMessage("Client mobile cannot be empty.", "Validation");
                TxtMobile.Focus();
                return;
            }
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ResponseMessage responseMessage = await providerRepository.VerifyClientAccount(TxtMobile.Text.Trim());
                Cursor.Current = Cursors.Default;
                if (responseMessage.IsSuccess)
                {
                    ClientVM? clientModel = JsonConvert.DeserializeObject<ClientVM>(responseMessage.Data?.ToString()!);
                    if (clientModel != null)
                    {
                        if(!clientModel.IsApiService)
                        {
                            sharedRepository.ShowInfoMessage("You are not permitted to access the desktop user. Please contact the service provider");
                            TxtMobile.SelectAll();
                            TxtMobile.Focus();
                            return;
                        }

                        Hide();
                        OTPValidationForm otpForm = ActivatorUtilities.CreateInstance<OTPValidationForm>(serviceProvider, clientModel);
                        otpForm.Show();
                    }
                    else
                        sharedRepository.ShowInfoMessage("Unable to get the client details. Please try again!");  
                }
                else
                    sharedRepository.ShowInfoMessage(responseMessage.Message);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                sharedRepository.ShowErrorMessage(ex.Message.ToString());
            }
            
        }

        private void PnlMobile_Click(object sender, EventArgs e)
        {
            TxtMobile.Focus();
        }

        private void TxtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
                e.Handled = true;
        }
    }
}
