using MediatR;

namespace TestGoalSystems.Application.Features.Inventories.Queries.GetInventoriesList
{
    public class GetInventoriesListQuery : IRequest<List<InventoriesVm>>
    {
        public string _Username { get; set; } = string.Empty;

        public GetInventoriesListQuery(string username)
        {
            _Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
