using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TestGoalSystems.Application.Contrats.Persistence;
using TestGoalSystems.Domain;

namespace TestGoalSystems.Application.Features.Inventories.Commands.CreateInventory
{
    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, int>
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateInventoryCommandHandler> _logger;

        public CreateInventoryCommandHandler(IInventoryRepository inventoryRepository, IMapper mapper, ILogger<CreateInventoryCommandHandler> logger)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventoryEntity = _mapper.Map<Inventory>(request);

            var newInventory = await _inventoryRepository.AddAsync(inventoryEntity);

            _logger.LogInformation($"Inventory {newInventory.Id} was created successfully.");

            return newInventory.Id;
        }
    }
}
