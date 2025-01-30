using PaybillWinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaybillWinApp.Repositories
{
    public interface IProviderRepository
    {
        Task<ResponseMessage> VerifyClientAccount(string mobile);
        Task<ResponseMessage> VerifyClientOTP(ClientVM client);
    }
}
