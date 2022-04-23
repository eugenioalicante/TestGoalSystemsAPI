using TestGoalSystems.Domain;

namespace TestGoalSystems.Application.Contrats.Persistence
{
    public interface IInventoryRepository : IAsyncRepository<Inventory>
    {
        Task<IEnumerable<Inventory>> GetInventoryByUsername(string username);
    }
}
