using CityMapUWP.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Windows.Storage;

namespace CityMapUWP.Infrastructure
{
    public class LocalStorage
    {
        private const string AppDataFileName = "appData.txt";
        private readonly StorageFolder _localStorage;

        public LocalStorage()
        {
            _localStorage = ApplicationData.Current.LocalFolder;
        }

        public async Task SaveDateAsync(AppData data)
        {
            var dataFile = await _localStorage.CreateFileAsync(AppDataFileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(dataFile, JsonConvert.SerializeObject(data));
        }

        public async Task<AppData> GetDataAsync()
        {
            try
            {
                var dataFile = await _localStorage.GetFileAsync(AppDataFileName);
                var saveData = await FileIO.ReadTextAsync(dataFile);

                return JsonConvert.DeserializeObject<AppData>(saveData);
            }
            catch (Exception)
            {

                return new AppData();
            }
        }

    }
}
