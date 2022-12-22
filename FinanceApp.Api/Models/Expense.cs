namespace FinanceApp.Api.Models;

public class Expense : EntityBase
{
    public Expense() { }
    public Expense(string name, decimal value, Guid categoryId)
    {
        Name = name;
        Value = value;
        CategoryId = categoryId;
    }

    public string Name { get; private set; }

    public decimal Value { get; private set; }

    public Category Category { get; set; }
    public Guid CategoryId { get; private set; }

    public User User { get; set; }
    public Guid UserId { get; set; }
}
