using PaybillWinApp.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace PaybillWinApp.Repositories
{
    public class BaseRepository
    {
        private static readonly HttpClient client = new();
        public static async Task<string> GetApiDataAsync(string action)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(requestUri: $"{AppVariables.ApiUrl}{Controller.Home}/{action}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                return $"Request error: {e.Message}";
            }
        }

        public static async Task<T?> GetApiDataAsync<T>(string action) where T : class, new()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(requestUri: $"{AppVariables.ApiUrl}{Controller.Home}/{action}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (HttpRequestException e)
            {
                return $"HTTP request error: {e.Message}" as T;
            }
            catch (NotSupportedException e)
            {
                return $"The content type is not supported: {e.Message}" as T;
            }
            catch (JsonException e)
            {
                return $"JSON parsing error: {e.Message}" as T;
            }
            catch (Exception e)
            {
                return $"Unexpected error: {e.Message}" as T;
            }
        }
    }
}
