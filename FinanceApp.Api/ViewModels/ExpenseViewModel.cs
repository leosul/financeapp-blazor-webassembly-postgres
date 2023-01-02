using FinanceApp.Api.Models;

namespace FinanceApp.Api.ViewModels;

public class ExpenseViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public Category Category { get; private set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public User User { get; private set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
}
