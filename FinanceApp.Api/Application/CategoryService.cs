using FinanceApp.Api.Data.Repository;
using FinanceApp.Api.Models;

namespace FinanceApp.Api.Application;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> AddAsync(Category category)
    {
        _categoryRepository.Add(category);

        return await _categoryRepository.UnitOfWork.Commit();
    }

    public async Task<List<Category>> FindAllAsync()
    {
        var result = await _categoryRepository.GetAll();

        return result.OrderBy(s => s.Name).ToList();
    }

    public async Task<Category> FindByIdAsync(Guid id)
    {
        return await _categoryRepository.GetById(id);
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        _categoryRepository.Update(category);
        await _categoryRepository.UnitOfWork.Commit();

        return await _categoryRepository.GetById(category.Id);
    }
 
    public async Task<bool> DeleteAsync(Guid id)
    {
        _categoryRepository.Remove(id);

        return await _categoryRepository.UnitOfWork.Commit();
    }
}
