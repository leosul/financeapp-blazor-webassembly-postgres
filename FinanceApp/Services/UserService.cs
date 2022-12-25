using System.Text;
using System.Text.Json;
using FinanceApp.ViewModel;

namespace FinanceApp.Services;

public class UserService : IUserService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;

    public UserService(HttpClient client)
    {
        _client = client;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = false };
    }

    public async Task<bool> AddAsync(UserViewModel user)
    {
        var content = JsonSerializer.Serialize(user);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync($"users", bodyContent);
        var result = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<bool>(result, _options);
    }

    public async Task<List<UserViewModel>> FindAllAsync()
    {
        var response = await _client.GetAsync("users");
        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<UserViewModel>>(content, _options);
    }

    public async Task<UserViewModel> FindByIdAsync(string id)
    {
        var response = await _client.GetAsync($"users/{Guid.Parse(id)}");
        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<UserViewModel>(content, _options);
    }

    public async Task<UserViewModel> UpdatedAsync(UserViewModel user)
    {
        var content = JsonSerializer.Serialize(user);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        var response = await _client.PutAsync($"users", bodyContent);
        var result = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<UserViewModel>(result, _options);
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var response = await _client.DeleteAsync($"users/{Guid.Parse(id)}");
        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<bool>(content, _options);
    }
}
