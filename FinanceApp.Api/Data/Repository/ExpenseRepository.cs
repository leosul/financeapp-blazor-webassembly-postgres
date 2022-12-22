using FinanceApp.Api.Data.Context;
using FinanceApp.Api.Models;

namespace FinanceApp.Api.Data.Repository;

public class ExpenseRepository : Repository<Expense>, IExpenseRepository
{
    private readonly FinanceDbContext _context;
    public ExpenseRepository(FinanceDbContext context) : base(context)
    {
        _context = context;
    }
}
