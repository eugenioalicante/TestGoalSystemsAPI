using MediatR;

namespace TestGoalSystems.Application.Features.Inventories.Commands.UpdateInventory
{
    public class UpdateInventoryCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? Expiration { get; set; }
        public int InventoryTypeId { get; set; }
    }
}
