using FinanceApp.ViewModel;

namespace FinanceApp.Services;

public interface IUserService
{
    Task<List<UserViewModel>> FindAllAsync();
}
