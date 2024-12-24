using PaybillWinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaybillWinApp.Repositories
{
    public class CommonRepository : BaseRepository, ICommonRepository
    {
        public async Task<string> PingServer()
        {
            return await GetApiDataAsync("server/test");
        }

    }
}
