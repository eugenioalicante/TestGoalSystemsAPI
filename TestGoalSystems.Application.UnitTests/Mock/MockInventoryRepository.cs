using AutoFixture;
using TestGoalSystems.Domain;
using TestGoalSystems.Infrastructure.Persistence;

namespace TestGoalSystems.Application.UnitTests.Mock
{
    public class MockInventoryRepository
    {
        public static void AddDataInventoryRepository(InventoryDbContext inventoryDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var inventories = fixture.CreateMany<Inventory>().ToList();

            inventories.Add(fixture.Build<Inventory>()
                .With(tr => tr.CreatedBy, "system")
                .With(tr => tr.Id, 2005)
                .Without(tr => tr.InventoryType)
                .Create()
            );

            inventoryDbContextFake.Inventory!.AddRange(inventories);
            inventoryDbContextFake.SaveChanges();
        }
    }
}
