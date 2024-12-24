using MaterialSkin;
using Microsoft.Extensions.DependencyInjection;
using PaybillWinApp.Models;
using PaybillWinApp.Repositories;

namespace PaybillWinApp
{
    public partial class SignInForm : Form
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

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LinkLabelServerConfig_Click(object sender, EventArgs e)
        {
            ServerForm serverForm = AppVariables.ServiceProvider!.GetRequiredService<ServerForm>();
            serverForm.ShowDialog();
        }
    }
}
