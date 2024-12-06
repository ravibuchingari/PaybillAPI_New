using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Controllers
{
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(IItemRepository itemRepository, ISharedRepository sharedRepository) : ControllerBase
    {
        #region "Category"

        [HttpPost]
        [Route("category/upsert")]
        public async Task<IActionResult> UpsertCategory([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await itemRepository.UpsertCategory(userParam.CategoryModel!, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("category/create")]
        public async Task<IActionResult> CreateCategoryIfNotExists([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await itemRepository.CreateCategoryIfNotExists(userParam.CategoryModel!.CategoryName!, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("category/list")]
        public async Task<IActionResult> GetCategories([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await itemRepository.GetCategories());
        }

        [HttpPost]
        [Route("category/{categoryId}/details")]
        public async Task<IActionResult> GetCategoryDetails([FromRoute] string categoryId)
        {
            categoryId = DataProtection.UrlDecode(categoryId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await itemRepository.GetCategoryDetails(int.Parse(categoryId)));
        }

        [HttpPost]
        [Route("category/{categoryId}/delete")]
        public async Task<IActionResult> DeleteCategory([FromBody] UserParam userParam, [FromRoute] string categoryId)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            categoryId = DataProtection.UrlDecode(categoryId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await itemRepository.DeleteCategory(int.Parse(categoryId)));
        }

        [HttpGet]
        [Route("category/report")]
        public async Task<IActionResult> GetCategoriesWithItemCount()
        {
            return Ok(await itemRepository.GetCategoriesWithItemCount());
        }

        #endregion

        #region "GST"

        [HttpPost]
        [Route("gst/upsert")]
        public async Task<IActionResult> UpsertGst([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await itemRepository.UpsertGst(userParam.GstModel!, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("gst/create")]
        public async Task<IActionResult> CreateGstIfNotExists([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await itemRepository.CreateGstIfNotExists(userParam.GstModel!, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("gst/list/{isActive}")]
        public async Task<IActionResult> GetGsts([FromBody] UserParam userParam, [FromRoute] bool isActive)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await itemRepository.GetGsts(isActive));
        }

        [HttpPost]
        [Route("gst/{gstId}/details")]
        public async Task<IActionResult> GetGstDetails([FromRoute] string gstId)
        {
            gstId = DataProtection.UrlDecode(gstId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await itemRepository.GetGstDetails(int.Parse(gstId)));
        }

        [HttpPost]
        [Route("gst/{gstId}/delete")]
        public async Task<IActionResult> DeleteGST([FromBody] UserParam userParam, [FromRoute] string gstId)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            gstId = DataProtection.UrlDecode(gstId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await itemRepository.DeleteGST(int.Parse(gstId)));
        }


        #endregion

        #region "Item"

        [HttpPost]
        [Route("item/upsert")]
        public async Task<IActionResult> UpsertItem([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await itemRepository.UpsertItem(userParam.ItemModel!, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("item/upload/{userRowId}/{securityKey}")]
        public async Task<IActionResult> UploadItems([FromBody] List<ItemVM> items, [FromRoute] string userRowId, [FromRoute] string securityKey)
        {
            userRowId = DataProtection.UrlDecode(userRowId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            securityKey = DataProtection.UrlDecode(securityKey, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            if (!await sharedRepository.IsValidUser(int.Parse(userRowId), securityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            if (items.Count == 0)
                return BadRequest("No item(s) found");
            return Ok(await itemRepository.UploadItems(items!, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpGet]
        [Route("item/{categoryId}/list/")]
        public async Task<IActionResult> GetItems([FromRoute] int categoryId, [FromQuery] string? filter)
        {
            return Ok(await itemRepository.GetItems(categoryId, filter ?? string.Empty));
        }

        [HttpGet]
        [Route("item/{itemId}/details")]
        public async Task<IActionResult> GetItemDetails([FromRoute] string itemId)
        {
            itemId = DataProtection.UrlDecode(itemId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await itemRepository.GetItemDetails(int.Parse(itemId)));
        }

        [HttpPost]
        [Route("item/{itemId}/delete")]
        public async Task<IActionResult> DeleteItem([FromBody] UserParam userParam, [FromRoute] string itemId)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            itemId = DataProtection.UrlDecode(itemId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await itemRepository.DeleteItem(int.Parse(itemId)));
        }


        [HttpPost]
        [Route("min/stock/list")]
        public async Task<IActionResult> GetMinStockItems([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await itemRepository.GetMinStockItems());
        }

        [HttpGet]
        [Route("items/for/offline/{isAllItems}/{lastUpdatedTime?}")]
        public async Task<IActionResult> GetItemsForOffline([FromRoute] bool isAllItems, [FromRoute] string? lastUpdatedTime)
        {
            return Ok(await itemRepository.GetItemsForOffline(isAllItems, lastUpdatedTime));
        }

        [HttpGet]
        [Route("item/search")]
        public async Task<IActionResult> SearchItems([FromQuery] string? filter)
        {
            return Ok(await itemRepository.SearchItems(filter ?? string.Empty));
        }

        [HttpGet]
        [Route("items/code/{itemCode}")]
        public async Task<IActionResult> GetItemsOnCode([FromRoute] string itemCode)
        {
            return Ok(await itemRepository.GetItemsOnCode(itemCode));
        }

        [HttpPost]
        [Route("items/reset")]
        public async Task<IActionResult> ResetStock()
        {
            return Ok(await itemRepository.ResetStock());
        }



        #endregion

        #region "Service Type"

        [HttpPost]
        [Route("service/upsert")]
        public async Task<IActionResult> UpsertServiceType([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await itemRepository.UpsertServiceType(userParam.ServiceTypeModel!, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpGet]
        [Route("service/list/{isAll}")]
        public async Task<IActionResult> GetServiceTypes([FromRoute] bool isAll)
        {
            return Ok(await itemRepository.GetServiceTypes(isAll));
        }

        [HttpGet]
        [Route("service/{serviceTypeId}/details")]
        public async Task<IActionResult> GetServiceTypeDetails([FromRoute] string serviceTypeId)
        {
            serviceTypeId = DataProtection.UrlDecode(serviceTypeId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await itemRepository.GetServiceTypeDetails(int.Parse(serviceTypeId)));
        }

        [HttpPost]
        [Route("service/{serviceTypeId}/delete")]
        public async Task<IActionResult> DeleteServiceType([FromBody] UserParam userParam, [FromRoute] string serviceTypeId)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            serviceTypeId = DataProtection.UrlDecode(serviceTypeId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await itemRepository.DeleteServiceType(int.Parse(serviceTypeId)));
        }

        #endregion

    }
}
