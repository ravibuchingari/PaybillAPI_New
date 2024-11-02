using PaybillAPI.Models;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories.Service
{
    public interface IItemRepository
    {
        Task<ResponseMessage> DeleteCategory(int categoryId);
        Task<ResponseMessage> DeleteGST(int gstId);
        Task<ResponseMessage> DeleteItem(int itemId);
        Task<IEnumerable<CategoryVM>> GetCategories();
        Task<CategoryVM> GetCategoryDetails(int categoryId);
        Task<GstVM> GetGstDetails(int gstId);
        Task<IEnumerable<GstVM>> GetGsts(bool isActive);
        Task<ItemVM> GetItemDetails(int itemId);
        //Task<ItemVM?> GetItemDetailsOnCode(string itemCode);
        Task<IEnumerable<ItemVM>> GetItems(string filter);
        Task<IEnumerable<ItemVM>> GetMinStockItems();
        Task<IEnumerable<ItemVM>> GetItemsForOffline(bool isAllItems, string? lastUpdatedTime);
        Task<ResponseMessage> UpsertCategory(CategoryVM categoryVM, int userRowId);
        Task<ResponseMessage> UpsertGst(GstVM gstVM, int userRowId);
        Task<ResponseMessage> UpsertItem(ItemVM itemVM, int userRowId);
        Task<IEnumerable<ItemVM>> SearchItems(string filter);
        Task<IEnumerable<ItemVM>> GetItemsOnCode(string itemCode);
        Task<ResponseMessage> ResetStock();
    }
}
