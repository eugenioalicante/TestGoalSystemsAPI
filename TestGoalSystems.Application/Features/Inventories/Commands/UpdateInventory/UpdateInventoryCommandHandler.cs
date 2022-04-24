using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TestGoalSystems.Application.Contrats.Persistence;
using TestGoalSystems.Application.Exceptions;
using TestGoalSystems.Domain;

namespace TestGoalSystems.Application.Features.Inventories.Commands.UpdateInventory
{
    public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommand>
    {        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateInventoryCommandHandler> _logger;

        public UpdateInventoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateInventoryCommandHandler> logger)
        {            
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }       

        public async Task<Unit> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventoryToUpdate = await _unitOfWork.InventoryRepository.GetByIdAsync(request.Id);

            if (inventoryToUpdate == null)
            {
                _logger.LogError($"Inventory id not found {request.Id}");
                throw new NotFoundException(nameof(Inventory), request.Id);
            }

            _mapper.Map(request, inventoryToUpdate, typeof(UpdateInventoryCommand), typeof(Inventory));

            if (request.Expiration <= DateTime.UtcNow)
            {
                _logger.LogInformation($"Inventory {inventoryToUpdate.Id} has expired.");
            }

            _unitOfWork.InventoryRepository.UpdateEntity(inventoryToUpdate);

            _logger.LogInformation($"The operation was successful updating the inventory {request.Id}");

            return Unit.Value;
        }
    }
}
