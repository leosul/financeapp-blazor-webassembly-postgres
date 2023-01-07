using FinanceApp.Api.Models;

namespace FinanceApp.Api.Data.Repository;

public interface IExpenseRepository : IRepository<Expense>
{
    Task<List<Expense>> GetAllExpensesAsync();
    Task<Expense> GetExpensesByIdAsync(Guid id);
}
