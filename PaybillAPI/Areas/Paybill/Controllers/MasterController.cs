using System.Text.Json;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paybill.Models;
using Paybill.Services;
using Paybill.ViewModel;

namespace Paybill.Areas.Paybill.Controllers
{
    [Area("Paybill")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class MasterController(IPaybillApiService apiService, IWebHostEnvironment env, IHttpClientFactory httpClientFactory) : Controller
    {
        // ============================================================
        // 0. MASTER SETUP HUB (MasterRegistrationScreen.kt)
        // ============================================================
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categoriesTask = apiService.GetCategoriesWithItemCountAsync();
            var gstTask = apiService.GetGstListAsync(false);
            var itemsTask = apiService.GetItemsAsync(0, null);
            var minStockTask = apiService.GetMinStockItemsAsync();
            var customersTask = apiService.GetPartiesAsync(false);
            var vendorsTask = apiService.GetPartiesAsync(true);
            var usersTask = apiService.GetUsersAsync();
            var servicesTask = apiService.GetServiceTypesAsync(true);

            await Task.WhenAll(categoriesTask, gstTask, itemsTask, minStockTask, customersTask, vendorsTask, usersTask, servicesTask);

            var categories = categoriesTask.Result;
            if (categories.Count == 0)
                categories = await apiService.GetCategoriesAsync();

            var vm = new MasterHubViewModel
            {
                CategoriesCount = categories.Count,
                GstSlabsCount = gstTask.Result.Count,
                ItemsCount = itemsTask.Result.Count,
                LowStockCount = minStockTask.Result.Count,
                CustomersCount = customersTask.Result.Count,
                VendorsCount = vendorsTask.Result.Count,
                UsersCount = usersTask.Result.Count,
                ServiceTypesCount = servicesTask.Result.Count,
                IsAdmin = apiService.IsAdminUser()
            };

            return View(vm);
        }

        // ============================================================
        // 1. CATEGORY MASTER (SearchCategoryScreen.kt)
        // ============================================================
        [HttpGet]
        public async Task<IActionResult> Categories(int? editId = null, string? q = null)
        {
            var categories = await apiService.GetCategoriesWithItemCountAsync();
            if (categories.Count == 0)
                categories = await apiService.GetCategoriesAsync();

            if (!string.IsNullOrWhiteSpace(q))
            {
                string filter = q.Trim();
                categories = categories
                    .Where(c => c.CategoryName.Contains(filter, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            var editCat = new CategoryVM();
            if (editId.HasValue && editId.Value > 0)
            {
                editCat = categories.FirstOrDefault(c => c.CategoryId == editId.Value)
                    ?? await apiService.GetCategoryDetailsAsync(editId.Value)
                    ?? new CategoryVM();
            }

            var vm = new CategoryMasterViewModel
            {
                EditCategory = editCat,
                Categories = categories,
                SearchFilter = q
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveCategory(int categoryId, string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                TempData["ErrorMessage"] = "Category name is required.";
                return RedirectToAction(nameof(Categories));
            }

            var res = await apiService.UpsertCategoryAsync(new CategoryVM
            {
                CategoryId = categoryId,
                CategoryName = categoryName.Trim()
            });

            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? (categoryId == 0 ? "Category registered successfully." : "Category updated successfully.");
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to save category.";

            return RedirectToAction(nameof(Categories));
        }

        [HttpPost]
        public async Task<IActionResult> SaveCategoryJson([FromBody] CategoryVM model)
        {
            if (string.IsNullOrWhiteSpace(model.CategoryName))
                return Json(new { isSuccess = false, message = "Category name is required." });

            var res = await apiService.CreateCategoryIfNotExistsAsync(model.CategoryName.Trim());
            int catId = 0;
            if (!string.IsNullOrWhiteSpace(res.Message))
                int.TryParse(res.Message, out catId);

            return Json(new
            {
                isSuccess = res.IsSuccess,
                categoryId = catId,
                categoryName = model.CategoryName.Trim(),
                message = res.IsSuccess ? "Category added." : res.Message
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var res = await apiService.DeleteCategoryAsync(id);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Category deleted.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Unable to delete category (items may be linked to this category).";

            return RedirectToAction(nameof(Categories));
        }

        // ============================================================
        // 2. GST MASTER (SearchGSTScreen.kt)
        // ============================================================
        [HttpGet]
        public async Task<IActionResult> Gst(int? editId = null, string? q = null)
        {
            var gstList = await apiService.GetGstListAsync(false);
            if (!string.IsNullOrWhiteSpace(q))
            {
                string filter = q.Trim();
                gstList = gstList
                    .Where(g => g.IgstPer.ToString().Contains(filter)
                             || g.CgstPer.ToString().Contains(filter)
                             || g.SgstPer.ToString().Contains(filter))
                    .ToList();
            }

            var editGst = new GstVM { IsActive = true };
            if (editId.HasValue && editId.Value > 0)
            {
                editGst = gstList.FirstOrDefault(g => g.GstId == editId.Value)
                    ?? await apiService.GetGstDetailsAsync(editId.Value)
                    ?? new GstVM { IsActive = true };
            }

            var vm = new GstMasterViewModel
            {
                EditGst = editGst,
                GstSlabs = gstList,
                SearchFilter = q
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveGst(int gstId, float cgstPer, float sgstPer, float igstPer, bool isActive = true)
        {
            float totalIgst = igstPer > 0 ? igstPer : (cgstPer + sgstPer);
            var res = await apiService.UpsertGstAsync(new GstVM
            {
                GstId = gstId,
                CgstPer = cgstPer,
                SgstPer = sgstPer,
                IgstPer = totalIgst,
                IsActive = isActive
            });

            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? (gstId == 0 ? "GST slab registered successfully." : "GST slab updated successfully.");
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to save GST slab.";

            return RedirectToAction(nameof(Gst));
        }

        [HttpPost]
        public async Task<IActionResult> SaveGstJson([FromBody] GstVM model)
        {
            float totalIgst = model.IgstPer > 0 ? model.IgstPer : (model.CgstPer + model.SgstPer);
            model.IgstPer = totalIgst;
            model.IsActive = true;

            var res = await apiService.CreateGstIfNotExistsAsync(model);
            int gstId = 0;
            if (!string.IsNullOrWhiteSpace(res.Message))
                int.TryParse(res.Message, out gstId);

            return Json(new
            {
                isSuccess = res.IsSuccess,
                gstId,
                displayName = $"GST {totalIgst:0.##}% (CGST {model.CgstPer:0.##}% + SGST {model.SgstPer:0.##}%)",
                message = res.IsSuccess ? "GST slab added." : res.Message
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteGst(int id)
        {
            var res = await apiService.DeleteGstAsync(id);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "GST slab deleted.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Unable to delete GST slab (items may be linked to this GST rate).";

            return RedirectToAction(nameof(Gst));
        }

        // ============================================================
        // 3. ITEM MASTER REGISTRATION (ItemMasterScreen.kt)
        // ============================================================
        [HttpGet]
        public async Task<IActionResult> ItemMaster(int id = 0)
        {
            var categoriesTask = apiService.GetCategoriesAsync();
            var gstTask = apiService.GetGstListAsync(false);
            var settingsTask = apiService.GetSettingsAsync();
            Task<ItemVM?>? itemTask = id > 0 ? apiService.GetItemDetailsAsync(id) : null;

            if (itemTask != null)
                await Task.WhenAll(categoriesTask, gstTask, settingsTask, itemTask);
            else
                await Task.WhenAll(categoriesTask, gstTask, settingsTask);

            var item = itemTask?.Result ?? new ItemVM
            {
                ItemId = 0,
                IsActive = true,
                Measure = "Piece"
            };

            string localLang = string.IsNullOrWhiteSpace(settingsTask.Result.LocalLanguageCode)
                ? "te"
                : settingsTask.Result.LocalLanguageCode.Trim().ToLowerInvariant();

            bool hasImage = false;
            string imageUrl = string.Empty;
            if (item.ItemId > 0)
            {
                string imgRelative = Path.Combine("images", "items", $"{item.ItemId}.png");
                string imgFull = Path.Combine(env.WebRootPath, imgRelative);
                if (System.IO.File.Exists(imgFull))
                {
                    hasImage = true;
                    imageUrl = $"/images/items/{item.ItemId}.png?v={System.IO.File.GetLastWriteTimeUtc(imgFull).Ticks}";
                }
            }

            var vm = new ItemMasterPageViewModel
            {
                Item = item,
                Categories = categoriesTask.Result,
                GstSlabs = gstTask.Result,
                HasExistingImage = hasImage,
                ExistingImageUrl = imageUrl,
                LocalLanguageCode = localLang
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> TranslateToLocalLanguage(string? text, string? targetLang = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return Json(new { isSuccess = true, translatedText = string.Empty, lang = targetLang ?? "te" });

            string lang = targetLang?.Trim().ToLowerInvariant() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(lang))
            {
                var settings = await apiService.GetSettingsAsync();
                lang = string.IsNullOrWhiteSpace(settings.LocalLanguageCode)
                    ? "te"
                    : settings.LocalLanguageCode.Trim().ToLowerInvariant();
            }

            if (lang == "en" || lang == "eng")
                return Json(new { isSuccess = true, translatedText = text.Trim(), lang });

            try
            {
                var client = httpClientFactory.CreateClient();
                client.Timeout = TimeSpan.FromSeconds(5);
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");

                // 1. Primary: Google Translate API
                string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl={Uri.EscapeDataString(lang)}&dt=t&q={Uri.EscapeDataString(text.Trim())}";
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(json);
                    if (doc.RootElement.ValueKind == JsonValueKind.Array && doc.RootElement.GetArrayLength() > 0)
                    {
                        var sentences = doc.RootElement[0];
                        if (sentences.ValueKind == JsonValueKind.Array)
                        {
                            var sb = new System.Text.StringBuilder();
                            foreach (var seg in sentences.EnumerateArray())
                            {
                                if (seg.ValueKind == JsonValueKind.Array && seg.GetArrayLength() > 0 && seg[0].ValueKind == JsonValueKind.String)
                                {
                                    sb.Append(seg[0].GetString());
                                }
                            }
                            string translated = sb.ToString().Trim();
                            if (!string.IsNullOrWhiteSpace(translated))
                            {
                                return Json(new { isSuccess = true, translatedText = translated, lang });
                            }
                        }
                    }
                }
            }
            catch
            {
                // Ignore and fall back
            }

            return Json(new { isSuccess = false, translatedText = text.Trim(), lang });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveItem(
            int itemId,
            string itemCode,
            string itemName,
            string? itemLocalName,
            string? aliasName,
            int categoryId,
            int? gstId,
            float mrp,
            float salesPrice,
            float purchasePrice,
            string? hsnCode,
            string? measure,
            double openingStock,
            double minimumStock,
            string? shelf,
            bool isActive = true,
            IFormFile? itemImage = null,
            bool removeExistingImage = false,
            string afterAction = "stay")
        {
            if (string.IsNullOrWhiteSpace(itemName))
            {
                TempData["ErrorMessage"] = "Item name cannot be empty.";
                return RedirectToAction(nameof(ItemMaster), new { id = itemId });
            }

            if (salesPrice <= 0)
            {
                TempData["ErrorMessage"] = "Sales price must be greater than zero.";
                return RedirectToAction(nameof(ItemMaster), new { id = itemId });
            }

            if (categoryId <= 0)
            {
                var cats = await apiService.GetCategoriesAsync();
                categoryId = cats.FirstOrDefault()?.CategoryId ?? 0;
                if (categoryId == 0)
                {
                    var defaultCat = await apiService.CreateCategoryIfNotExistsAsync("General");
                    int.TryParse(defaultCat.Message, out categoryId);
                }
            }

            string finalCode = string.IsNullOrWhiteSpace(itemCode)
                ? $"ITM{DateTime.Now:yyMMddHHmmss}"
                : itemCode.Trim().ToUpperInvariant();

            var model = new ItemVM
            {
                ItemId = itemId,
                ItemCode = finalCode,
                ItemName = itemName.Trim(),
                ItemLocalName = string.IsNullOrWhiteSpace(itemLocalName) ? itemName.Trim() : itemLocalName.Trim(),
                AliasName = aliasName?.Trim() ?? string.Empty,
                Mrp = mrp > 0 ? mrp : salesPrice,
                SalesPrice = salesPrice,
                PurchasePrice = purchasePrice,
                HSncode = hsnCode?.Trim() ?? string.Empty,
                Measure = string.IsNullOrWhiteSpace(measure) ? "Piece" : measure.Trim(),
                OpeningStock = openingStock,
                MinimumStock = minimumStock,
                Shelf = shelf?.Trim() ?? string.Empty,
                IsActive = isActive,
                CategoryModel = new CategoryVM { CategoryId = categoryId },
                GstModel = gstId.HasValue && gstId.Value > 0 ? new GstVM { GstId = gstId.Value } : null
            };

            var res = await apiService.UpsertItemAsync(model);
            if (!res.IsSuccess)
            {
                TempData["ErrorMessage"] = res.Message ?? "Failed to save item.";
                return RedirectToAction(nameof(ItemMaster), new { id = itemId });
            }

            int savedItemId = itemId;
            if (!string.IsNullOrWhiteSpace(res.Data) && int.TryParse(res.Data, out int parsedId) && parsedId > 0)
            {
                savedItemId = parsedId;
            }

            // Handle Item Image save or removal in wwwroot/images/items/{savedItemId}.png
            if (savedItemId > 0)
            {
                string itemsImgDir = Path.Combine(env.WebRootPath, "images", "items");
                Directory.CreateDirectory(itemsImgDir);
                string destFile = Path.Combine(itemsImgDir, $"{savedItemId}.png");

                if (removeExistingImage && System.IO.File.Exists(destFile))
                {
                    System.IO.File.Delete(destFile);
                }

                if (itemImage != null && itemImage.Length > 0)
                {
                    using var fs = new FileStream(destFile, FileMode.Create, FileAccess.Write);
                    await itemImage.CopyToAsync(fs);
                }
            }

            TempData["SuccessMessage"] = itemId == 0 ? "Item registered successfully." : "Item updated successfully.";

            if (string.Equals(afterAction, "list", StringComparison.OrdinalIgnoreCase))
                return RedirectToAction(nameof(Items));

            // If creating new item, clear form for next item entry (matching ItemMasterActivity.kt clearData())
            return RedirectToAction(nameof(ItemMaster), new { id = itemId > 0 ? savedItemId : 0 });
        }

        // ============================================================
        // 4. VIEW ALL ITEMS & ITEM IMAGES (ViewItemsScreen.kt)
        // ============================================================
        [HttpGet]
        public async Task<IActionResult> Items(int categoryId = 0, string? filter = null)
        {
            var itemsTask = apiService.GetItemsAsync(categoryId, filter);
            var categoriesTask = apiService.GetCategoriesWithItemCountAsync();
            var gstTask = apiService.GetGstListAsync(false);
            var minStockTask = apiService.GetMinStockItemsAsync();

            await Task.WhenAll(itemsTask, categoriesTask, gstTask, minStockTask);

            var categories = categoriesTask.Result;
            if (categories.Count == 0)
                categories = await apiService.GetCategoriesAsync();

            var vm = new InventoryPageViewModel
            {
                Items = itemsTask.Result,
                Categories = categories,
                GstSlabs = gstTask.Result,
                MinStockItems = minStockTask.Result,
                SelectedCategoryId = categoryId,
                SearchFilter = filter
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var res = await apiService.DeleteItemAsync(id);
            if (res.IsSuccess)
            {
                string imgPath = Path.Combine(env.WebRootPath, "images", "items", $"{id}.png");
                if (System.IO.File.Exists(imgPath))
                    System.IO.File.Delete(imgPath);
                TempData["SuccessMessage"] = res.Message ?? "Item deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = res.Message ?? "Unable to delete item (linked to invoices).";
            }
            return RedirectToAction(nameof(Items));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetStock()
        {
            var res = await apiService.ResetStockAsync();
            if (res.IsSuccess)
                TempData["SuccessMessage"] = "Closing stock recalculated from all purchases and sales.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to recalculate stock.";
            return RedirectToAction(nameof(Items));
        }

        // ============================================================
        // 5. PARTY / VENDOR REGISTRATION (PartyMasterScreen.kt)
        // ============================================================
        [HttpGet]
        public async Task<IActionResult> PartyMaster(int id = 0, bool isVendor = false)
        {
            var settingsTask = apiService.GetSettingsAsync();
            var customersTask = apiService.GetPartiesAsync(false);
            var vendorsTask = apiService.GetPartiesAsync(true);
            Task<PartyVM?>? partyTask = id > 0 ? apiService.GetPartyDetailsAsync(id) : null;

            if (partyTask != null)
                await Task.WhenAll(settingsTask, customersTask, vendorsTask, partyTask);
            else
                await Task.WhenAll(settingsTask, customersTask, vendorsTask);

            var party = partyTask?.Result ?? new PartyVM
            {
                PartyId = 0,
                IsVendor = isVendor,
                IsActive = true
            };

            var settings = settingsTask.Result;
            RewardCustomerSummaryVM? rewardsSummary = null;
            List<RewardTransactionVM> rewardTransactions = [];
            double availablePts = 0;

            if (party.PartyId > 0 && !party.IsVendor)
            {
                var summaryTask = apiService.GetCustomerRewardsSummaryAsync(party.PartyId);
                var txTask = apiService.GetRewardsTransactionsAsync(partyId: party.PartyId);
                await Task.WhenAll(summaryTask, txTask);

                rewardsSummary = summaryTask.Result;
                rewardTransactions = txTask.Result;
                availablePts = rewardsSummary?.AvailablePoints ?? 0;
            }

            var vm = new PartyMasterPageViewModel
            {
                Party = party,
                Settings = settings,
                RewardsSummary = rewardsSummary,
                AvailableRewardPoints = availablePts,
                RewardPointMonetaryValue = availablePts * (settings.RewardPointValue > 0 ? settings.RewardPointValue : 1.0),
                RewardTransactions = rewardTransactions,
                TotalCustomersCount = customersTask.Result.Count,
                TotalVendorsCount = vendorsTask.Result.Count
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveParty(PartyVM model, string afterAction = "stay")
        {
            if (string.IsNullOrWhiteSpace(model.PartyName))
            {
                TempData["ErrorMessage"] = $"{(model.IsVendor ? "Vendor" : "Customer")} name cannot be empty.";
                return RedirectToAction(nameof(PartyMaster), new { id = model.PartyId, isVendor = model.IsVendor });
            }

            if (string.IsNullOrWhiteSpace(model.PartyMobile) || model.PartyMobile.Trim().Length < 10)
            {
                TempData["ErrorMessage"] = "Valid 10-digit mobile number is required.";
                return RedirectToAction(nameof(PartyMaster), new { id = model.PartyId, isVendor = model.IsVendor });
            }

            model.PartyName = model.PartyName.Trim();
            model.PartyMobile = model.PartyMobile.Trim();
            model.PartyAddress = model.PartyAddress?.Trim() ?? string.Empty;
            model.PartyShippingAddress = model.PartyShippingAddress?.Trim() ?? string.Empty;
            model.PartyEmail = model.PartyEmail?.Trim() ?? string.Empty;
            model.PartyGstNo = model.PartyGstNo?.Trim().ToUpperInvariant() ?? string.Empty;
            model.PartyRemarks = model.PartyRemarks?.Trim() ?? string.Empty;

            var res = await apiService.UpsertPartyAsync(model);
            if (!res.IsSuccess)
            {
                TempData["ErrorMessage"] = res.Message ?? "Failed to save party.";
                return RedirectToAction(nameof(PartyMaster), new { id = model.PartyId, isVendor = model.IsVendor });
            }

            TempData["SuccessMessage"] = res.Message ?? (model.IsVendor ? "Vendor saved successfully." : "Customer saved successfully.");

            if (string.Equals(afterAction, "list", StringComparison.OrdinalIgnoreCase))
                return RedirectToAction("Index", "Party", new { isVendor = model.IsVendor });

            int savedPartyId = model.PartyId;
            if (model.PartyId > 0 && !string.IsNullOrWhiteSpace(res.Data) && int.TryParse(res.Data, out int pId))
                savedPartyId = pId;

            return RedirectToAction(nameof(PartyMaster), new { id = model.PartyId > 0 ? savedPartyId : 0, isVendor = model.IsVendor });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdjustCustomerRewardPoints(int partyId, double points, string reason)
        {
            if (partyId <= 0 || Math.Abs(points) < 0.01)
            {
                TempData["ErrorMessage"] = "Please enter a non-zero points adjustment value.";
                return RedirectToAction(nameof(PartyMaster), new { id = partyId, isVendor = false });
            }

            var res = await apiService.SaveManualRewardAdjustmentAsync(
                partyId,
                points,
                string.IsNullOrWhiteSpace(reason) ? "Manual Adjustment from Party Master" : reason.Trim());

            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Customer reward points adjusted successfully.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to adjust customer reward points.";

            return RedirectToAction(nameof(PartyMaster), new { id = partyId, isVendor = false });
        }

        // ============================================================
        // 6. USER REGISTRATION MASTER (UserRegistrationScreen.kt)
        // ============================================================
        [HttpGet]
        public async Task<IActionResult> Users(int? editId = null)
        {
            var users = await apiService.GetUsersAsync();
            var editUser = new UserVM { IsActive = true };

            if (editId.HasValue && editId.Value > 0)
            {
                editUser = users.FirstOrDefault(u => u.UserRowId == editId.Value) ?? new UserVM { IsActive = true };
            }

            var vm = new UserMasterPageViewModel
            {
                EditUser = editUser,
                Users = users,
                IsAdmin = apiService.IsAdminUser()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveUser(UserVM model, string? confirmPassword = null)
        {
            if (string.IsNullOrWhiteSpace(model.FirstName))
            {
                TempData["ErrorMessage"] = "First name is required.";
                return RedirectToAction(nameof(Users), new { editId = model.UserRowId });
            }

            if (string.IsNullOrWhiteSpace(model.Mobile) || model.Mobile.Trim().Length < 10)
            {
                TempData["ErrorMessage"] = "Valid 10-digit mobile number is required.";
                return RedirectToAction(nameof(Users), new { editId = model.UserRowId });
            }

            if (string.IsNullOrWhiteSpace(model.UserId))
            {
                TempData["ErrorMessage"] = "User ID is required.";
                return RedirectToAction(nameof(Users), new { editId = model.UserRowId });
            }

            if (model.UserRowId == 0)
            {
                if (string.IsNullOrWhiteSpace(model.Password))
                {
                    TempData["ErrorMessage"] = "Password is required for new user registration.";
                    return RedirectToAction(nameof(Users));
                }
                if (!string.IsNullOrEmpty(confirmPassword) && model.Password != confirmPassword)
                {
                    TempData["ErrorMessage"] = "Password and Confirm Password do not match.";
                    return RedirectToAction(nameof(Users));
                }
            }

            model.FirstName = model.FirstName.Trim();
            model.LastName = model.LastName?.Trim() ?? string.Empty;
            model.Address = model.Address?.Trim() ?? string.Empty;
            model.Mobile = model.Mobile.Trim();
            model.UserId = model.UserId.Trim();

            var res = await apiService.UpsertUserAsync(model);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? (model.UserRowId == 0 ? "User registered successfully." : "User updated successfully.");
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to save user.";

            return RedirectToAction(nameof(Users));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(int userRowId)
        {
            var res = await apiService.DeleteUserAsync(userRowId);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "User deleted successfully.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Unable to delete user.";

            return RedirectToAction(nameof(Users));
        }

        // ============================================================
        // 7. SERVICE TYPES MASTER (ServiceTypesScreen.kt)
        // ============================================================
        [HttpGet]
        public async Task<IActionResult> ServiceTypes(int? editId = null)
        {
            var servicesTask = apiService.GetServiceTypesAsync(true);
            var gstTask = apiService.GetGstListAsync(false);

            await Task.WhenAll(servicesTask, gstTask);

            var services = servicesTask.Result;
            var editService = new ServiceTypeVM { IsActive = true };

            if (editId.HasValue && editId.Value > 0)
            {
                editService = services.FirstOrDefault(s => s.ServiceTypeId == editId.Value)
                    ?? await apiService.GetServiceTypeDetailsAsync(editId.Value)
                    ?? new ServiceTypeVM { IsActive = true };
            }

            var vm = new ServiceTypeMasterViewModel
            {
                EditServiceType = editService,
                ServiceTypes = services,
                GstSlabs = gstTask.Result
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveServiceType(
            int serviceTypeId,
            string serviceTypeName,
            string? serviceDescription,
            double serviceCharge,
            string? sacCode,
            int? gstId,
            bool isActive = true)
        {
            if (string.IsNullOrWhiteSpace(serviceTypeName))
            {
                TempData["ErrorMessage"] = "Service name is required.";
                return RedirectToAction(nameof(ServiceTypes), new { editId = serviceTypeId });
            }

            if (serviceCharge <= 0)
            {
                TempData["ErrorMessage"] = "Service charge must be greater than 0.";
                return RedirectToAction(nameof(ServiceTypes), new { editId = serviceTypeId });
            }

            var model = new ServiceTypeVM
            {
                ServiceTypeId = serviceTypeId,
                ServiceTypeName = serviceTypeName.Trim(),
                ServiceDescription = serviceDescription?.Trim() ?? string.Empty,
                ServiceCharge = serviceCharge,
                SacCode = sacCode?.Trim() ?? string.Empty,
                IsActive = isActive,
                GstModel = gstId.HasValue && gstId.Value > 0 ? new GstVM { GstId = gstId.Value } : null
            };

            var res = await apiService.UpsertServiceTypeAsync(model);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? (serviceTypeId == 0 ? "Service type registered successfully." : "Service type updated successfully.");
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to save service type.";

            return RedirectToAction(nameof(ServiceTypes));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteServiceType(int id)
        {
            var res = await apiService.DeleteServiceTypeAsync(id);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Service type deleted.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Unable to delete service type.";

            return RedirectToAction(nameof(ServiceTypes));
        }

        // ============================================================
        // 8. IMPORT DATA FROM EXCEL (ImportDataActivity.kt)
        // ============================================================
        [HttpGet]
        public async Task<IActionResult> ImportData()
        {
            var itemsTask = apiService.GetItemsAsync(0, null);
            var categoriesTask = apiService.GetCategoriesAsync();
            var gstTask = apiService.GetGstListAsync(false);

            await Task.WhenAll(itemsTask, categoriesTask, gstTask);

            var vm = new ImportDataPageViewModel
            {
                ExistingItemsCount = itemsTask.Result.Count,
                ExistingCategoriesCount = categoriesTask.Result.Count,
                Categories = categoriesTask.Result,
                GstSlabs = gstTask.Result
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportExcel(IFormFile? excelFile, int? defaultCategoryId = null, int? defaultGstId = null)
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                TempData["ErrorMessage"] = "Please select a valid Excel (.xlsx) file to import.";
                return RedirectToAction(nameof(ImportData));
            }

            try
            {
                var categories = await apiService.GetCategoriesAsync();
                var gsts = await apiService.GetGstListAsync(false);

                int fallbackCatId = defaultCategoryId.HasValue && defaultCategoryId.Value > 0
                    ? defaultCategoryId.Value
                    : (categories.FirstOrDefault()?.CategoryId ?? 0);

                if (fallbackCatId == 0)
                {
                    var createdDefault = await apiService.CreateCategoryIfNotExistsAsync("General");
                    int.TryParse(createdDefault.Message, out fallbackCatId);
                }

                int? fallbackGstId = defaultGstId.HasValue && defaultGstId.Value > 0
                    ? defaultGstId.Value
                    : gsts.FirstOrDefault()?.GstId;

                var itemsToUpload = new List<ItemVM>();

                using var stream = excelFile.OpenReadStream();
                using var workbook = new XLWorkbook(stream);
                var ws = workbook.Worksheets.First();
                var usedRange = ws.RangeUsed();

                if (usedRange != null)
                {
                    var allRows = usedRange.RowsUsed().ToList();
                    if (allRows.Count > 1)
                    {
                        // Auto-detect column indices from header row (matching Android ImportDataActivity.kt)
                        var headerRow = allRows[0];
                        int itemCodeCol = -1;
                        int itemNameCol = -1;
                        int categoryCol = -1;
                        int mrpCol = -1;
                        int salesPriceCol = -1;
                        int purchasePriceCol = -1;
                        int measureCol = -1;
                        int stockCol = -1;
                        int minStockCol = -1;
                        int hsnCol = -1;
                        int shelfCol = -1;

                        int maxCell = headerRow.CellCount();
                        for (int c = 1; c <= maxCell; c++)
                        {
                            string headerText = headerRow.Cell(c).GetValue<string>().Trim().ToUpperInvariant();
                            if (string.IsNullOrEmpty(headerText)) continue;

                            if (headerText.Contains("ITEM CODE") || headerText == "CODE" || headerText.Contains("BARCODE"))
                                itemCodeCol = c;
                            else if (headerText.Contains("ITEM NAME") || headerText == "NAME" || headerText.Contains("PRODUCT"))
                                itemNameCol = c;
                            else if (headerText.Contains("CATEGORY") || headerText == "GROUP")
                                categoryCol = c;
                            else if (headerText == "MRP" || headerText.Contains("M.R.P"))
                                mrpCol = c;
                            else if (headerText.Contains("SALES PRICE") || headerText.Contains("SALE PRICE") || headerText == "RATE" || headerText == "PRICE")
                                salesPriceCol = c;
                            else if (headerText.Contains("PURCHASE PRICE") || headerText.Contains("COST"))
                                purchasePriceCol = c;
                            else if (headerText.Contains("UNIT") || headerText.Contains("MEASURE") || headerText == "UOM")
                                measureCol = c;
                            else if (headerText.Contains("CLOSING QTY") || headerText.Contains("CLOSING STOCK") || headerText.Contains("OPENING STOCK") || headerText == "STOCK" || headerText == "QTY")
                                stockCol = c;
                            else if (headerText.Contains("MIN STOCK") || headerText.Contains("MINIMUM STOCK") || headerText.Contains("REORDER"))
                                minStockCol = c;
                            else if (headerText.Contains("HSN"))
                                hsnCol = c;
                            else if (headerText.Contains("SHELF") || headerText.Contains("RACK") || headerText.Contains("LOCATION"))
                                shelfCol = c;
                        }

                        // Fallback to positional columns if headers didn't match standard names
                        if (itemNameCol == -1)
                        {
                            itemCodeCol = 1;
                            itemNameCol = 2;
                            categoryCol = 3;
                            mrpCol = 4;
                            salesPriceCol = 5;
                            purchasePriceCol = 6;
                            measureCol = 7;
                            stockCol = 8;
                            minStockCol = 9;
                            hsnCol = 10;
                        }

                        int autoCodeSeq = 1;
                        foreach (var row in allRows.Skip(1))
                        {
                            string name = itemNameCol > 0 ? row.Cell(itemNameCol).GetValue<string>().Trim() : string.Empty;
                            if (string.IsNullOrWhiteSpace(name))
                                continue;

                            string code = itemCodeCol > 0 ? row.Cell(itemCodeCol).GetValue<string>().Trim() : string.Empty;
                            if (string.IsNullOrWhiteSpace(code))
                                code = $"ITM{DateTime.Now:MMdd}{autoCodeSeq++:D4}";

                            int catId = fallbackCatId;
                            if (categoryCol > 0)
                            {
                                string catName = row.Cell(categoryCol).GetValue<string>().Trim();
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
                                        {
                                            catId = newCatId;
                                            categories.Add(new CategoryVM { CategoryId = newCatId, CategoryName = catName });
                                        }
                                    }
                                }
                            }

                            float salesPrice = salesPriceCol > 0 && float.TryParse(row.Cell(salesPriceCol).GetValue<string>(), out float sp) ? sp : 0f;
                            float mrp = mrpCol > 0 && float.TryParse(row.Cell(mrpCol).GetValue<string>(), out float m) ? m : salesPrice;
                            if (salesPrice <= 0 && mrp > 0) salesPrice = mrp;
                            if (salesPrice <= 0) continue;

                            float purchasePrice = purchasePriceCol > 0 && float.TryParse(row.Cell(purchasePriceCol).GetValue<string>(), out float pp) ? pp : 0f;
                            string measure = measureCol > 0 ? row.Cell(measureCol).GetValue<string>().Trim() : "Piece";
                            double opStock = stockCol > 0 && double.TryParse(row.Cell(stockCol).GetValue<string>(), out double os) ? os : 0;
                            double minStock = minStockCol > 0 && double.TryParse(row.Cell(minStockCol).GetValue<string>(), out double ms) ? ms : 0;
                            string hsn = hsnCol > 0 ? row.Cell(hsnCol).GetValue<string>().Trim() : string.Empty;
                            string shelf = shelfCol > 0 ? row.Cell(shelfCol).GetValue<string>().Trim() : string.Empty;

                            itemsToUpload.Add(new ItemVM
                            {
                                ItemCode = code,
                                ItemName = name,
                                ItemLocalName = name,
                                CategoryModel = new CategoryVM { CategoryId = catId },
                                GstModel = fallbackGstId.HasValue ? new GstVM { GstId = fallbackGstId.Value } : null,
                                Mrp = mrp > 0 ? mrp : salesPrice,
                                SalesPrice = salesPrice,
                                PurchasePrice = purchasePrice,
                                Measure = string.IsNullOrWhiteSpace(measure) ? "Piece" : measure,
                                OpeningStock = opStock,
                                MinimumStock = minStock,
                                HSncode = hsn,
                                Shelf = shelf,
                                IsActive = true
                            });
                        }
                    }
                }

                if (itemsToUpload.Count == 0)
                {
                    TempData["ErrorMessage"] = "No valid item rows with Item Name and Sales Price were found in the Excel file.";
                    return RedirectToAction(nameof(ImportData));
                }

                var res = await apiService.UploadItemsBulkAsync(itemsToUpload);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = $"Successfully imported {itemsToUpload.Count} items from Excel.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Bulk upload failed.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error reading Excel file: {ex.Message}";
            }

            return RedirectToAction(nameof(ImportData));
        }

        [HttpGet]
        public IActionResult DownloadTemplate()
        {
            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Items Master Template");

            string[] headers =
            [
                "ITEM CODE",
                "ITEM NAME",
                "CATEGORY",
                "MRP",
                "SALES PRICE",
                "PURCHASE PRICE",
                "MEASURE",
                "CLOSING QTY",
                "MIN STOCK",
                "HSN",
                "SHELF"
            ];

            for (int i = 0; i < headers.Length; i++)
            {
                var cell = ws.Cell(1, i + 1);
                cell.Value = headers[i];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#EAF6E6");
                cell.Style.Font.FontColor = XLColor.FromHtml("#153808");
            }

            // Sample rows matching Android paybill_template.xlsx
            ws.Cell(2, 1).Value = "ITM001";
            ws.Cell(2, 2).Value = "Aashirvaad Whole Wheat Atta 5Kg";
            ws.Cell(2, 3).Value = "Groceries";
            ws.Cell(2, 4).Value = 285;
            ws.Cell(2, 5).Value = 265;
            ws.Cell(2, 6).Value = 240;
            ws.Cell(2, 7).Value = "Pack";
            ws.Cell(2, 8).Value = 50;
            ws.Cell(2, 9).Value = 10;
            ws.Cell(2, 10).Value = "1101";
            ws.Cell(2, 11).Value = "Rack A-1";

            ws.Cell(3, 1).Value = "ITM002";
            ws.Cell(3, 2).Value = "Tata Tea Gold 500g";
            ws.Cell(3, 3).Value = "Beverages";
            ws.Cell(3, 4).Value = 310;
            ws.Cell(3, 5).Value = 295;
            ws.Cell(3, 6).Value = 260;
            ws.Cell(3, 7).Value = "Pack";
            ws.Cell(3, 8).Value = 35;
            ws.Cell(3, 9).Value = 5;
            ws.Cell(3, 10).Value = "0902";
            ws.Cell(3, 11).Value = "Rack B-2";

            ws.Columns().AdjustToContents();

            using var ms = new MemoryStream();
            workbook.SaveAs(ms);
            return File(
                ms.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "paybill_template.xlsx");
        }
    }
}
