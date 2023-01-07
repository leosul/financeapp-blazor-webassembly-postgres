using FinanceApp.Api.Models;

namespace FinanceApp.Api.Application;

public interface IUserService
{
    Task<bool> AddAsync(User user);
    Task<List<User>> FindAllAsync();
    Task<User> FindByIdAsync(Guid id);
    Task<User> UpdateAsync(User user);
    Task<bool> DeleteAsync(Guid id);
}
