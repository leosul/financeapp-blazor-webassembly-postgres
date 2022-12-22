using FinanceApp.Api.Data.Context;
using FinanceApp.Api.Models;

namespace FinanceApp.Api.Data.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly FinanceDbContext _context;
    public UserRepository(FinanceDbContext context) : base(context)
    {
        _context = context;
    }
}
