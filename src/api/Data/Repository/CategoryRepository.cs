using FinanceApp.Api.Data.Context;
using FinanceApp.Api.Models;

namespace FinanceApp.Api.Data.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly FinanceDbContext _context;
    public CategoryRepository(FinanceDbContext context) : base(context)
    {
        _context = context;
    }
}
