using FinanceApp.Api.Data.Repository;
using FinanceApp.Api.Models;
using FinanceApp.Api.ViewModels;

namespace FinanceApp.Api.Application;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _expenseRepository;

    public ExpenseService(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }

    public async Task<bool> AddAsync(Expense expense)
    {
        _expenseRepository.Add(new Expense(expense.Name, expense.Value, expense.CategoryId, expense.UserId));

        return await _expenseRepository.UnitOfWork.Commit();
    }

    public async Task<List<ExpenseViewModel>> FindAllAsync()
    {
        var result = await _expenseRepository.GetAllExpensesAsync();

        return result.Select(s => new ExpenseViewModel()
        {
            CategoryId = s.CategoryId,
            UserId = s.UserId,
            Id = s.Id,
            Value = s.Value,
            Name = s.Name,
            CategoryName = s.Category.Name,
            UserName = s.User.Name,
            CreatedAt = s.CreatedAt,
        }).OrderBy(s => s.CreatedAt).ToList();
    }

    public async Task<ExpenseViewModel> FindByIdAsync(Guid id)
    {
        var result = await _expenseRepository.GetExpensesByIdAsync(id);

        return new ExpenseViewModel()
        {
            CategoryId = result.CategoryId,
            UserId = result.UserId,
            Id = result.Id,
            Value = result.Value,
            Name = result.Name,
            CategoryName = result.Category.Name,
            UserName = result.User.Name,
            CreatedAt = result.CreatedAt,
        };
    }

    public async Task<Expense> UpdateAsync(Expense expense)
    {
        var expenseUpdated = new Expense(expense.Name, expense.Value, expense.CategoryId, expense.UserId)
        {
            Id = expense.Id
        };

        _expenseRepository.Update(expenseUpdated);
        await _expenseRepository.UnitOfWork.Commit();

        return await _expenseRepository.GetById(expense.Id);
    }
 
    public async Task<bool> DeleteAsync(Guid id)
    {
        _expenseRepository.Remove(id);

        return await _expenseRepository.UnitOfWork.Commit();
    }
}
