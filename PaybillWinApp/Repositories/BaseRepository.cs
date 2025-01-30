using PaybillWinApp.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace PaybillWinApp.Repositories
{
    public class BaseRepository
    {
        private static readonly HttpClient client = new();

       /* private static T CreateErrorResponse<T>(string errorMessage) where T : class, new() 
        { 
            var errorResponse = new T() as dynamic; 
            errorResponse.IsSuccess = false; 
            errorResponse.Message = errorMessage; 
            return errorResponse; 
        }*/

        public static async Task<string> GetApiDataAsync(string controller, string action)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(requestUri: $"{AppVariables.API_BASE_URL}{controller}/{action}");
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
                HttpResponseMessage response = await client.GetAsync(requestUri: $"{AppVariables.API_BASE_URL}{controller}/{action}");
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
            catch (System.Text.Json.JsonException e) { throw new Exception($"JSON parsing error: {e.Message}"); }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        public static async Task<T> PostApiDataAsync<T>(string controller, string action, object? data = null) where T : class, new()
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(requestUri: $"{AppVariables.API_BASE_URL}{controller}/{action}", data);
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
    }
}
