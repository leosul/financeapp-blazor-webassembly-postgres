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

    public async Task<bool> AddAsync(User user)
    {
        _userRepository.Add(user);

        return await _userRepository.UnitOfWork.Commit();
    }

    public async Task<List<User>> FindAllAsync()
    {
        var result = await _userRepository.GetAll();

        return result.OrderBy(s => s.Name).ToList();
    }

    public async Task<User> FindByIdAsync(Guid id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task<User> UpdateAsync(User user)
    {
        _userRepository.Update(user);
        await _userRepository.UnitOfWork.Commit();

        return await _userRepository.GetById(user.Id);
    }
 
    public async Task<bool> DeleteAsync(Guid id)
    {
        _userRepository.Remove(id);

        return await _userRepository.UnitOfWork.Commit();
    }
}
