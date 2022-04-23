using AutoMapper;
using TestGoalSystems.Application.Features.Inventories.Commands.CreateInventory;
using TestGoalSystems.Application.Features.Inventories.Queries.GetInventoriesList;
using TestGoalSystems.Domain;

namespace TestGoalSystems.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Inventory, InventoriesVm>();
            CreateMap<CreateInventoryCommand, Inventory>();
        }
    }
}
