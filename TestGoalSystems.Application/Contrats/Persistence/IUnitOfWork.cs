using TestGoalSystems.Domain.Common;

namespace TestGoalSystems.Application.Contrats.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IInventoryRepository InventoryRepository { get; }
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> Complete();
    }
}
