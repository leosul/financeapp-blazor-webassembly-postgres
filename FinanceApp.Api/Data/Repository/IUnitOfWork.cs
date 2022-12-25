namespace FinanceApp.Api.Data.Repository;

public interface IUnitOfWork
{
    Task<bool> Commit();
}
