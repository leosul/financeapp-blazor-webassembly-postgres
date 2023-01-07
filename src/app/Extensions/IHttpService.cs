namespace FinanceApp.Extensions;

public interface IHttpService
{
    Task<T> GetDataAsync<T>(string tableName);
}
