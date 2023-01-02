using FinanceApp.Api.Models;
using FinanceApp.Api.ViewModels;

namespace FinanceApp.Api.Application;

public interface IExpenseService
{
    Task<bool> AddAsync(Expense expense);
    Task<List<ExpenseViewModel>> FindAllAsync();
    Task<ExpenseViewModel> FindByIdAsync(Guid id);
    Task<Expense> UpdateAsync(Expense expense);
    Task<bool> DeleteAsync(Guid id);
}
