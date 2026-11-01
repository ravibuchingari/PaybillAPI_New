using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaybillWebApp.Models;
using PaybillWebApp.Services;

namespace PaybillWebApp.Controllers
{
    [Authorize]
    public class InventoryController(IPaybillApiService apiService) : Controller
    {
        public async Task<IActionResult> Index(int categoryId = 0, string? filter = null, string tab = "items")
        {
            var itemsTask = apiService.GetItemsAsync(categoryId, filter);
            var categoriesTask = apiService.GetCategoriesWithItemCountAsync();
            var gstTask = apiService.GetGstListAsync(false);
            var servicesTask = apiService.GetServiceTypesAsync(true);
            var minStockTask = apiService.GetMinStockItemsAsync();

            await Task.WhenAll(itemsTask, categoriesTask, gstTask, servicesTask, minStockTask);

            var categories = categoriesTask.Result;
            if (categories.Count == 0)
            {
                categories = await apiService.GetCategoriesAsync();
            }

            var vm = new InventoryPageViewModel
            {
                Items = itemsTask.Result,
                Categories = categories,
                GstSlabs = gstTask.Result,
                ServiceTypes = servicesTask.Result,
                MinStockItems = minStockTask.Result,
                SelectedCategoryId = categoryId,
                SearchFilter = filter,
                ActiveTab = tab
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> SearchItemsJson(string? q, string? code)
        {
            if (!string.IsNullOrWhiteSpace(code))
            {
                var byCode = await apiService.GetItemsByCodeAsync(code.Trim());
                return Json(byCode);
            }
            var items = await apiService.SearchItemsAsync(q ?? string.Empty);
            return Json(items);
        }

        [HttpGet]
        public async Task<IActionResult> GetItemJson(int id)
        {
            var item = await apiService.GetItemDetailsAsync(id);
            return Json(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveItem(
            int itemId, string itemCode, string itemName, string? itemLocalName, string? aliasName,
            int categoryId, int? gstId, float mrp, float salesPrice, float purchasePrice,
            string? hsnCode, string? measure, double openingStock, double minimumStock,
            string? shelf, bool isActive = true)
        {
            var model = new ItemVM
            {
                ItemId = itemId,
                ItemCode = itemCode?.Trim() ?? string.Empty,
                ItemName = itemName?.Trim() ?? string.Empty,
                ItemLocalName = itemLocalName?.Trim() ?? string.Empty,
                AliasName = aliasName?.Trim() ?? string.Empty,
                Mrp = mrp,
                SalesPrice = salesPrice,
                PurchasePrice = purchasePrice,
                HSncode = hsnCode?.Trim() ?? string.Empty,
                Measure = string.IsNullOrWhiteSpace(measure) ? "PCS" : measure.Trim(),
                OpeningStock = openingStock,
                MinimumStock = minimumStock,
                Shelf = shelf?.Trim() ?? string.Empty,
                IsActive = isActive,
                CategoryModel = new CategoryVM { CategoryId = categoryId },
                GstModel = gstId.HasValue && gstId.Value > 0 ? new GstVM { GstId = gstId.Value } : null
            };

            var res = await apiService.UpsertItemAsync(model);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = itemId == 0 ? "Item created successfully." : "Item updated successfully.";
            else
                TempData["ErrorMessage"] = res.Message;

            return RedirectToAction("Index", new { tab = "items" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var res = await apiService.DeleteItemAsync(id);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message;
            else
                TempData["ErrorMessage"] = res.Message;
            return RedirectToAction("Index", new { tab = "items" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveCategory(int categoryId, string categoryName)
        {
            var res = await apiService.UpsertCategoryAsync(new CategoryVM
            {
                CategoryId = categoryId,
                CategoryName = categoryName.Trim()
            });
            if (res.IsSuccess)
                TempData["SuccessMessage"] = categoryId == 0 ? "Category added successfully." : "Category updated successfully.";
            else
                TempData["ErrorMessage"] = res.Message;
            return RedirectToAction("Index", new { tab = "categories" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var res = await apiService.DeleteCategoryAsync(id);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message;
            else
                TempData["ErrorMessage"] = res.Message;
            return RedirectToAction("Index", new { tab = "categories" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveGst(int gstId, float cgstPer, float sgstPer, float igstPer, bool isActive = true)
        {
            var res = await apiService.UpsertGstAsync(new GstVM
            {
                GstId = gstId,
                CgstPer = cgstPer,
                SgstPer = sgstPer,
                IgstPer = igstPer > 0 ? igstPer : (cgstPer + sgstPer),
                IsActive = isActive
            });
            if (res.IsSuccess)
                TempData["SuccessMessage"] = gstId == 0 ? "GST slab added successfully." : "GST slab updated successfully.";
            else
                TempData["ErrorMessage"] = res.Message;
            return RedirectToAction("Index", new { tab = "gst" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteGst(int id)
        {
            var res = await apiService.DeleteGstAsync(id);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message;
            else
                TempData["ErrorMessage"] = res.Message;
            return RedirectToAction("Index", new { tab = "gst" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveServiceType(int serviceTypeId, string serviceTypeName, double serviceCharge, string? sacCode, string? serviceDescription, int? gstId, bool isActive = true)
        {
            var res = await apiService.UpsertServiceTypeAsync(new ServiceTypeVM
            {
                ServiceTypeId = serviceTypeId,
                ServiceTypeName = serviceTypeName.Trim(),
                ServiceCharge = serviceCharge,
                SacCode = sacCode?.Trim() ?? string.Empty,
                ServiceDescription = serviceDescription?.Trim() ?? string.Empty,
                IsActive = isActive,
                GstModel = gstId.HasValue && gstId.Value > 0 ? new GstVM { GstId = gstId.Value } : null
            });
            if (res.IsSuccess)
                TempData["SuccessMessage"] = serviceTypeId == 0 ? "Service type added successfully." : "Service type updated successfully.";
            else
                TempData["ErrorMessage"] = res.Message;
            return RedirectToAction("Index", new { tab = "services" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteServiceType(int id)
        {
            var res = await apiService.DeleteServiceTypeAsync(id);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message;
            else
                TempData["ErrorMessage"] = res.Message;
            return RedirectToAction("Index", new { tab = "services" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetStock()
        {
            var res = await apiService.ResetStockAsync();
            if (res.IsSuccess)
                TempData["SuccessMessage"] = "Inventory closing stock recalculated from all purchases and sales.";
            else
                TempData["ErrorMessage"] = res.Message;
            return RedirectToAction("Index", new { tab = "items" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BulkUploadExcel(IFormFile? excelFile)
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                TempData["ErrorMessage"] = "Please select a valid .xlsx Excel file.";
                return RedirectToAction("Index", new { tab = "items" });
            }

            try
            {
                var categories = await apiService.GetCategoriesAsync();
                var gsts = await apiService.GetGstListAsync(false);
                int defaultCatId = categories.FirstOrDefault()?.CategoryId ?? 1;
                int? defaultGstId = gsts.FirstOrDefault()?.GstId;

                var itemsToUpload = new List<ItemVM>();
                using var stream = excelFile.OpenReadStream();
                using var workbook = new XLWorkbook(stream);
                var ws = workbook.Worksheets.First();
                var rows = ws.RangeUsed()?.RowsUsed().Skip(1);

                if (rows != null)
                {
                    foreach (var row in rows)
                    {
                        string code = row.Cell(1).GetValue<string>().Trim();
                        string name = row.Cell(2).GetValue<string>().Trim();
                        if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name))
                            continue;

                        string catName = row.Cell(3).GetValue<string>().Trim();
                        int catId = defaultCatId;
                        if (!string.IsNullOrWhiteSpace(catName))
                        {
                            var existingCat = categories.FirstOrDefault(c => string.Equals(c.CategoryName, catName, StringComparison.OrdinalIgnoreCase));
                            if (existingCat != null)
                            {
                                catId = existingCat.CategoryId;
                            }
                            else
                            {
                                var createdCat = await apiService.CreateCategoryIfNotExistsAsync(catName);
                                if (int.TryParse(createdCat.Message, out int newCatId) && newCatId > 0)
                                    catId = newCatId;
                            }
                        }

                        float mrp = float.TryParse(row.Cell(4).GetValue<string>(), out float m) ? m : 0;
                        float salesPrice = float.TryParse(row.Cell(5).GetValue<string>(), out float sp) ? sp : mrp;
                        float purchasePrice = float.TryParse(row.Cell(6).GetValue<string>(), out float pp) ? pp : 0;
                        string measure = row.Cell(7).GetValue<string>().Trim();
                        double opStock = double.TryParse(row.Cell(8).GetValue<string>(), out double os) ? os : 0;
                        double minStock = double.TryParse(row.Cell(9).GetValue<string>(), out double ms) ? ms : 0;
                        string hsn = row.Cell(10).GetValue<string>().Trim();

                        itemsToUpload.Add(new ItemVM
                        {
                            ItemCode = code,
                            ItemName = name,
                            ItemLocalName = name,
                            CategoryModel = new CategoryVM { CategoryId = catId },
                            GstModel = defaultGstId.HasValue ? new GstVM { GstId = defaultGstId.Value } : null,
                            Mrp = mrp,
                            SalesPrice = salesPrice,
                            PurchasePrice = purchasePrice,
                            Measure = string.IsNullOrWhiteSpace(measure) ? "PCS" : measure,
                            OpeningStock = opStock,
                            MinimumStock = minStock,
                            HSncode = hsn,
                            IsActive = true
                        });
                    }
                }

                if (itemsToUpload.Count == 0)
                {
                    TempData["ErrorMessage"] = "No valid item rows found in the uploaded Excel file.";
                    return RedirectToAction("Index", new { tab = "items" });
                }

                var res = await apiService.UploadItemsBulkAsync(itemsToUpload);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = $"Uploaded {itemsToUpload.Count} items successfully.";
                else
                    TempData["ErrorMessage"] = res.Message;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Excel import error: {ex.Message}";
            }

            return RedirectToAction("Index", new { tab = "items" });
        }

        [HttpGet]
        public async Task<IActionResult> PrintBarcodes(string? itemIds = null, int copies = 2)
        {
            var allItems = await apiService.GetItemsAsync(0, null);
            List<ItemVM> selected;
            if (!string.IsNullOrWhiteSpace(itemIds))
            {
                var ids = itemIds.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => int.TryParse(s, out int id) ? id : 0)
                    .Where(id => id > 0)
                    .ToHashSet();
                selected = allItems.Where(i => ids.Contains(i.ItemId)).ToList();
            }
            else
            {
                selected = allItems.Take(24).ToList();
            }

            ViewBag.Copies = Math.Clamp(copies, 1, 20);
            ViewBag.CompanyName = apiService.GetCurrentCompanyName();
            return View(selected);
        }
    }
}

