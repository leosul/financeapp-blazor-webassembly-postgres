using FinanceApp.ViewModel;

namespace FinanceApp.Services;

public interface IExpenseService
{
    Task<bool> AddAsync(ExpenseViewModel expense);
    Task<List<ExpenseViewModel>> FindAllAsync();
    Task<ExpenseViewModel> FindByIdAsync(string id);
    Task<ExpenseViewModel> UpdatedAsync(ExpenseViewModel expense);
    Task<bool> DeleteAsync(string id);
}
