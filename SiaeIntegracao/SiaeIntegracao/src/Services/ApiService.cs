using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http.Headers;

namespace SiaeIntegracao.src.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;
        private readonly ProtectedLocalStorage _storage;
        private readonly NavigationManager _nav;

        public ApiService(HttpClient http, ProtectedLocalStorage storage, NavigationManager nav)
        {
            _http = http;
            _storage = storage;
            _nav = nav;
        }

        public async Task<T?> GetAsync<T>(string url)
        {
            var token = await _storage.GetAsync<string>("authToken");

            if (token.Success && !string.IsNullOrEmpty(token.Value))
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
            }

            var response = await _http.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                _nav.NavigateTo("/login");
                return default;
            }

            if (!response.IsSuccessStatusCode) return default;

            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
