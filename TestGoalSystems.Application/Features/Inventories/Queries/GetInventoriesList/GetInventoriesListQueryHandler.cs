using AutoMapper;
using MediatR;
using TestGoalSystems.Application.Contrats.Persistence;

namespace TestGoalSystems.Application.Features.Inventories.Queries.GetInventoriesList
{
    /// <summary>
    /// Inventory Handle
    /// </summary>
    public class GetInventoriesListQueryHandler : IRequestHandler<GetInventoriesListQuery, List<InventoriesVm>>
    {
        private readonly IUnitOfWork _unitOfWork;        
        private readonly IMapper _mapper;

        public GetInventoriesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Inventory Handle
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<InventoriesVm>> Handle(GetInventoriesListQuery request, CancellationToken cancellationToken)
        {
            var inventoriesList = await _unitOfWork.InventoryRepository.GetInventoryByUsername(request._Username);

            return _mapper.Map<List<InventoriesVm>>(inventoriesList);
        }
    }
}
