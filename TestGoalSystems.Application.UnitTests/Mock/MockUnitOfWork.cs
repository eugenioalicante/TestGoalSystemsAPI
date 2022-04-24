using Microsoft.EntityFrameworkCore;
using Moq;
using TestGoalSystems.Infrastructure.Persistence;
using TestGoalSystems.Infrastructure.Repositories;

namespace TestGoalSystems.Application.UnitTests.Mock
{
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            Guid dbContextId = Guid.NewGuid();

            var options = new DbContextOptionsBuilder<InventoryDbContext>()
                .UseInMemoryDatabase(databaseName: $"InventoryDbContext-{dbContextId}")
                .Options;

            var inventoryDbContextFake = new InventoryDbContext(options);

            inventoryDbContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(inventoryDbContextFake);

            return mockUnitOfWork;
        }
    }
}
