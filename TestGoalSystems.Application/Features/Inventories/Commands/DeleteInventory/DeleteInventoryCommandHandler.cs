using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TestGoalSystems.Application.Contrats.Persistence;
using TestGoalSystems.Application.Exceptions;
using TestGoalSystems.Domain;

namespace TestGoalSystems.Application.Features.Inventories.Commands.DeleteInventory
{
    /// <summary>
    /// Delete Inventory Handle
    /// </summary>
    public class DeleteInventoryCommandHandler : IRequestHandler<DeleteInventoryCommand>
    {        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteInventoryCommandHandler> _logger;

        public DeleteInventoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteInventoryCommandHandler> logger)
        {     
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Create Inventory
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<Unit> Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventoryToDelete = await _unitOfWork.InventoryRepository.GetByIdAsync(request.Id);

            if (inventoryToDelete == null)
            {
                _logger.LogError($"Inventory id not found {request.Id}");
                throw new NotFoundException(nameof(Inventory), request.Id);
            }

            _mapper.Map(request, inventoryToDelete, typeof(DeleteInventoryCommand), typeof(Inventory));
            
            _unitOfWork.InventoryRepository.DeleteEntity(inventoryToDelete);
            await _unitOfWork.Complete();

            _logger.LogInformation($"The operation was successful eliminating the inventory {request.Id}");

            return Unit.Value;
        }
    }
}
