namespace FinanceApp.Api.Models;

public sealed class Category : EntityBase
{
    public Category() { }
    public Category(string name) => Name = name;

    public string Name { get; private set; }

    public ICollection<Expense> Expenses { get; set; }
}
