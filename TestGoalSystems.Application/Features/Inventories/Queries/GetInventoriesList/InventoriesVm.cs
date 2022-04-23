namespace TestGoalSystems.Application.Features.Inventories.Queries.GetInventoriesList
{
    public class InventoriesVm
    {
        public string Name { get; set; } = string.Empty;
        public DateTime? Expiration { get; set; }
        public int InventoryTypeId { get; set; }        
    }
}
