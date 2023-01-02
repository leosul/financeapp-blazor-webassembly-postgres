using FinanceApp.Api.Data.Context;
using FinanceApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Api.Data.Repository;

public class ExpenseRepository : Repository<Expense>, IExpenseRepository
{
    private readonly FinanceDbContext _context;
    public ExpenseRepository(FinanceDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Expense>> GetAllExpensesAsync()
    {
        return await _context.Expenses.AsNoTrackingWithIdentityResolution().Include(s => s.User).Include(s => s.Category).ToListAsync();
    }

    public async Task<Expense> GetExpensesByIdAsync(Guid id)
    {
        return await _context.Expenses.Include(s => s.User).Include(s => s.Category).FirstOrDefaultAsync(s => s.Id == id);
    }
}
