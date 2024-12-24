using Microsoft.Extensions.DependencyInjection;
using PaybillWinApp.Models;
using PaybillWinApp.Repositories;
using PaybillWinApp.UserControls;
using System.Text;

namespace PaybillWinApp
{
    public partial class SignInForm : RoundedForm
    {
        private readonly ICommonRepository commonRepository;
        private readonly ISharedRepository sharedRepository;

        public SignInForm(ISharedRepository sharedRepository, ICommonRepository commonRepository)
        {
            InitializeComponent();
            this.commonRepository = commonRepository;
            this.sharedRepository = sharedRepository;

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            AppVariables.ApiUrl = Properties.Settings.Default.ApiUrl.Trim();
            if (AppVariables.ApiUrl.Substring(AppVariables.ApiUrl.Length - 1) != "/")
                AppVariables.ApiUrl = $"{AppVariables.ApiUrl}/";
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void LinkLabelServerConfig_Click(object sender, EventArgs e)
        {
            this.Hide();
            ServerForm serverForm = AppVariables.ServiceProvider!.GetRequiredService<ServerForm>();
            serverForm.ShowDialog();
        }

        private async void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (TxtUserId.Text.Trim().Length == 0)
            {
                sharedRepository.ShowInfoMessage("User Id cannot be empty.", "Validation");
                TxtUserId.Focus();
                return;
            }

            if (TxtPassword.Text.Trim().Length == 0)
            {
                sharedRepository.ShowInfoMessage("User Id cannot be empty.", "Validation");
                TxtPassword.Focus();
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                BtnSignIn.Enabled = false;

                AuthRequestVM authRequest = new AuthRequestVM();
                authRequest.ClientUniqueId = "1";
                authRequest.ClientId = "132";
                authRequest.UserId = TxtUserId.Text.Trim();
                authRequest.Password = TxtPassword.Text.Trim();
                authRequest.BiometricAuthKey = "";

                AuthenticationResponse response = await commonRepository.Authenticate(authRequest);

                //var result = await ApiHelper.GetApiDataAsync<MyDataType>("getDataAction");
                //if (result is ResponseMessage responseMessage && !responseMessage.IsSuccess)

                //string userSalt = await userRepository.GetUserSaltAsync(0, TxtUserId.Text.Trim());

                //if (!string.IsNullOrWhiteSpace(userSalt))
                //{
                //    string password = DataProtection.EncryptWithIV(Convert.ToBase64String(DataProtection.GetSaltHasPassword(Encoding.ASCII.GetBytes(TxtPassword.Text.Trim()), Convert.FromBase64String(DataProtection.DecryptWithIV(userSalt, AppVariables.APP_AES_KEY_AND_IV)))), AppVariables.APP_AES_KEY_AND_IV);

                //    TblUser? user = await userRepository.ValidateCredentialsAsync(TxtUserId.Text.Trim(), password, userSalt);

                //    if (user != null)
                //    {
                //        AppVariables.USER_ROWID = user.UserRowId;
                //        AppVariables.USER_NAME = $"{user.FirstName} {user.LastName}";
                //        AppVariables.IS_ADMIN = user.IsAdmin == 1;
                //        AppVariables.IS_READONLY = user.IsReadonly == 1;
                //        AppVariables.QRCODE_PRINTER_NAME = user.QrcorPrinter ?? string.Empty;
                //        Cursor.Current = Cursors.Default;
                //        this.DialogResult = DialogResult.OK;
                //        this.Close();
                //    }
                //    else
                //    {
                //        Cursor.Current = Cursors.Default;
                //        sharedRepository.ShowWarningMessage("Security information failed.", "Validation Failed");
                //    }
                //}
                //else
                //{
                //    Cursor.Current = Cursors.Default;
                //    sharedRepository.ShowWarningMessage("Security information failed.", "Validation Failed");
                //}
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                sharedRepository.ShowErrorMessage(ex.Message.ToString());
            }
            finally
            {
                BtnSignIn.Enabled = true;
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            TxtUserId.Focus();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            TxtPassword.Focus();
        }

        private void LinkLabelServerConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ServerForm serverForm = AppVariables.ServiceProvider!.GetRequiredService<ServerForm>();
            serverForm.ShowDialog();
        }
    }
}
