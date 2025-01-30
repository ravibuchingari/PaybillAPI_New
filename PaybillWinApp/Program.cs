using Microsoft.Extensions.DependencyInjection;
using PaybillWinApp.Models;
using PaybillWinApp.RegisterForms;
using PaybillWinApp.Repositories;
using System.Configuration;

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
            services.AddTransient<ClientValidationForm>();
            services.AddTransient<OTPValidationForm>();


            services.AddSingleton<ISharedRepository, SharedRepository>();
            services.AddSingleton<ICommonRepository, CommonRepository>();
            services.AddSingleton<IProviderRepository, ProviderRepository>();
            services.AddSingleton<ISQLiteHelper, SQLiteHelper>();

            AppVariables.ServiceProvider = services.BuildServiceProvider();

            AppVariables.SQLITE_DB = string.Format(AppVariables.SQLITE_DB, System.IO.Path.Combine(Application.StartupPath, ConfigurationManager.AppSettings["sqlDB"] ?? "paybill.db"), ConfigurationManager.AppSettings["sqlVersion"] ?? "3");

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
                Application.Run(AppVariables.ServiceProvider.GetRequiredService<ClientValidationForm>());
            }
        }
    }
}