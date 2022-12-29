using FinanceApp.Api.Models;

namespace FinanceApp.Api.Application;

public interface IExpenseService
{
    Task<bool> AddAsync(Expense expense);
    Task<List<Expense>> FindAllAsync();
    Task<Expense> FindByIdAsync(Guid id);
    Task<Expense> UpdateAsync(Expense expense);
    Task<bool> DeleteAsync(Guid id);
}
