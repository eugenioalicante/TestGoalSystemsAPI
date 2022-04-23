using MediatR;

namespace TestGoalSystems.Application.Features.Inventories.Commands.DeleteInventory
{
    public class DeleteInventoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
