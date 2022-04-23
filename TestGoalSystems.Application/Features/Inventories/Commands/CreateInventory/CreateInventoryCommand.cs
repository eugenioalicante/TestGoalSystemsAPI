using MediatR;

namespace TestGoalSystems.Application.Features.Inventories.Commands.CreateInventory
{
    public class CreateInventoryCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public DateTime? Expiration { get; set; }
        public int InventoryTypeId { get; set; }        
    }
}
