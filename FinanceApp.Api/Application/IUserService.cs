using FinanceApp.Api.Models;

namespace FinanceApp.Api.Application;

public interface IUserService
{
    Task<List<User>> FindAllAsync();
    Task<User> FindByIdAsync(Guid id);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
}
