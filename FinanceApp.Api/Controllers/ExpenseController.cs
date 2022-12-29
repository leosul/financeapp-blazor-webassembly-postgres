using AutoMapper;
using FinanceApp.Api.Application;
using FinanceApp.Api.Models;
using FinanceApp.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Api.Controllers;

[ApiController]
[Route("api/v1/expenses")]
public class ExpenseController : ControllerBase
{
    private readonly IExpenseService _expenseService;
    private readonly IMapper _mapper;

    public ExpenseController(IExpenseService expenseService,
                             IMapper mapper)
    {
        _expenseService = expenseService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync(ExpenseViewModel expense)
    {
        return Ok(await _expenseService.AddAsync(_mapper.Map<Expense>(expense)));
    }

    [HttpGet]
    public async Task<ActionResult> FindAllAsync()
    {
        return Ok(await _expenseService.FindAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> FindByIdAsync(Guid id)
    {
        return Ok(await _expenseService.FindByIdAsync(id));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync(ExpenseViewModel expense)
    {
        await _expenseService.UpdateAsync(_mapper.Map<Expense>(expense));

        return Ok(await _expenseService.FindByIdAsync(expense.Id));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        return Ok(await _expenseService.DeleteAsync(id));
    }
}
