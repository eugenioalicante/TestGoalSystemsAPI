using TestGoalSystems.Domain;

namespace TestGoalSystems.Application.Contrats.Persistence
{
    /// <summary>
    /// Repository Custom Inventory
    /// </summary>
    public interface IInventoryRepository : IAsyncRepository<Inventory>
    {
        /// <summary>
        /// Inventory by Username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<IEnumerable<Inventory>> GetInventoryByUsername(string username);
    }
}
