using AutoMapper;
using FinanceApp.Api.Models;
using FinanceApp.Api.ViewModels;

namespace FinanceApp.Api.Configurations;

public class MappingDomain : Profile
{
    public MappingDomain()
    {
        CreateMap<User, UserViewModel>()
            .ReverseMap();

        CreateMap<Category, CategoryViewModel>()
            .ReverseMap();

        CreateMap<Expense, ExpenseViewModel>()
            .ReverseMap();
    }
}
