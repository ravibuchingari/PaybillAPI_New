using PaybillWinApp.Models;
using System;
using System.Data;
using System.Data.SQLite;

namespace PaybillWinApp.Repositories
{
    public class SQLiteHelper: ISQLiteHelper
    {
        private static async Task<DataTable> ExecuteDataTable(string query)
        {
            using SQLiteConnection connection = new(AppVariables.SQLITE_DB);
            using SQLiteCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandText = query;
            SQLiteDataAdapter adapter = new()
            {
                SelectCommand = command
            };
            DataSet dataSet = new();
            adapter.Fill(dataSet);
            return await Task.FromResult(dataSet.Tables[0]);
        }

        public async Task<int> CreateAccount(ClientVM client)
        {
            string query = $"INSERT INTO {AppVariables.TABLE_PREF} (clientUniqueId, clientId, clientName, mobile, email, address, subscriptionType, subscriptionAmount, subscriptionEndDate, isPremiumUser, isApiService, countryId, countryName, countryCurrencyCode, countryCurrencySymbol, countryLocaleCode, countryMobileLength, serviceUrl) VALUES (@clientUniqueId, @clientId, @clientName, @mobile, @email, @address, @subscriptionType, @subscriptionAmount, @subscriptionEndDate, @isPremiumUser, @isApiService, @countryId, @countryName, @countryCurrencyCode, @countryCurrencySymbol, @countryLocaleCode, @countryMobileLength, @serviceUrl)";
            using SQLiteConnection connection = new(AppVariables.SQLITE_DB);
            using SQLiteCommand command = connection.CreateCommand();
            command.Connection.Open();

            command.CommandText = $"DELETE FROM {AppVariables.TABLE_PREF}";
            await command.ExecuteNonQueryAsync();

            command.CommandText = query;
            command.Parameters.AddWithValue("@clientUniqueId", client.ClientUniqueId);
            command.Parameters.AddWithValue("@clientId", client.ClientId);
            command.Parameters.AddWithValue("@clientName", client.ClientName);
            command.Parameters.AddWithValue("@mobile", client.Mobile);
            command.Parameters.AddWithValue("@email", client.Email);
            command.Parameters.AddWithValue("@address", client.Address);
            command.Parameters.AddWithValue("@subscriptionType", client.SubscriptionType);
            command.Parameters.AddWithValue("@subscriptionAmount", client.SubscriptionAmount);
            command.Parameters.AddWithValue("@subscriptionEndDate", client.SubscriptionEndDate);
            command.Parameters.AddWithValue("@isPremiumUser", client.IsPremiumUser);
            command.Parameters.AddWithValue("@isApiService", client.IsApiService);
            command.Parameters.AddWithValue("@countryId", client.Country.CountryId);
            command.Parameters.AddWithValue("@countryName", client.Country.CountryName);
            command.Parameters.AddWithValue("@countryCurrencyCode", client.Country.CountryCurrencyCode);
            command.Parameters.AddWithValue("@countryCurrencySymbol", client.Country.CountryCurrencySymbol);
            command.Parameters.AddWithValue("@countryLocaleCode", client.Country.CountryLocaleCode);
            command.Parameters.AddWithValue("@countryMobileLength", client.Country.CountryMobileLength);
            command.Parameters.AddWithValue("@serviceUrl", client.ServiceUrl);
            return await command.ExecuteNonQueryAsync();
        }

        public async Task<DataTable> GetClientPref()
        {
            string query = $"SELECT * FROM {AppVariables.TABLE_PREF}";
            return await ExecuteDataTable(query);
        }
    }
}
