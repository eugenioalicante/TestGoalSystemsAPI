using AutoMapper;
using Moq;
using Shouldly;
using TestGoalSystems.Application.Features.Inventories.Queries.GetInventoriesList;
using TestGoalSystems.Application.Mappings;
using TestGoalSystems.Application.UnitTests.Mock;
using TestGoalSystems.Infrastructure.Repositories;
using Xunit;

namespace TestGoalSystems.Application.UnitTests.Features.Inventories.Queries
{
    public class GetInventoriesListQueryHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetInventoriesListQueryHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            MockInventoryRepository.AddDataInventoryRepository(_unitOfWork.Object.InventoryDbContext);
        }

        [Fact]
        public async Task GetInventoryListTest()
        {
            var handler = new GetInventoriesListQueryHandler(_unitOfWork.Object, _mapper);
            var request = new GetInventoriesListQuery("system");

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<List<InventoriesVm>>();

            result.Count.ShouldBe(1);
        }


    }
}
