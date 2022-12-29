namespace FinanceApp.Api.ViewModels;

public class ExpenseViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
}
