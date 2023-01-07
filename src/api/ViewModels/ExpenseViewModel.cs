using FinanceApp.Api.Models;

namespace FinanceApp.Api.ViewModels;

public class ExpenseViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedAt { get; set; }
}
