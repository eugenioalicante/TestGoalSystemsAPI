using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using TestGoalSystems.Application.Features.Inventories.Commands.CreateInventory;
using TestGoalSystems.Application.Mappings;
using TestGoalSystems.Application.UnitTests.Mock;
using TestGoalSystems.Infrastructure.Repositories;
using Xunit;

namespace TestGoalSystems.Application.UnitTests.Features.Inventories.Commands.CreateInventory
{
    public class CreateInventoryCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<CreateInventoryCommandHandler>> _logger;

        public CreateInventoryCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _logger = new Mock<ILogger<CreateInventoryCommandHandler>>();

            MockInventoryRepository.AddDataInventoryRepository(_unitOfWork.Object.InventoryDbContext);
        }

        [Fact]
        public async Task CreateInventoryCommand_InputInventory_ReturnsNumber()
        {
            var inventoryInput = new CreateInventoryCommand
            {
                Name = "Test Inventario",
                InventoryTypeId = 1,
                Expiration = new DateTime(2023, 8, 5)
            };

            var handler = new CreateInventoryCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);

            var result = await handler.Handle(inventoryInput, CancellationToken.None);

            result.ShouldBeOfType<int>();
        }
    }
}
