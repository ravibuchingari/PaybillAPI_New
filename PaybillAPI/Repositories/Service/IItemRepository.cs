using PaybillAPI.Models;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories.Service
{
    public interface IItemRepository
    {
        Task<ResponseMessage> DeleteCategory(int categoryId);
        Task<ResponseMessage> DeleteGST(int gstId);
        Task<IEnumerable<CategoryVM>> GetCategories();
        Task<CategoryVM> GetCategoryDetails(int categoryId);
        Task<GstVM> GetGstDetails(int gstId);
        Task<IEnumerable<GstVM>> GetGsts(bool isActive);
        Task<IEnumerable<ItemVM>> GetMinStockItems();
        Task<ResponseMessage> UpsertCategory(CategoryVM categoryVM, int userRowId);
        Task<ResponseMessage> UpsertGst(GstVM gstVM, int userRowId);
    }
}
