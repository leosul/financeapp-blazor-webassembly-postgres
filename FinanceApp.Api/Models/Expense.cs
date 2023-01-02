namespace FinanceApp.Api.Models;

public class Expense : EntityBase
{
    public Expense() { }
    public Expense(string name, decimal value, Guid categoryId, Guid userId)
    {
        Name = name;
        Value = value;
        CategoryId = categoryId;
        UserId = userId;
    }

    public string Name { get; private set; }

    public decimal Value { get; private set; }

    public Category Category { get; private set; }
    public Guid CategoryId { get; private set; }

    public User User { get; private set; }
    public Guid UserId { get; private set; }
}
