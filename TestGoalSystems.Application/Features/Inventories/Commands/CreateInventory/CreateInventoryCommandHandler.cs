﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TestGoalSystems.Application.Contrats.Persistence;
using TestGoalSystems.Domain;

namespace TestGoalSystems.Application.Features.Inventories.Commands.CreateInventory
{
    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, int>
    {        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateInventoryCommandHandler> _logger;

        public CreateInventoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateInventoryCommandHandler> logger)
        {            
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventoryEntity = _mapper.Map<Inventory>(request);
            
            _unitOfWork.InventoryRepository.AddEntity(inventoryEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"Failed to insert inventory record");
            }

            _logger.LogInformation($"Inventory {inventoryEntity.Id} was created successfully.");

            if (request.Expiration <= DateTime.UtcNow)
            {
                _logger.LogInformation($"Inventory {inventoryEntity.Id} has expired.");
            }

            return inventoryEntity.Id;
        }
    }
}
