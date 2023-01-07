using System.Text;
using System.Text.Json;
using FinanceApp.ViewModel;

namespace FinanceApp.Services;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;

    public CategoryService(HttpClient client)
    {
        _client = client;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = false };
    }

    public async Task<bool> AddAsync(CategoryViewModel category)
    {
        var content = JsonSerializer.Serialize(category);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync($"categories", bodyContent);
        var result = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<bool>(result, _options);
    }

    public async Task<List<CategoryViewModel>> FindAllAsync()
    {
        var response = await _client.GetAsync("categories");
        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<CategoryViewModel>>(content, _options);
    }

    public async Task<CategoryViewModel> FindByIdAsync(string id)
    {
        var response = await _client.GetAsync($"categories/{Guid.Parse(id)}");
        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<CategoryViewModel>(content, _options);
    }

    public async Task<CategoryViewModel> UpdatedAsync(CategoryViewModel category)
    {
        var content = JsonSerializer.Serialize(category);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        var response = await _client.PutAsync($"categories", bodyContent);
        var result = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<CategoryViewModel>(result, _options);
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var response = await _client.DeleteAsync($"categories/{Guid.Parse(id)}");
        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<bool>(content, _options);
    }
}
