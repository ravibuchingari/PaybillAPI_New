using PaybillWinApp.Models;
using PaybillWinApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaybillWinApp.MasterForms
{
    public partial class CategoryForm : Form
    {
        private readonly ICommonRepository commonRepository;
        private readonly IItemRepository itemRepository;
        private readonly ISharedRepository sharedRepository;

        public CategoryForm(ISharedRepository sharedRepository, ICommonRepository commonRepository, IItemRepository itemRepository)
        {
            InitializeComponent();
            this.commonRepository = commonRepository;
            this.itemRepository = itemRepository;
            this.sharedRepository = sharedRepository;
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            GetCategories();
        }

        private async Task GetCategories()
        {
            try
            {
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
                
                var response = await itemRepository.getCategories(AppVariables.UserParameter);

                Cursor.Current = Cursors.Default;
               
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                sharedRepository.ShowErrorMessage(ex.Message.ToString(), "Validation");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        
    }
}
