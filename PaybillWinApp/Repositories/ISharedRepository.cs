using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaybillWinApp.Repositories
{
    public interface ISharedRepository
    {
        DialogResult Confirm(string message, string title = "Confirmation");
        DialogResult DeleteConfirm(string item, string value = "", string title = "Confirm Delete!!");
        void ShowErrorMessage(string message, string title = "Error");
        void ShowInfoMessage(string message, string title = "Required");
        void ShowSuccessMessage(string message, string title = "Success");
        void ShowWarningMessage(string message, string title = "Required");
    }
}
