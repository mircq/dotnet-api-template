namespace Persistence.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveAsync();
}
