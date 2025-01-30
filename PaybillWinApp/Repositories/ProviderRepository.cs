using PaybillWinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PaybillWinApp.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private static readonly HttpClient client = new();

        private static async Task<T> GetApiDataAsync<T>(string action) where T : class, new()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(requestUri: $"{AppVariables.PROVIDER_BASE_URL}/{action}");
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadFromJsonAsync<T>();
                    return result ?? throw new Exception("Unexpected error");
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    throw new Exception(result);
                }
            }
            catch (HttpRequestException e) { throw new Exception($"HTTP request error: {e.Message}"); }
            catch (NotSupportedException e) { throw new Exception($"The content type is not supported: {e.Message}"); }
            catch (JsonException e) { throw new Exception($"JSON parsing error: {e.Message}"); }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        private static async Task<T> PostApiDataAsync<T>(string action, object? data = null) where T : class, new()
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(requestUri: $"{AppVariables.PROVIDER_BASE_URL}{action}", data);
                if(response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadFromJsonAsync<T>();
                    return result ?? throw new Exception("Unexpected error");
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    throw new Exception(result);
                }
            }
            catch (HttpRequestException e) { throw new Exception($"HTTP request error: {e.Message}"); }
            catch (NotSupportedException e) { throw new Exception($"The content type is not supported: {e.Message}"); }
            catch (JsonException e) { throw new Exception($"JSON parsing error: {e.Message}"); }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public async Task<ResponseMessage> VerifyClientAccount(string mobile) => await PostApiDataAsync<ResponseMessage>($"client/{mobile}/validate"); //$"client/{mobile}/validate/system"

        public async Task<ResponseMessage> VerifyClientOTP(ClientVM client) => await PostApiDataAsync<ResponseMessage>($"client/account/otp/verify", client);

    }
}
