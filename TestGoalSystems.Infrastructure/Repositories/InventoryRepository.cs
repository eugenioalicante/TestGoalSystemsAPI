using Microsoft.EntityFrameworkCore;
using TestGoalSystems.Application.Contrats.Persistence;
using TestGoalSystems.Domain;
using TestGoalSystems.Infrastructure.Persistence;

namespace TestGoalSystems.Infrastructure.Repositories
{
    public class InventoryRepository : RepositoryBase<Inventory>, IInventoryRepository
    {
        public InventoryRepository(InventoryDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Inventory>> GetInventoryByUsername(string username)
        {
            return await _context.Inventory!.Where(q => q.CreatedBy == username).ToListAsync();
        }
    }
}
