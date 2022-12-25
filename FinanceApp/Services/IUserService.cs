using FinanceApp.ViewModel;

namespace FinanceApp.Services;

public interface IUserService
{
    Task<bool> AddAsync(UserViewModel user);
    Task<List<UserViewModel>> FindAllAsync();
    Task<UserViewModel> FindByIdAsync(string id);
    Task<UserViewModel> UpdatedAsync(UserViewModel user);
    Task<bool> DeleteAsync(string id);
}
