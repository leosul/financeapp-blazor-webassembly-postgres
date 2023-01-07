namespace FinanceApp.Api.Models;

public sealed class User : EntityBase
{
    public User() { }
    public User(string name) => Name = name;

    public string Name { get; set; }

    public ICollection<Expense> Expenses { get; set; }
}
