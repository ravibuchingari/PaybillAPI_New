using PayBillApp.WinApp.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;

namespace PayBillApp.WinApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!IsServiceRunning())
            {
                if (HasWritePermission())
                {
                    LoginScanner loginScanner = new();
                    Application.Run(loginScanner);
                    if (loginScanner.DialogResult == DialogResult.OK)
                        Application.Run(new SalesInvoiceForm());
                }
                else
                {
                    MessageBox.Show("Please provide read and write persmission on root folder.", ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = Application.StartupPath,
                        UseShellExecute = true,
                        Verb = "open"
                    });
                }
            }
            else
                MessageBox.Show("PayBillApp is already running...", ConstantVariables.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        static bool IsServiceRunning()
        {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).GetUpperBound(0) > 0)
                return true;
            else
                return false;
        }

        static bool HasWritePermission()
        {
            try
            {
                DirectoryInfo directoryInfo = new(Application.StartupPath);
                DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
                AuthorizationRuleCollection ruleCollection = directorySecurity.GetAccessRules(true, true, typeof(NTAccount));
                WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new(currentUser);
                foreach (AuthorizationRule rule in ruleCollection)
                {
                    if (rule is not FileSystemAccessRule accessRule)
                        continue;
                    if ((accessRule.FileSystemRights & FileSystemRights.WriteData) > 0)
                    {
                        NTAccount ntAccount = rule.IdentityReference as NTAccount;
                        if (ntAccount == null)
                            continue;
                        if (principal.IsInRole(ntAccount.Value))
                            return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
