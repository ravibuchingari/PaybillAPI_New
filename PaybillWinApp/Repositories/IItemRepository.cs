using PaybillWinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaybillWinApp.Repositories
{
    public interface IItemRepository
    {
        Task<List<CategoryVM>> getCategories(UserParam userParam);
    }
}
