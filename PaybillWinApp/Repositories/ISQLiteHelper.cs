using PaybillWinApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaybillWinApp.Repositories
{
    public interface ISQLiteHelper
    {
        Task<int> CreateAccount(ClientVM client);
        Task<DataTable> GetClientPref();
    }
}
