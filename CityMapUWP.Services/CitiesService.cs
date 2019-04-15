using CityMapUWP.Infrastructure;
using CityMapUWP.Models;
using CityMapUWP.Services.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityMapUWP.Services
{
    public sealed class CitiesService
    {
        private readonly AppApiService _contextApiService;
        private readonly LocalStorage _contextStorage;

        public CitiesService()
        {
            _contextApiService = new AppApiService();
            _contextStorage = new LocalStorage();
        }

        public async Task<IEnumerable<City>> LoadCitiesAsync()
        {
            var appData = await _contextApiService.FetchDataAsync();
            if (appData.Cities == null)
                appData = await _contextStorage.GetDataAsync();
            else
                await _contextStorage.SaveDateAsync(appData);

            return appData.Cities;
        }
    }
}