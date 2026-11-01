using Paybill.Areas.Paybill.Models;
using Paybill.Helpers;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Paybill.Services
{
    public class PaybillApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, ILogger<PaybillApiService> logger) : IPaybillApiService
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        private HttpClient CreateClient(string? overrideJwt = null)
        {
            var client = httpClientFactory.CreateClient("PaybillApi");
            var req = httpContextAccessor.HttpContext?.Request;
            if (req != null && req.Host.HasValue)
            {
                client.BaseAddress = new Uri($"{req.Scheme}://{req.Host}{req.PathBase}/");
            }
            string? token = overrideJwt ?? httpContextAccessor.HttpContext?.User?.FindFirstValue("JwtToken");
            if (!string.IsNullOrWhiteSpace(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return client;
        }

        public int GetCurrentUserRowId()
        {
            var val = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(val, out int id) ? id : 0;
        }

        public string GetCurrentCompanyName()
            => httpContextAccessor.HttpContext?.User?.FindFirstValue("CompanyName") ?? "PayBill ERP";

        public string GetCurrentCompanyGstin()
            => httpContextAccessor.HttpContext?.User?.FindFirstValue("CompanyGstin") ?? string.Empty;

        public bool IsAdminUser()
            => httpContextAccessor.HttpContext?.User?.IsInRole("admin") == true;

        public UserParam GetCurrentUserParam()
        {
            var user = httpContextAccessor.HttpContext?.User;
            return new UserParam
            {
                UserRowId = GetCurrentUserRowId(),
                SecurityKey = user?.FindFirstValue("SecurityKey") ?? string.Empty,
                ClientUniqueId = user?.FindFirstValue("ClientUniqueId") ?? string.Empty,
                ClientId = user?.FindFirstValue("ClientId") ?? string.Empty
            };
        }

        private async Task<T?> GetAsync<T>(string relativeUrl, string? overrideJwt = null)
        {
            try
            {
                using var client = CreateClient(overrideJwt);
                var response = await client.GetAsync(relativeUrl);
                if (!response.IsSuccessStatusCode)
                {
                    string err = await response.Content.ReadAsStringAsync();
                    logger.LogWarning("GET {Url} returned {StatusCode}: {Error}", relativeUrl, response.StatusCode, err);
                    return default;
                }
                string json = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(json)) return default;
                return JsonSerializer.Deserialize<T>(json, JsonOptions);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error calling GET {Url}", relativeUrl);
                return default;
            }
        }

        private async Task<T?> PostJsonAsync<T>(string relativeUrl, object? payload = null, string? overrideJwt = null)
        {
            try
            {
                using var client = CreateClient(overrideJwt);
                HttpContent content = payload != null
                    ? new StringContent(JsonSerializer.Serialize(payload, JsonOptions), Encoding.UTF8, "application/json")
                    : new StringContent("{}", Encoding.UTF8, "application/json");

                var response = await client.PostAsync(relativeUrl, content);
                string body = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    logger.LogWarning("POST {Url} returned {StatusCode}: {Body}", relativeUrl, response.StatusCode, body);
                    if (typeof(T) == typeof(ResponseMessage))
                    {
                        return (T)(object)new ResponseMessage
                        {
                            IsSuccess = false,
                            Message = ExtractErrorMessage(body, response.ReasonPhrase ?? "Request failed")
                        };
                    }
                    if (typeof(T) == typeof(AuthResponseVM))
                    {
                        return (T)(object)new AuthResponseVM
                        {
                            IsSuccess = false,
                            Message = ExtractErrorMessage(body, "Authentication failed")
                        };
                    }
                    return default;
                }

                if (string.IsNullOrWhiteSpace(body)) return default;
                return JsonSerializer.Deserialize<T>(body, JsonOptions);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error calling POST {Url}", relativeUrl);
                if (typeof(T) == typeof(ResponseMessage))
                {
                    return (T)(object)new ResponseMessage { IsSuccess = false, Message = ex.Message };
                }
                if (typeof(T) == typeof(AuthResponseVM))
                {
                    return (T)(object)new AuthResponseVM { IsSuccess = false, Message = ex.Message };
                }
                return default;
            }
        }

        private async Task<ResponseMessage> PostFormAsync(string relativeUrl, Dictionary<string, string> formFields)
        {
            try
            {
                using var client = CreateClient();
                using var content = new FormUrlEncodedContent(formFields);
                var response = await client.PostAsync(relativeUrl, content);
                string body = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseMessage { IsSuccess = false, Message = ExtractErrorMessage(body, "Form submission failed") };
                }
                return JsonSerializer.Deserialize<ResponseMessage>(body, JsonOptions)
                       ?? new ResponseMessage { IsSuccess = true, Message = "Success" };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error calling POST Form {Url}", relativeUrl);
                return new ResponseMessage { IsSuccess = false, Message = ex.Message };
            }
        }

        private static string ExtractErrorMessage(string body, string fallback)
        {
            if (string.IsNullOrWhiteSpace(body)) return fallback;
            try
            {
                using var doc = JsonDocument.Parse(body);
                if (doc.RootElement.ValueKind == JsonValueKind.Object && doc.RootElement.TryGetProperty("message", out var msgProp))
                {
                    return msgProp.GetString() ?? body;
                }
            }
            catch
            {
                // Plain string response
            }
            return body.Trim('"');
        }

        // ==================== HOME & AUTH ====================

        public async Task<ClientVM?> GetClientInfoAsync()
            => await GetAsync<ClientVM>("api/home/client/info");

        public async Task<ResponseMessage> CreateAccountAsync(ClientVM client)
            => await PostJsonAsync<ResponseMessage>("api/home/create/account", client)
               ?? new ResponseMessage { IsSuccess = false, Message = "Unable to create account." };

        public async Task<ResponseMessage> CreateInitialUserAsync(UserVM user, string tempJwtToken)
        {
            var payload = new UserVM
            {
                UserRowId = 0,
                UserId = user.UserId,
                Password = PaybillCrypto.EncryptPassword(user.Password),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Mobile = user.Mobile,
                Address = user.Address ?? string.Empty,
                IsAdmin = true,
                IsActive = true,
                SecurityKey = user.SecurityKey
            };
            return await PostJsonAsync<ResponseMessage>("api/common/create/user", payload, tempJwtToken)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Unable to create initial admin user." };
        }

        public async Task<AuthResponseVM> AuthenticateAsync(AuthRequestVM request)
        {
            var encryptedReq = new AuthRequestVM
            {
                ClientUniqueId = request.ClientUniqueId,
                ClientId = request.ClientId,
                UserId = request.UserId,
                Password = PaybillCrypto.EncryptPassword(request.Password)
            };
            return await PostJsonAsync<AuthResponseVM>("api/home/authenticate", encryptedReq)
                   ?? new AuthResponseVM { IsSuccess = false, Message = "Unable to connect to PayBill API server." };
        }

        // ==================== ADMIN, SETTINGS & COMMON ====================

        public async Task<SettingVM> GetSettingsAsync()
            => await PostJsonAsync<SettingVM>("api/admin/settings/view", GetCurrentUserParam()) ?? new SettingVM();

        public async Task<ResponseMessage> UpdateSettingsAsync(SettingVM setting)
        {
            var param = GetCurrentUserParam();
            param.SettingModel = setting;
            return await PostJsonAsync<ResponseMessage>("api/admin/settings/update", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to update settings." };
        }

        public async Task<ResponseMessage> UpdateClientProfileAsync(ClientVM client)
            => await PostJsonAsync<ResponseMessage>("api/common/client/profile/update", client)
               ?? new ResponseMessage { IsSuccess = false, Message = "Failed to update business profile." };

        public async Task<PrintHeader> GetPrintHeaderAsync()
            => await GetAsync<PrintHeader>("api/common/print/header") ?? new PrintHeader();

        public async Task<List<UserVM>> GetUsersAsync()
            => await PostJsonAsync<List<UserVM>>("api/common/user/list", GetCurrentUserParam()) ?? [];

        public async Task<ResponseMessage> UpsertUserAsync(UserVM user)
        {
            var param = GetCurrentUserParam();
            var clone = new UserVM
            {
                UserRowId = user.UserRowId,
                UserId = user.UserId,
                Password = !string.IsNullOrWhiteSpace(user.Password) ? PaybillCrypto.EncryptPassword(user.Password) : string.Empty,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address ?? string.Empty,
                Mobile = user.Mobile,
                IsAdmin = user.IsAdmin,
                IsActive = user.IsActive
            };
            param.UserModel = clone;
            return await PostJsonAsync<ResponseMessage>("api/common/user/upset", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to save user." };
        }

        public async Task<ResponseMessage> DeleteUserAsync(int targetUserRowId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(targetUserRowId);
            return await PostJsonAsync<ResponseMessage>($"api/common/user/{encId}/delete", GetCurrentUserParam())
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to delete user." };
        }

        public async Task<ResponseMessage> ChangePasswordAsync(string oldPassword, string newPassword)
        {
            string encOld = PaybillCrypto.EncodeRouteParam(oldPassword);
            string encNew = PaybillCrypto.EncodeRouteParam(newPassword);
            return await PostJsonAsync<ResponseMessage>($"api/common/user/password/change/{encOld}/{encNew}", GetCurrentUserParam())
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to change password." };
        }

        public async Task<ResponseMessage> InsertUnlockRequestAsync(UnlockRequestVM request)
            => await PostJsonAsync<ResponseMessage>("api/common/unlock/request/insert", request)
               ?? new ResponseMessage { IsSuccess = false, Message = "Failed to submit unlock request." };

        public async Task<ResponseMessage> CheckUnlockRequestStatusAsync(int? salesId, int? purchaseId)
        {
            var query = new List<string>();
            if (salesId.HasValue) query.Add($"salesId={salesId.Value}");
            if (purchaseId.HasValue) query.Add($"purchaseId={purchaseId.Value}");
            string qs = query.Count > 0 ? "?" + string.Join("&", query) : "";
            return await GetAsync<ResponseMessage>($"api/common/unlock/request/status{qs}")
                   ?? new ResponseMessage { IsSuccess = true, Message = "NONE" };
        }

        public async Task<List<UnlockRequestVM>> GetUnlockRequestsAsync()
            => await PostJsonAsync<List<UnlockRequestVM>>("api/common/unlock/request/list", GetCurrentUserParam()) ?? [];

        public async Task<ResponseMessage> UpdateUnlockRequestAsync(int unlockRequestId, bool isApproved, string remarks)
        {
            string encId = PaybillCrypto.EncodeRouteParam(unlockRequestId);
            var param = GetCurrentUserParam();
            param.remarks = remarks;
            return await PostJsonAsync<ResponseMessage>($"api/common/unlock/request/update/{encId}/{isApproved.ToString().ToLowerInvariant()}", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to update unlock request." };
        }

        public async Task<List<MessageTemplateVM>> GetMessagesAsync()
            => await GetAsync<List<MessageTemplateVM>>("api/common/message/list") ?? [];

        public async Task<ResponseMessage> SaveMessageTemplateAsync(string messageId, string description, string? messageType, bool isSelected)
        {
            var form = new Dictionary<string, string>
            {
                ["messageId"] = messageId,
                ["messageDescription"] = description,
                ["messageType"] = messageType ?? "Sales Invoice",
                ["isSelected"] = isSelected.ToString().ToLowerInvariant()
            };
            return await PostFormAsync("api/common/message/insert", form);
        }

        public async Task<ResponseMessage> SelectMessageTemplateAsync(int messageId, string messageType)
        {
            var form = new Dictionary<string, string>
            {
                ["messageId"] = messageId.ToString(),
                ["messageType"] = messageType
            };
            return await PostFormAsync("api/common/message/select", form);
        }

        public async Task<ResponseMessage> GetSelectedMessageAsync(string messageType)
            => await GetAsync<ResponseMessage>($"api/common/message/selected?messageType={Uri.EscapeDataString(messageType)}")
               ?? new ResponseMessage { IsSuccess = false, Message = string.Empty };

        public async Task<ResponseMessage> DeleteMessageTemplateAsync(int messageId)
            => await PostJsonAsync<ResponseMessage>($"api/common/message/{messageId}/delete", null)
               ?? new ResponseMessage { IsSuccess = false, Message = "Failed to delete message template." };

        public async Task<List<CustomReceiptLineVM>> GetAllCustomReceiptLinesAsync()
            => await GetAsync<List<CustomReceiptLineVM>>("api/common/custom-receipt/list") ?? [];

        public async Task<List<CustomReceiptLineVM>> GetActiveCustomReceiptLinesAsync()
            => await GetAsync<List<CustomReceiptLineVM>>("api/common/custom-receipt/active") ?? [];

        public async Task<ResponseMessage> UpsertCustomReceiptLineAsync(CustomReceiptLineVM line)
        {
            var param = GetCurrentUserParam();
            param.CustomReceiptLineModel = line;
            return await PostJsonAsync<ResponseMessage>("api/common/custom-receipt/upsert", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to save custom receipt line." };
        }

        public async Task<ResponseMessage> UpdateCustomReceiptLineStatusAsync(int customLineId, bool isActive)
            => await PostJsonAsync<ResponseMessage>($"api/common/custom-receipt/status/{customLineId}/{isActive.ToString().ToLowerInvariant()}", null)
               ?? new ResponseMessage { IsSuccess = false, Message = "Failed to update status." };

        public async Task<ResponseMessage> DeleteCustomReceiptLineAsync(int customLineId)
            => await PostJsonAsync<ResponseMessage>($"api/common/custom-receipt/{customLineId}/delete", null)
               ?? new ResponseMessage { IsSuccess = false, Message = "Failed to delete custom receipt line." };

        // ==================== INVENTORY ====================

        public async Task<List<CategoryVM>> GetCategoriesAsync()
            => await PostJsonAsync<List<CategoryVM>>("api/item/category/list", GetCurrentUserParam()) ?? [];

        public async Task<CategoryVM?> GetCategoryDetailsAsync(int categoryId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(categoryId);
            return await PostJsonAsync<CategoryVM>($"api/item/category/{encId}/details", null);
        }

        public async Task<ResponseMessage> UpsertCategoryAsync(CategoryVM category)
        {
            var param = GetCurrentUserParam();
            param.CategoryModel = category;
            return await PostJsonAsync<ResponseMessage>("api/item/category/upsert", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to save category." };
        }

        public async Task<ResponseMessage> CreateCategoryIfNotExistsAsync(string categoryName)
        {
            var param = GetCurrentUserParam();
            param.CategoryModel = new CategoryVM { CategoryName = categoryName };
            return await PostJsonAsync<ResponseMessage>("api/item/category/create", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to create category." };
        }

        public async Task<ResponseMessage> DeleteCategoryAsync(int categoryId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(categoryId);
            return await PostJsonAsync<ResponseMessage>($"api/item/category/{encId}/delete", GetCurrentUserParam())
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to delete category." };
        }

        public async Task<List<CategoryVM>> GetCategoriesWithItemCountAsync()
            => await GetAsync<List<CategoryVM>>("api/item/category/report") ?? [];

        public async Task<List<GstVM>> GetGstListAsync(bool isActiveOnly = false)
            => await PostJsonAsync<List<GstVM>>($"api/item/gst/list/{isActiveOnly.ToString().ToLowerInvariant()}", GetCurrentUserParam()) ?? [];

        public async Task<GstVM?> GetGstDetailsAsync(int gstId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(gstId);
            return await PostJsonAsync<GstVM>($"api/item/gst/{encId}/details", null);
        }

        public async Task<ResponseMessage> UpsertGstAsync(GstVM gst)
        {
            var param = GetCurrentUserParam();
            param.GstModel = gst;
            return await PostJsonAsync<ResponseMessage>("api/item/gst/upsert", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to save GST slab." };
        }

        public async Task<ResponseMessage> CreateGstIfNotExistsAsync(GstVM gst)
        {
            var param = GetCurrentUserParam();
            param.GstModel = gst;
            return await PostJsonAsync<ResponseMessage>("api/item/gst/create", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to create GST slab." };
        }

        public async Task<ResponseMessage> DeleteGstAsync(int gstId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(gstId);
            return await PostJsonAsync<ResponseMessage>($"api/item/gst/{encId}/delete", GetCurrentUserParam())
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to delete GST slab." };
        }

        public async Task<List<ServiceTypeVM>> GetServiceTypesAsync(bool isAll = true)
            => await GetAsync<List<ServiceTypeVM>>($"api/item/service/list/{isAll.ToString().ToLowerInvariant()}") ?? [];

        public async Task<ServiceTypeVM?> GetServiceTypeDetailsAsync(int serviceTypeId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(serviceTypeId);
            return await GetAsync<ServiceTypeVM>($"api/item/service/{encId}/details");
        }

        public async Task<ResponseMessage> UpsertServiceTypeAsync(ServiceTypeVM serviceType)
        {
            var param = GetCurrentUserParam();
            param.ServiceTypeModel = serviceType;
            return await PostJsonAsync<ResponseMessage>("api/item/service/upsert", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to save service type." };
        }

        public async Task<ResponseMessage> DeleteServiceTypeAsync(int serviceTypeId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(serviceTypeId);
            return await PostJsonAsync<ResponseMessage>($"api/item/service/{encId}/delete", GetCurrentUserParam())
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to delete service type." };
        }

        public async Task<List<ItemVM>> GetItemsAsync(int categoryId = 0, string? filter = null)
        {
            string qs = !string.IsNullOrWhiteSpace(filter) ? $"?filter={Uri.EscapeDataString(filter)}" : "";
            return await GetAsync<List<ItemVM>>($"api/item/item/{categoryId}/list/{qs}") ?? [];
        }

        public async Task<List<ItemVM>> GetAllItemsOfflineAsync(bool isAllItems = true)
            => await GetAsync<List<ItemVM>>($"api/item/items/for/offline/{isAllItems.ToString().ToLowerInvariant()}") ?? [];

        public async Task<List<ItemVM>> SearchItemsAsync(string? filter)
            => await GetAsync<List<ItemVM>>($"api/item/item/search?filter={Uri.EscapeDataString(filter ?? string.Empty)}") ?? [];

        public async Task<List<ItemVM>> GetItemsByCodeAsync(string itemCode)
            => await GetAsync<List<ItemVM>>($"api/item/items/code/{Uri.EscapeDataString(itemCode)}") ?? [];

        public async Task<ItemVM?> GetItemDetailsAsync(int itemId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(itemId);
            return await GetAsync<ItemVM>($"api/item/item/{encId}/details");
        }

        public async Task<ResponseMessage> UpsertItemAsync(ItemVM item)
        {
            var param = GetCurrentUserParam();
            param.ItemModel = item;
            return await PostJsonAsync<ResponseMessage>("api/item/item/upsert", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to save item." };
        }

        public async Task<ResponseMessage> DeleteItemAsync(int itemId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(itemId);
            return await PostJsonAsync<ResponseMessage>($"api/item/item/{encId}/delete", GetCurrentUserParam())
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to delete item." };
        }

        public async Task<ResponseMessage> UploadItemsBulkAsync(List<ItemVM> items)
        {
            var param = GetCurrentUserParam();
            string encUser = PaybillCrypto.EncodeRouteParam(param.UserRowId);
            string encSecKey = PaybillCrypto.EncodeRouteParam(param.SecurityKey);
            return await PostJsonAsync<ResponseMessage>($"api/item/item/upload/{encUser}/{encSecKey}", items)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to upload items." };
        }

        public async Task<List<ItemVM>> GetMinStockItemsAsync()
            => await PostJsonAsync<List<ItemVM>>("api/item/min/stock/list", GetCurrentUserParam()) ?? [];

        public async Task<ResponseMessage> ResetStockAsync()
            => await PostJsonAsync<ResponseMessage>("api/item/items/reset", null)
               ?? new ResponseMessage { IsSuccess = false, Message = "Failed to reset stock." };

        // ==================== PARTIES & REWARDS ====================

        public async Task<List<PartyVM>> GetPartiesAsync(bool isVendor)
            => await PostJsonAsync<List<PartyVM>>($"api/party/party/list/{isVendor.ToString().ToLowerInvariant()}", GetCurrentUserParam()) ?? [];

        public async Task<List<PartyVM>> GetActivePartiesAsync(bool isVendor, bool isAll = false)
            => await GetAsync<List<PartyVM>>($"api/party/party/active/list/{isVendor.ToString().ToLowerInvariant()}/{isAll.ToString().ToLowerInvariant()}") ?? [];

        public async Task<PartyVM?> GetPartyDetailsAsync(int partyId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(partyId);
            return await PostJsonAsync<PartyVM>($"api/party/party/{encId}/details", null);
        }

        public async Task<ResponseMessage> UpsertPartyAsync(PartyVM party)
        {
            var param = GetCurrentUserParam();
            param.PartyModel = party;
            return await PostJsonAsync<ResponseMessage>("api/party/party/upsert", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to save party." };
        }

        public async Task<ResponseMessage> DeletePartyAsync(int partyId, bool isVendor)
        {
            string encId = PaybillCrypto.EncodeRouteParam(partyId);
            return await PostJsonAsync<ResponseMessage>($"api/party/party/{encId}/delete/{isVendor.ToString().ToLowerInvariant()}", GetCurrentUserParam())
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to delete party." };
        }

        public async Task<double> GetCustomerAvailablePointsAsync(int partyId)
        {
            var res = await GetAsync<ResponseMessage>($"api/party/party/{partyId}/rewards/available");
            if (res != null && double.TryParse(res.Data ?? res.Message, out double pts))
                return pts;
            return 0.0;
        }

        public async Task<RewardCustomerSummaryVM?> GetCustomerRewardsSummaryAsync(int partyId)
            => await GetAsync<RewardCustomerSummaryVM>($"api/party/party/{partyId}/rewards/summary");

        public async Task<string> GetCustomerEarliestExpiryDateAsync(int partyId)
        {
            var res = await GetAsync<ResponseMessage>($"api/party/party/{partyId}/rewards/expiry");
            return res?.Data ?? res?.Message ?? string.Empty;
        }

        public async Task<List<RewardTransactionVM>> GetRewardsTransactionsAsync(
            int? partyId = null, int? salesId = null, string? fromDate = null, string? toDate = null, string? transType = null, string? searchQuery = null)
        {
            var q = new List<string>();
            if (partyId.HasValue && partyId.Value > 0) q.Add($"partyId={partyId.Value}");
            if (salesId.HasValue && salesId.Value > 0) q.Add($"salesId={salesId.Value}");
            if (!string.IsNullOrWhiteSpace(fromDate)) q.Add($"fromDate={Uri.EscapeDataString(fromDate)}");
            if (!string.IsNullOrWhiteSpace(toDate)) q.Add($"toDate={Uri.EscapeDataString(toDate)}");
            if (!string.IsNullOrWhiteSpace(transType)) q.Add($"transType={Uri.EscapeDataString(transType)}");
            if (!string.IsNullOrWhiteSpace(searchQuery)) q.Add($"searchQuery={Uri.EscapeDataString(searchQuery)}");
            string qs = q.Count > 0 ? "?" + string.Join("&", q) : "";
            return await GetAsync<List<RewardTransactionVM>>($"api/party/party/rewards/transactions{qs}") ?? [];
        }

        public async Task<ResponseMessage> SaveManualRewardAdjustmentAsync(int partyId, double points, string reason)
        {
            var param = GetCurrentUserParam();
            var req = new RewardAdjustmentRequestVM
            {
                PartyId = partyId,
                Points = points,
                Reason = reason,
                UserRowId = param.UserRowId,
                SecurityKey = param.SecurityKey
            };
            return await PostJsonAsync<ResponseMessage>("api/party/party/rewards/adjustment", req)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to save reward adjustment." };
        }

        public async Task<List<RewardCustomerSummaryVM>> GetAllCustomerRewardsSummaryAsync(string? fromDate = null, string? toDate = null, string? searchQuery = null)
        {
            var q = new List<string>();
            if (!string.IsNullOrWhiteSpace(fromDate)) q.Add($"fromDate={Uri.EscapeDataString(fromDate)}");
            if (!string.IsNullOrWhiteSpace(toDate)) q.Add($"toDate={Uri.EscapeDataString(toDate)}");
            if (!string.IsNullOrWhiteSpace(searchQuery)) q.Add($"searchQuery={Uri.EscapeDataString(searchQuery)}");
            string qs = q.Count > 0 ? "?" + string.Join("&", q) : "";
            return await GetAsync<List<RewardCustomerSummaryVM>>($"api/party/party/rewards/customers-summary{qs}") ?? [];
        }

        public async Task<RewardOverallSummaryVM> GetOverallRewardsSummaryAsync()
            => await GetAsync<RewardOverallSummaryVM>("api/party/party/rewards/overall-summary") ?? new RewardOverallSummaryVM();

        public async Task<ResponseMessage> ExpireOldPointsAsync()
            => await PostJsonAsync<ResponseMessage>("api/party/party/rewards/expire", null)
               ?? new ResponseMessage { IsSuccess = false, Message = "Failed to expire points." };

        public async Task<List<RewardRedemptionDetailVM>> GetRedemptionDetailsAsync(
            string? specificDate = null, string? fromDate = null, string? toDate = null, string? searchQuery = null, string? filterInvoiceNo = null)
        {
            var q = new List<string>();
            if (!string.IsNullOrWhiteSpace(specificDate)) q.Add($"specificDate={Uri.EscapeDataString(specificDate)}");
            if (!string.IsNullOrWhiteSpace(fromDate)) q.Add($"fromDate={Uri.EscapeDataString(fromDate)}");
            if (!string.IsNullOrWhiteSpace(toDate)) q.Add($"toDate={Uri.EscapeDataString(toDate)}");
            if (!string.IsNullOrWhiteSpace(searchQuery)) q.Add($"searchQuery={Uri.EscapeDataString(searchQuery)}");
            if (!string.IsNullOrWhiteSpace(filterInvoiceNo)) q.Add($"filterInvoiceNo={Uri.EscapeDataString(filterInvoiceNo)}");
            string qs = q.Count > 0 ? "?" + string.Join("&", q) : "";
            return await GetAsync<List<RewardRedemptionDetailVM>>($"api/party/party/rewards/redemptions{qs}") ?? [];
        }

        // ==================== SALES & JOB CARDS ====================

        public async Task<DashboardSalesSummaryResponse> GetDashboardSalesSummaryAsync()
            => await PostJsonAsync<DashboardSalesSummaryResponse>("api/sales/sales/summary/dashboard", GetCurrentUserParam())
               ?? new DashboardSalesSummaryResponse();

        public async Task<ResponseMessage> SaveSalesInvoiceAsync(SalesVM sales)
        {
            var param = GetCurrentUserParam();
            param.SalesModel = sales;
            return await PostJsonAsync<ResponseMessage>("api/sales/sales/invoice/save", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to save sales invoice." };
        }

        public async Task<List<SalesVM>> GetSalesInvoicesAsync(string fromDate, string toDate)
            => await PostJsonAsync<List<SalesVM>>($"api/sales/sales/invoice/list/{Uri.EscapeDataString(fromDate)}/{Uri.EscapeDataString(toDate)}", GetCurrentUserParam()) ?? [];

        public async Task<SalesVM?> GetSalesInvoiceDetailsAsync(int salesId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(salesId);
            return await PostJsonAsync<SalesVM>($"api/sales/sales/invoice/details/{encId}", GetCurrentUserParam());
        }

        public async Task<ResponseMessage> DeleteSalesItemAsync(int salesItemId, string remarks)
        {
            string encId = PaybillCrypto.EncodeRouteParam(salesItemId);
            var param = GetCurrentUserParam();
            param.remarks = remarks;
            return await PostJsonAsync<ResponseMessage>($"api/sales/sales/item/{encId}/delete", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to delete sales item." };
        }

        public async Task<ResponseMessage> DeleteSalesInvoiceAsync(int salesId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(salesId);
            return await PostJsonAsync<ResponseMessage>($"api/sales/sales/invoice/{encId}/delete", GetCurrentUserParam())
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to delete sales invoice." };
        }

        public async Task<PrintSalesInvoice?> GetSalesInvoiceToPrintAsync(int salesId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(salesId);
            return await PostJsonAsync<PrintSalesInvoice>($"api/sales/sales/invoice/{encId}/print", GetCurrentUserParam());
        }

        public async Task<string> GetNextJobCardNumberAsync()
        {
            var res = await GetAsync<ResponseMessage>("api/sales/jobcard/next-number");
            return res?.Data ?? res?.Message ?? "1";
        }

        public async Task<ResponseMessage> SaveJobCardAsync(JobCardVM jobCard)
        {
            var param = GetCurrentUserParam();
            param.JobCardModel = jobCard;
            return await PostJsonAsync<ResponseMessage>("api/sales/jobcard/save", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to save job card." };
        }

        public async Task<List<JobCardVM>> GetActiveJobCardsAsync()
            => await PostJsonAsync<List<JobCardVM>>("api/sales/jobcard/list", GetCurrentUserParam()) ?? [];

        public async Task<JobCardVM?> GetJobCardDetailsAsync(int serviceRequestId)
            => await PostJsonAsync<JobCardVM>($"api/sales/jobcard/{serviceRequestId}/details", GetCurrentUserParam());

        public async Task<ResponseMessage> DeleteJobCardAsync(int serviceRequestId)
            => await PostJsonAsync<ResponseMessage>($"api/sales/jobcard/{serviceRequestId}/delete", GetCurrentUserParam())
               ?? new ResponseMessage { IsSuccess = false, Message = "Failed to delete job card." };

        public async Task<ResponseMessage> DeleteJobCardItemAsync(int complaintId)
            => await PostJsonAsync<ResponseMessage>($"api/sales/jobcard/item/{complaintId}/delete", GetCurrentUserParam())
               ?? new ResponseMessage { IsSuccess = false, Message = "Failed to delete service item." };

        public async Task<ResponseMessage> DeleteJobCardSpareAsync(int spareId)
            => await PostJsonAsync<ResponseMessage>($"api/sales/jobcard/spare/{spareId}/delete", GetCurrentUserParam())
               ?? new ResponseMessage { IsSuccess = false, Message = "Failed to delete spare part." };

        public async Task<ResponseMessage> UpdateJobCardStatusAsync(int serviceRequestId, int statusId)
            => await PostJsonAsync<ResponseMessage>($"api/sales/jobcard/{serviceRequestId}/status/{statusId}", GetCurrentUserParam())
               ?? new ResponseMessage { IsSuccess = false, Message = "Failed to update job card status." };

        public async Task<ResponseMessage> GenerateJobCardInvoiceAsync(int jobCardId)
            => await PostJsonAsync<ResponseMessage>($"api/sales/jobcard/{jobCardId}/generate-invoice", GetCurrentUserParam())
               ?? new ResponseMessage { IsSuccess = false, Message = "Failed to generate sales invoice." };

        public async Task<SalesVM?> GetJobCardSalesInvoiceAsync(int jobCardId)
            => await PostJsonAsync<SalesVM>($"api/sales/jobcard/{jobCardId}/sales-invoice", GetCurrentUserParam());

        // ==================== PURCHASES & PURCHASE ORDERS ====================

        public async Task<ResponseMessage> UpsertPurchaseAsync(PurchaseVM purchase)
        {
            var param = GetCurrentUserParam();
            param.PurchaseModel = purchase;
            return await PostJsonAsync<ResponseMessage>("api/purchase/purchase/upsert", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to save purchase invoice." };
        }

        public async Task<List<PurchaseVM>> GetPurchaseInvoicesAsync(string fromDate, string toDate)
            => await PostJsonAsync<List<PurchaseVM>>($"api/purchase/purchase/invoice/list/{Uri.EscapeDataString(fromDate)}/{Uri.EscapeDataString(toDate)}", GetCurrentUserParam()) ?? [];

        public async Task<PurchaseVM?> GetPurchaseInvoiceDetailsAsync(int purchaseId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(purchaseId);
            return await PostJsonAsync<PurchaseVM>($"api/purchase/purchase/invoice/details/{encId}", GetCurrentUserParam());
        }

        public async Task<ResponseMessage> DeletePurchaseItemAsync(int purchaseItemId, string remarks)
        {
            string encId = PaybillCrypto.EncodeRouteParam(purchaseItemId);
            var param = GetCurrentUserParam();
            param.remarks = remarks;
            return await PostJsonAsync<ResponseMessage>($"api/purchase/purchase/item/{encId}/delete", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to delete purchase item." };
        }

        public async Task<ResponseMessage> DeletePurchaseInvoiceAsync(int purchaseId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(purchaseId);
            return await PostJsonAsync<ResponseMessage>($"api/purchase/purchase/invoice/{encId}/delete", GetCurrentUserParam())
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to delete purchase invoice." };
        }

        public async Task<List<PurchaseItemVM>> GetPurchaseOrderItemsForPurchaseAsync(int purchaseOrderId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(purchaseOrderId);
            return await GetAsync<List<PurchaseItemVM>>($"api/purchase/purchase/order/items/{encId}") ?? [];
        }

        public async Task<ResponseMessage> UpsertPurchaseOrderAsync(PurchaseOrderVM order)
        {
            var param = GetCurrentUserParam();
            param.PurchaseOrderModel = order;
            return await PostJsonAsync<ResponseMessage>("api/purchaseorder/purchase/order/upsert", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to save purchase order." };
        }

        public async Task<PurchaseOrderVM?> GetPurchaseOrderDetailsAsync(int purchaseOrderId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(purchaseOrderId);
            return await PostJsonAsync<PurchaseOrderVM>($"api/purchaseorder/purchase/order/details/{encId}", GetCurrentUserParam());
        }

        public async Task<List<PurchaseOrderVM>> GetActivePurchaseOrdersAsync()
            => await PostJsonAsync<List<PurchaseOrderVM>>("api/purchaseorder/purchase/order/active/list", GetCurrentUserParam()) ?? [];

        public async Task<ResponseMessage> DeletePurchaseOrderItemAsync(int purchaseOrderItemId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(purchaseOrderItemId);
            return await PostJsonAsync<ResponseMessage>($"api/purchaseorder/purchase/order/item/{encId}/delete", GetCurrentUserParam())
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to delete purchase order item." };
        }

        public async Task<ResponseMessage> DeletePurchaseOrderAsync(int purchaseOrderId)
        {
            string encId = PaybillCrypto.EncodeRouteParam(purchaseOrderId);
            return await PostJsonAsync<ResponseMessage>($"api/purchaseorder/purchase/order/{encId}/delete", GetCurrentUserParam())
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to delete purchase order." };
        }

        // ==================== TRANSACTIONS ====================

        public async Task<ResponseMessage> InsertTransactionAsync(TransactionVM transaction)
        {
            var param = GetCurrentUserParam();
            param.TransactionModel = transaction;
            return await PostJsonAsync<ResponseMessage>("api/transaction/trans/insert", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to save transaction." };
        }

        public async Task<ResponseMessage> DeleteTransactionAsync(int transactionId, string remarks)
        {
            string encId = PaybillCrypto.EncodeRouteParam(transactionId);
            var param = GetCurrentUserParam();
            param.remarks = remarks;
            return await PostJsonAsync<ResponseMessage>($"api/transaction/trans/{encId}/delete", param)
                   ?? new ResponseMessage { IsSuccess = false, Message = "Failed to delete transaction." };
        }

        public async Task<List<TransactionVM>> GetTodayTransactionsAsync(bool isPayment)
            => await PostJsonAsync<List<TransactionVM>>($"api/transaction/trans/list/today/{isPayment.ToString().ToLowerInvariant()}", GetCurrentUserParam()) ?? [];

        public async Task<List<TransactionVM>> GetTransactionsAsync(string fromDate, string toDate, int isPayment)
        {
            string encFrom = PaybillCrypto.EncodeRouteParam(fromDate);
            string encTo = PaybillCrypto.EncodeRouteParam(toDate);
            return await PostJsonAsync<List<TransactionVM>>($"api/transaction/trans/list/today/{encFrom}/{encTo}/{isPayment}", GetCurrentUserParam()) ?? [];
        }

        // ==================== REPORTS ====================

        public async Task<List<GSTReturnDetailed>> GetGSTReturnDetailedAsync(string fromDate, string toDate, string? returnType = null)
        {
            string rt = !string.IsNullOrWhiteSpace(returnType) ? $"&returnType={Uri.EscapeDataString(returnType)}" : "";
            return await GetAsync<List<GSTReturnDetailed>>($"api/report/sales/gst/return/detailed?fromDate={Uri.EscapeDataString(fromDate)}&toDate={Uri.EscapeDataString(toDate)}{rt}") ?? [];
        }

        public async Task<List<GSTHSNSummary>> GetGSTHSNSummaryAsync(string fromDate, string toDate)
            => await GetAsync<List<GSTHSNSummary>>($"api/report/sales/gst/hsn/summary?fromDate={Uri.EscapeDataString(fromDate)}&toDate={Uri.EscapeDataString(toDate)}") ?? [];

        public async Task<List<GSTHSNSummary>> GetGSTSACSummaryAsync(string fromDate, string toDate)
            => await GetAsync<List<GSTHSNSummary>>($"api/report/sales/gst/sac/summary?fromDate={Uri.EscapeDataString(fromDate)}&toDate={Uri.EscapeDataString(toDate)}") ?? [];

        public async Task<List<SalesVM>> GetSalesDetailsReportAsync(ReportParam param)
            => await PostJsonAsync<List<SalesVM>>("api/report/sales/details", param) ?? [];

        public async Task<byte[]?> DownloadSalesDetailsExcelAsync(ReportParam param)
        {
            try
            {
                using var client = CreateClient();
                var content = new StringContent(JsonSerializer.Serialize(param, JsonOptions), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/report/sales/details/download", content);
                if (!response.IsSuccessStatusCode) return null;
                return await response.Content.ReadAsByteArrayAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<SalesSummary>> GetSalesSummaryReportAsync(ReportParam param)
            => await PostJsonAsync<List<SalesSummary>>("api/report/sales/summary", param) ?? [];

        public async Task<byte[]?> DownloadSalesSummaryExcelAsync(ReportParam param)
        {
            try
            {
                using var client = CreateClient();
                var content = new StringContent(JsonSerializer.Serialize(param, JsonOptions), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/report/sales/summary/download", content);
                if (!response.IsSuccessStatusCode) return null;
                return await response.Content.ReadAsByteArrayAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<PurchaseVM>> GetPurchaseDetailsReportAsync(ReportParam param)
            => await PostJsonAsync<List<PurchaseVM>>("api/report/purchase/details", param) ?? [];

        public async Task<List<TransactionVM>> GetPartyLedgerAsync(int partyId, string fromDate, string toDate)
        {
            var up = GetCurrentUserParam();
            var param = new ReportParam
            {
                UserRowId = up.UserRowId,
                SecurityKey = up.SecurityKey,
                Id = partyId.ToString(),
                FromDate = fromDate,
                ToDate = toDate
            };
            return await PostJsonAsync<List<TransactionVM>>("api/report/party/ledger", param) ?? [];
        }

        public async Task<List<BalanceSheet>> GetBalanceSheetAsync()
            => await PostJsonAsync<List<BalanceSheet>>("api/report/party/balance/sheet", GetCurrentUserParam()) ?? [];

        public async Task<List<TransactionVM>> GetDaybookAsync(string fromDate, string toDate)
        {
            string encFrom = PaybillCrypto.EncodeRouteParam(fromDate);
            string encTo = PaybillCrypto.EncodeRouteParam(toDate);
            return await GetAsync<List<TransactionVM>>($"api/report/trans/daybook/{encFrom}/{encTo}") ?? [];
        }

        public async Task<List<SalesItemVM>> GetDeletedSalesItemsAsync(string fromDate, string toDate)
            => await GetAsync<List<SalesItemVM>>($"api/report/sales/items/deleted?fromDate={Uri.EscapeDataString(fromDate)}&toDate={Uri.EscapeDataString(toDate)}") ?? [];

        public async Task<List<PurchaseItemVM>> GetDeletedPurchaseItemsAsync(string fromDate, string toDate)
            => await GetAsync<List<PurchaseItemVM>>($"api/report/purchase/items/deleted?fromDate={Uri.EscapeDataString(fromDate)}&toDate={Uri.EscapeDataString(toDate)}") ?? [];

        public async Task<List<PurchaseOrderVM>> GetPurchaseOrderReportListAsync()
            => await PostJsonAsync<List<PurchaseOrderVM>>("api/report/purchase/order/list", GetCurrentUserParam()) ?? [];

        public async Task<List<InventoryValuation>> GetInventoryValuationAsync(string? filter = null)
        {
            string qs = !string.IsNullOrWhiteSpace(filter) ? $"?filter={Uri.EscapeDataString(filter)}" : "";
            return await GetAsync<List<InventoryValuation>>($"api/report/inventory/valuation{qs}") ?? [];
        }

        public async Task<List<ItemVM>> GetAgedInventoryAsync(int inventoryAge)
            => await GetAsync<List<ItemVM>>($"api/report/inventory/age?inventoryAge={inventoryAge}") ?? [];

        public async Task<List<ProductMovementModel>> GetProductMovementAnalysisAsync(string fromDate, string toDate)
        {
            var up = GetCurrentUserParam();
            var param = new ReportParam
            {
                UserRowId = up.UserRowId,
                SecurityKey = up.SecurityKey,
                FromDate = fromDate,
                ToDate = toDate
            };
            return await PostJsonAsync<List<ProductMovementModel>>("api/report/product/movement/analysis", param) ?? [];
        }

        public async Task<List<ChartData>> GetDayWiseSalesChartAsync(string fromDate, string toDate)
            => await GetAsync<List<ChartData>>($"api/report/sales/day/wise/summary?fromDate={Uri.EscapeDataString(fromDate)}&toDate={Uri.EscapeDataString(toDate)}") ?? [];

        public async Task<List<ChartData>> GetMonthWiseSalesChartAsync(string fromDate, string toDate)
            => await GetAsync<List<ChartData>>($"api/report/sales/month/wise/summary?fromDate={Uri.EscapeDataString(fromDate)}&toDate={Uri.EscapeDataString(toDate)}") ?? [];

        public async Task<List<ChartData>> GetItemWiseSalesChartAsync(string fromDate, string toDate)
            => await GetAsync<List<ChartData>>($"api/report/sales/item/wise/summary?fromDate={Uri.EscapeDataString(fromDate)}&toDate={Uri.EscapeDataString(toDate)}") ?? [];

        public async Task<List<ChartData>> GetPaymentModeChartAsync(string fromDate, string toDate)
            => await GetAsync<List<ChartData>>($"api/report/sales/payment/mode/summary?fromDate={Uri.EscapeDataString(fromDate)}&toDate={Uri.EscapeDataString(toDate)}") ?? [];
    }
}


