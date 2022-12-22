using FinanceApp.Api.Data.Repository;
using FinanceApp.Api.Models;

namespace FinanceApp.Api.Application;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> FindAllAsync()
    {
        return await _userRepository.GetAll();
    }

    public Task<User> FindByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
 
    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
