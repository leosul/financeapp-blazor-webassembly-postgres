using FinanceApp.Api.Data.Repository;
using FinanceApp.Api.Models;

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
        _expenseRepository.Add(expense);

        return await _expenseRepository.UnitOfWork.Commit();
    }

    public async Task<List<Expense>> FindAllAsync()
    {
        var result = await _expenseRepository.GetAll();

        return result.OrderBy(s => s.Name).ToList();
    }

    public async Task<Expense> FindByIdAsync(Guid id)
    {
        return await _expenseRepository.GetById(id);
    }

    public async Task<Expense> UpdateAsync(Expense expense)
    {
        _expenseRepository.Update(expense);
        await _expenseRepository.UnitOfWork.Commit();

        return await _expenseRepository.GetById(expense.Id);
    }
 
    public async Task<bool> DeleteAsync(Guid id)
    {
        _expenseRepository.Remove(id);

        return await _expenseRepository.UnitOfWork.Commit();
    }
}
