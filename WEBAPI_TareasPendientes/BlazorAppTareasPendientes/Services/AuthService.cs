using BlazorAppTareasPendientes.Models;
using System.Net.Http.Json;

namespace BlazorAppTareasPendientes.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> Login(LoginModel loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync("Authenticate/login", loginModel);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<AuthResponse>();
            return result.Token;
        }
        public async Task<string> Register(RegisterModel registerModel)
        {
            var response = await _httpClient.PostAsJsonAsync("Authenticate/register", registerModel);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<Response>();
            return result.Status;
        }
        public async Task<string> RegisterAdmin(RegisterModel registerModel)
        {
            var response = await _httpClient.PostAsJsonAsync("Authenticate/register-admin", registerModel);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<Response>();
            return result.Status;
        }
    }
}
