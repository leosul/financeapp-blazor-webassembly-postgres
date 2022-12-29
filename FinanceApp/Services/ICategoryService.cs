using FinanceApp.ViewModel;

namespace FinanceApp.Services;

public interface ICategoryService
{
    Task<bool> AddAsync(CategoryViewModel category);
    Task<List<CategoryViewModel>> FindAllAsync();
    Task<CategoryViewModel> FindByIdAsync(string id);
    Task<CategoryViewModel> UpdatedAsync(CategoryViewModel category);
    Task<bool> DeleteAsync(string id);
}
