using BlazorAppTareasPendientes.Models;
using System.Net.Http.Json;

namespace BlazorAppTareasPendientes.Services
{
    public class TareasService
    {
        private readonly HttpClient _httpClient;
        public TareasService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }
        public async Task<IEnumerable<TareasPendientes>> GetTareasPendientesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TareasPendientes>>("TareasPendientes");
        }
        public async Task<TareasPendientes> GetTareaPendienteByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<TareasPendientes>($"TareasPendientes/{id}");
        }
        public async Task<TareasPendientes> CreateTareaPendienteAsync(TareasPendientes tarea)
        {
            var response = await _httpClient.PostAsJsonAsync("TareasPendientes", tarea);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TareasPendientes>();
        }
        public async Task UpdateTareaPendienteAsync(int id, TareasPendientes tarea)
        {
            var response = await _httpClient.PutAsJsonAsync($"TareasPendientes/{id}", tarea);
            response.EnsureSuccessStatusCode();
        }
        public async Task DeleteTareaPendienteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"TareasPendientes/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
