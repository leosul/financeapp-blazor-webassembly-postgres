using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using FinanceApp.ViewModel;

namespace FinanceApp.Services;

public class ExpenseService : IExpenseService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;

    public ExpenseService(HttpClient client)
    {
        _client = client;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = false, ReferenceHandler = ReferenceHandler.IgnoreCycles };
    }

    public async Task<bool> AddAsync(ExpenseViewModel expense)
    {
        var content = JsonSerializer.Serialize(expense);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync($"expenses", bodyContent);
        var result = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<bool>(result, _options);
    }

    public async Task<List<ExpenseViewModel>> FindAllAsync()
    {
        var response = await _client.GetAsync("expenses");
        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<ExpenseViewModel>>(content, _options);
    }

    public async Task<ExpenseViewModel> FindByIdAsync(string id)
    {
        var response = await _client.GetAsync($"expenses/{Guid.Parse(id)}");
        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<ExpenseViewModel>(content, _options);
    }

    public async Task<ExpenseViewModel> UpdatedAsync(ExpenseViewModel expense)
    {
        var content = JsonSerializer.Serialize(expense);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        var response = await _client.PutAsync($"expenses", bodyContent);
        var result = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<ExpenseViewModel>(result, _options);
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var response = await _client.DeleteAsync($"expenses/{Guid.Parse(id)}");
        var content = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<bool>(content, _options);
    }
}
