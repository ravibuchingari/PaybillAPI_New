using PaybillWinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaybillWinApp.Repositories
{
    public class SharedRepository : ISharedRepository
    {
        public void ShowInfoMessage(string message, string title = "Required")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowWarningMessage(string message, string title = "Required")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowErrorMessage(string message, string title = "Error")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSuccessMessage(string message, string title = "Success")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DialogResult DeleteConfirm(string item, string value = "", string title = "Confirm Delete!!")
        {
            if (value.Length > 0)
                return MessageBox.Show($"Are you sure do you want to delete this {item} '{value}'?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            else
                return MessageBox.Show($"Are you sure do you want to delete this {item}?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public DialogResult Confirm(string message, string title = "Confirmation")
        {
            return MessageBox.Show($"Are you sure do you want to {message}?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
