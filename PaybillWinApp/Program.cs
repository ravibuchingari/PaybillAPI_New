using Microsoft.Extensions.DependencyInjection;
using PaybillWinApp.Models;
using PaybillWinApp.Repositories;

namespace PaybillWinApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            services.AddTransient<PaybillMDI>();
            services.AddTransient<SignInForm>();
            services.AddTransient<ServerForm>();


            services.AddSingleton<ISharedRepository, SharedRepository>();
            services.AddSingleton<ICommonRepository, CommonRepository>();

            AppVariables.ServiceProvider = services.BuildServiceProvider();

            if (Properties.Settings.Default != null && !string.IsNullOrWhiteSpace(Properties.Settings.Default.ApiUrl))
            {
                SignInForm signInForm = AppVariables.ServiceProvider.GetRequiredService<SignInForm>();

                Application.Run(signInForm);

                if (signInForm.DialogResult == DialogResult.OK)
                {
                    PaybillMDI paybillMDI = AppVariables.ServiceProvider.GetRequiredService<PaybillMDI>();
                    Application.Run(paybillMDI);
                }
            }
            else
            {
                Application.Run(AppVariables.ServiceProvider.GetRequiredService<ServerForm>());
            }
        }
    }
}