namespace FinanceApp.Api.Models;

public abstract class EntityBase
{
    protected EntityBase()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
}
