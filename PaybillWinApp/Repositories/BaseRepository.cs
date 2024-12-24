using PaybillWinApp.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace PaybillWinApp.Repositories
{
    public class BaseRepository
    {
        private static readonly HttpClient client = new();

        private static T CreateErrorResponse<T>(string errorMessage) where T : class, new() 
        { 
            var errorResponse = new T() as dynamic; 
            errorResponse.IsSuccess = false; 
            errorResponse.Message = errorMessage; 
            return errorResponse; 
        }

        public static async Task<string> GetApiDataAsync(string controller, string action)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(requestUri: $"{AppVariables.ApiUrl}{controller}/{action}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                return $"Request error: {e.Message}";
            }
        }

        public static async Task<T> GetApiDataAsync<T>(string controller, string action) where T : class, new()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(requestUri: $"{AppVariables.ApiUrl}{controller}/{action}");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<T>();
                return result ?? throw new Exception("Unexpected error");
            }
            catch (HttpRequestException e) { throw new Exception($"HTTP request error: {e.Message}"); }
            catch (NotSupportedException e) { throw new Exception($"The content type is not supported: {e.Message}"); }
            catch (JsonException e) { throw new Exception($"JSON parsing error: {e.Message}"); }
            catch (Exception e) { throw new Exception($"Unexpected error: {e.Message}"); }
        }

        public static async Task<T> PostApiDataAsync<T>(string controller, string action, object? data = null) where T : class, new()
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(requestUri: $"{AppVariables.ApiUrl}{controller}/{action}", data);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<T>();
                return result ?? throw new Exception("Unexpected error");
            }
            catch (HttpRequestException e) { throw new Exception($"HTTP request error: {e.Message}"); }
            catch (NotSupportedException e) { throw new Exception($"The content type is not supported: {e.Message}"); }
            catch (JsonException e) { throw new Exception($"JSON parsing error: {e.Message}"); }
            catch (Exception e) { throw new Exception($"Unexpected error: {e.Message}"); }
        }
    }
}
