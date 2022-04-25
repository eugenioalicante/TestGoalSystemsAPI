using System.Collections;
using TestGoalSystems.Application.Contrats.Persistence;
using TestGoalSystems.Domain.Common;
using TestGoalSystems.Infrastructure.Persistence;

namespace TestGoalSystems.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable? _repositories;
        private readonly InventoryDbContext _context;

        private IInventoryRepository? _inventoryRepository;

        public IInventoryRepository InventoryRepository => _inventoryRepository ??= new InventoryRepository(_context);

        public UnitOfWork(InventoryDbContext context)
        {
            _context = context;
        }

        public InventoryDbContext InventoryDbContext => _context;

        public async Task<int> Complete()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
}
