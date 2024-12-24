using PaybillWinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
