using TestGoalSystems.Domain.Common;

namespace TestGoalSystems.Application.Contrats.Persistence
{
    /// <summary>
    /// Repository Unit Of Work
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Instance context
        /// </summary>
        IInventoryRepository InventoryRepository { get; }

        /// <summary>
        /// Generic methods
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        /// <summary>
        /// Save Changues
        /// </summary>
        /// <returns></returns>
        Task<int> Complete();
    }
}
