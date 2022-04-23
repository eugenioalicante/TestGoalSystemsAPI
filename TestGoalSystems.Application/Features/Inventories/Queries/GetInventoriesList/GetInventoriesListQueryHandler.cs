using AutoMapper;
using MediatR;
using TestGoalSystems.Application.Contrats.Persistence;

namespace TestGoalSystems.Application.Features.Inventories.Queries.GetInventoriesList
{
    public class GetInventoriesListQueryHandler : IRequestHandler<GetInventoriesListQuery, List<InventoriesVm>>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public GetInventoriesListQueryHandler(IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<List<InventoriesVm>> Handle(GetInventoriesListQuery request, CancellationToken cancellationToken)
        {
            var inventoriesList = await _inventoryRepository.GetInventoryByUsername(request._Username);

            return _mapper.Map<List<InventoriesVm>>(inventoriesList);
        }
    }
}
