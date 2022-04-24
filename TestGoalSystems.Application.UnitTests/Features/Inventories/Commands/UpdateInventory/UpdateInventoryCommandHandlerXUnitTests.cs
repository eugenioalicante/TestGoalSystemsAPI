using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using TestGoalSystems.Application.Features.Inventories.Commands.UpdateInventory;
using TestGoalSystems.Application.Mappings;
using TestGoalSystems.Application.UnitTests.Mock;
using TestGoalSystems.Infrastructure.Repositories;
using Xunit;

namespace TestGoalSystems.Application.UnitTests.Features.Inventories.Commands.UpdateInventory
{
    public class UpdateInventoryCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<UpdateInventoryCommandHandler>> _logger;

        public UpdateInventoryCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _logger = new Mock<ILogger<UpdateInventoryCommandHandler>>();

            MockInventoryRepository.AddDataInventoryRepository(_unitOfWork.Object.InventoryDbContext);
        }

        [Fact]
        public async Task UpdateInventoryCommand_InputInventory_ReturnsUnit()
        {
            var inventoryInput = new UpdateInventoryCommand
            {
                Id = 2005,
                Name = "Test Inventario",
                InventoryTypeId = 1,
                Expiration = new DateTime(2023, 8, 5)
            };

            var handler = new UpdateInventoryCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);

            var result = await handler.Handle(inventoryInput, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }
    }
}
