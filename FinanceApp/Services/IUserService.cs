using FinanceApp.ViewModel;

namespace FinanceApp.Services;

public interface IUserService
{
    Task<List<UserViewModel>> FindAllAsync();
    Task<UserViewModel> FindByIdAsync(string id);
    Task<UserViewModel> UpdatedAsync(UserViewModel user);
}
