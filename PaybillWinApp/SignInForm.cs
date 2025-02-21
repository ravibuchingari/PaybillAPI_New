using Microsoft.Extensions.DependencyInjection;
using PaybillWinApp.Models;
using PaybillWinApp.RegisterForms;
using PaybillWinApp.Repositories;
using PaybillWinApp.UserControls;
using System.Data;
using System.Text;

namespace PaybillWinApp
{
    public partial class SignInForm : RoundedForm
    {
        private readonly ICommonRepository commonRepository;
        private readonly ISQLiteHelper sQLiteHelper;
        private readonly ISharedRepository sharedRepository;

        public SignInForm(ISharedRepository sharedRepository, ICommonRepository commonRepository, ISQLiteHelper sQLiteHelper)
        {
            InitializeComponent();
            this.commonRepository = commonRepository;
            this.sQLiteHelper = sQLiteHelper;
            this.sharedRepository = sharedRepository;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            AppVariables.API_BASE_URL = Properties.Settings.Default.ApiUrl.Trim();
            if (AppVariables.API_BASE_URL.Substring(AppVariables.API_BASE_URL.Length - 1) != "/")
                AppVariables.API_BASE_URL = $"{AppVariables.API_BASE_URL}/";
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void LinkLabelServerConfig_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientValidationForm serverForm = AppVariables.ServiceProvider!.GetRequiredService<ClientValidationForm>();
            serverForm.ShowDialog();
        }

        private async void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (TxtUserId.Text.Trim().Length == 0)
            {
                sharedRepository.ShowErrorMessage("User Id cannot be empty.", "Validation");
                TxtUserId.Focus();
                return;
            }

            if (TxtPassword.Text.Trim().Length == 0)
            {
                sharedRepository.ShowErrorMessage("User Id cannot be empty.", "Validation");
                TxtPassword.Focus();
                return;
            }

            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                BtnSignIn.Enabled = false;

                DataTable dataTablePref = await sQLiteHelper.GetClientPref();

                if(dataTablePref == null || dataTablePref.Rows.Count == 0)
                {
                    sharedRepository.ShowInfoMessage("No client configurations were found.");
                    return;
                }

                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;

                AuthRequestVM authRequest = new()
                {
                    ClientUniqueId = dataTablePref.Rows[0]["clientUniqueId"].ToString()!,
                    ClientId = dataTablePref.Rows[0]["clientId"].ToString()!,
                    UserId = TxtUserId.Text.Trim(),
                    Password = DataProtection.EncryptWithIV(TxtPassword.Text.Trim(), AppVariables.PAYBILL_API_AES_KEY_AND_IV),
                    BiometricAuthKey = ""
                };

                AppVariables.API_BASE_URL = DataProtection.DecryptWithIV(dataTablePref.Rows[0]["serviceUrl"].ToString()!, AppVariables.PAYBILL_API_AES_KEY_AND_IV);

                AuthResponseVM response = await commonRepository.Authenticate(authRequest);

                Cursor.Current = Cursors.Default;

                if (response.IsSuccess)
                {
                    AppVariables.User = response.User;
                    AppVariables.DashboardPref = response.Pref;
                    AppVariables.UserParameter = new UserParam()
                    {
                        UserRowId = response.User.UserRowId,
                        SecurityKey = response.User.SecurityKey!,
                        ClientUniqueId = response.User.Client?.ClientUniqueId!,
                        ClientId = response.User.Client?.ClientId!
                    };

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    sharedRepository.ShowErrorMessage("Security information failed!", "Validation");
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                sharedRepository.ShowErrorMessage(ex.Message.ToString(), "Validation");
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
            AppVariables.ServiceProvider!.GetRequiredService<ClientValidationForm>().Show();
        }
    }
}
