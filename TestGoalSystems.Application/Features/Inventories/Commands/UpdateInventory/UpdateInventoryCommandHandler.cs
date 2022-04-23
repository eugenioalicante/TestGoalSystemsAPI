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
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateInventoryCommandHandler> _logger;

        public UpdateInventoryCommandHandler(IInventoryRepository inventoryRepository, IMapper mapper, ILogger<UpdateInventoryCommandHandler> logger)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
            _logger = logger;
        }       

        public async Task<Unit> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {
            var streamerToUpdate = await _inventoryRepository.GetByIdAsync(request.Id);

            if (streamerToUpdate == null)
            {
                _logger.LogError($"Inventory id not found {request.Id}");
                throw new NotFoundException(nameof(Inventory), request.Id);
            }

            _mapper.Map(request, streamerToUpdate, typeof(UpdateInventoryCommand), typeof(Inventory));

            await _inventoryRepository.UpdateAsync(streamerToUpdate);

            _logger.LogInformation($"The operation was successful updating the inventory {request.Id}");

            return Unit.Value;
        }
    }
}
