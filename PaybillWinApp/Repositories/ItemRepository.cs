using PaybillWinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaybillWinApp.Repositories
{
    public class ItemRepository: BaseRepository, IItemRepository
    {
        public async Task<List<CategoryVM>> getCategories(UserParam userParam) => await PostApiDataAsync<List<CategoryVM>>(Controller.Item.ToString(), "category/list", userParam);
    }
}
