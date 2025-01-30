using Microsoft.Extensions.DependencyInjection;
using PaybillWinApp.Models;
using PaybillWinApp.Repositories;
using PaybillWinApp.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaybillWinApp.RegisterForms
{
    public partial class OTPValidationForm : RoundedForm
    {
        private readonly ISharedRepository sharedRepository;
        private readonly IProviderRepository providerRepository;
        private readonly ISQLiteHelper sQLiteHelper;
        private ClientVM clientModel;

        public OTPValidationForm(ISharedRepository sharedRepository, IProviderRepository providerRepository, ISQLiteHelper sQLiteHelper, ClientVM clientModel)
        {
            InitializeComponent();
            this.sharedRepository = sharedRepository;
            this.providerRepository = providerRepository;
            this.sQLiteHelper = sQLiteHelper;
            this.clientModel = clientModel;
            LblBusinessType.Text = clientModel.BusinessType;
            LblClientName.Text = clientModel.ClientName;
            LblMobile.Text = clientModel.Mobile;
            LblAddress.Text = clientModel.Address;
            LblEmail.Text = clientModel.Email;
            LblApiUrl.Text = clientModel.ServiceUrl;
        }

        private async void BtnVerify_Click(object sender, EventArgs e)
        {
            if (TxtOTP.Text.Trim().Length == 0)
            {
                sharedRepository.ShowInfoMessage("OTP cannot be empty.", "Validation");
                TxtOTP.Focus();
                return;
            }

            if (TxtOTP.Text.Trim().Length != 6)
            {
                sharedRepository.ShowInfoMessage("Not a valid OTP.", "Validation");
                TxtOTP.Focus();
                return;
            }

            if (LblApiUrl.Text.Trim().Length == 0)
            {
                sharedRepository.ShowInfoMessage("API cannot be empty.", "Validation");
                return;
            }

            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            
            try
            {
                clientModel.Otp = DataProtection.UrlEncode(TxtOTP.Text, AppVariables.PAYBILL_API_AES_KEY_AND_IV);
                clientModel.ServiceUrl = DataProtection.EncryptWithIV(LblApiUrl.Text.Trim(), AppVariables.PAYBILL_API_AES_KEY_AND_IV);
                ResponseMessage responseMessage = await providerRepository.VerifyClientOTP(clientModel);
                Cursor.Current = Cursors.Default;
                if (responseMessage.IsSuccess)
                {
                    await sQLiteHelper.CreateAccount(clientModel);
                    sharedRepository.ShowSuccessMessage("Server connection established successfully.");
                    Environment.Exit(0);
                }
                else
                    sharedRepository.ShowErrorMessage(responseMessage.Message);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                sharedRepository.ShowErrorMessage(ex.Message.ToString());
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
