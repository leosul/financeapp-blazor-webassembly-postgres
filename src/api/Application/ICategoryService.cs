using FinanceApp.Api.Models;

namespace FinanceApp.Api.Application;

public interface ICategoryService
{
    Task<bool> AddAsync(Category category);
    Task<List<Category>> FindAllAsync();
    Task<Category> FindByIdAsync(Guid id);
    Task<Category> UpdateAsync(Category category);
    Task<bool> DeleteAsync(Guid id);
}
