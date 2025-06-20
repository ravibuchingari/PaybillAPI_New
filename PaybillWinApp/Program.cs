using Microsoft.Extensions.DependencyInjection;
using PayBillApp.WinApp;
using PaybillWinApp.MasterForms;
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
            services.AddTransient<SignInForm>();
            services.AddTransient<ClientValidationForm>();
            services.AddTransient<OTPValidationForm>();
            services.AddTransient<SalesInvoiceForm>();
            services.AddTransient<CategoryForm>();


            services.AddSingleton<ISharedRepository, SharedRepository>();
            services.AddSingleton<ICommonRepository, CommonRepository>();
            services.AddSingleton<IProviderRepository, ProviderRepository>();
            services.AddSingleton<ISQLiteHelper, SQLiteHelper>();
            services.AddSingleton<IItemRepository, ItemRepository>();

            AppVariables.ServiceProvider = services.BuildServiceProvider();

            AppVariables.SQLITE_DB = string.Format(AppVariables.SQLITE_DB, System.IO.Path.Combine(Application.StartupPath, ConfigurationManager.AppSettings["sqlDB"] ?? "paybill.db"), ConfigurationManager.AppSettings["sqlVersion"] ?? "3");

            if (Properties.Settings.Default != null && !string.IsNullOrWhiteSpace(Properties.Settings.Default.ApiUrl))
            {
                SignInForm signInForm = AppVariables.ServiceProvider.GetRequiredService<SignInForm>();

                Application.Run(signInForm);

                if (signInForm.DialogResult == DialogResult.OK)
                {
                    SalesInvoiceForm salesInvoiceForm = AppVariables.ServiceProvider.GetRequiredService<SalesInvoiceForm>();
                    Application.Run(salesInvoiceForm);
                }
            }
            else
            {
                Application.Run(AppVariables.ServiceProvider.GetRequiredService<ClientValidationForm>());
            }
        }
    }
}