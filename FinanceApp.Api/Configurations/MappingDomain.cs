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
            .ForMember(s => s.Name, a => a.MapFrom(s => s.Name))
            .ForMember(s => s.CategoryId, a => a.MapFrom(s => s.CategoryId))
            .ForMember(s => s.UserId, a => a.MapFrom(s => s.UserId))
            .ForMember(s => s.Name, a => a.MapFrom(s => s.Name))
            .ForMember(s => s.Category, a => a.Ignore())
            .ForMember(s => s.User, a => a.Ignore())
            .ReverseMap();
    }
}
