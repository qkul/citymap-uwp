﻿using CityMapUWP.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CityMapUWP.Services.Api
{
    public sealed class AppApiService
    {
        private const string AppDataUrl = "https://api.myjson.com/bins/7ybe5";

        public async Task<AppData> FetchDataAsync()
        {
            var httpClient = new HttpClient();
            var appDataUri = new Uri(AppDataUrl);
            var result = new AppData();

            try
            {
                var response = await httpClient.GetStringAsync(appDataUri);
                result = JsonConvert.DeserializeObject<AppData>(response);
            }
            catch (Exception)
            {

                throw;
            }
            httpClient.Dispose();
            return result;
        }
    }

}
