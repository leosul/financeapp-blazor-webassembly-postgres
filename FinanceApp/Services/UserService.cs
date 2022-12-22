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

    public async Task<List<UserViewModel>> FindAllAsync()
    {
        var response = await _client.GetAsync("users");
        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<UserViewModel>>(content, _options);
    }
}
