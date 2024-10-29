using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;

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
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await itemRepository.UpsertCategory(userParam.CategoryModel!, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("category/list")]
        public async Task<IActionResult> GetCategories([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey))
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
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            categoryId = DataProtection.UrlDecode(categoryId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await itemRepository.DeleteCategory(int.Parse(categoryId)));
        }

        #endregion

        #region "GST"

        [HttpPost]
        [Route("gst/upsert")]
        public async Task<IActionResult> UpsertGst([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await itemRepository.UpsertGst(userParam.GstModel!, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("gst/list/{isActive}")]
        public async Task<IActionResult> GetGsts([FromBody] UserParam userParam, [FromRoute] bool isActive)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey))
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
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey))
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
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await itemRepository.UpsertItem(userParam.ItemModel!, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("item/list/{filter?}")]
        public async Task<IActionResult> GetItems([FromBody] UserParam userParam, [FromRoute] string? filter)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await itemRepository.GetItems(filter ?? string.Empty));
        }

        [HttpPost]
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
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            itemId = DataProtection.UrlDecode(itemId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await itemRepository.DeleteItem(int.Parse(itemId)));
        }


        [HttpPost]
        [Route("min/stock/list")]
        public async Task<IActionResult> GetMinStockItems([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await itemRepository.GetMinStockItems());
        }


        #endregion

    }
}
