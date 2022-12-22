using System.Net.Http.Json;

namespace FinanceApp.Extensions;

public class HttpService : IHttpService
{
    public async Task<T> GetDataAsync<T>(string tableName)
    {
        using var client = new HttpClient();

        return await client.GetFromJsonAsync<T>($"Data/{tableName}.json");
    }
}
