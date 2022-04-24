using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using TestGoalSystems.Application.Features.Inventories.Commands.DeleteInventory;
using TestGoalSystems.Application.Mappings;
using TestGoalSystems.Application.UnitTests.Mock;
using TestGoalSystems.Infrastructure.Repositories;
using Xunit;

namespace TestGoalSystems.Application.UnitTests.Features.Inventories.Commands.DeleteInventory
{
    public class DeleteInventoryCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<DeleteInventoryCommandHandler>> _logger;

        public DeleteInventoryCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _logger = new Mock<ILogger<DeleteInventoryCommandHandler>>();

            MockInventoryRepository.AddDataInventoryRepository(_unitOfWork.Object.InventoryDbContext);
        }

        [Fact]
        public async Task DeleteInventoryCommand_InputInventory_ReturnsUnit()
        {
            var inventoryInput = new DeleteInventoryCommand
            {
                Id = 2005
            };

            var handler = new DeleteInventoryCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);

            var result = await handler.Handle(inventoryInput, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }
    }
}
