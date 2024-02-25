
using Blazored.LocalStorage;

namespace ClientLibrary.Helpers
{
    public class LocalStorageService(ILocalStorageService LocalStorageService)
    {
        private const string StorageKey = "authentication-token";
        public async Task<string> GetToken() => await LocalStorageService.GetItemAsStringAsync(StorageKey);
        public async Task SetToken(string item) => await LocalStorageService.SetItemAsStringAsync(StorageKey, item);
        public async Task RemoveToken() => await LocalStorageService.RemoveItemAsync(StorageKey);



    }
}
