using TestGoalSystems.Domain.Common;

namespace TestGoalSystems.Domain
{
    public class Inventory : BaseDomainModel
    {
        public string Name { get; set; } = string.Empty;
        public DateTime? Expiration { get; set; }
        public int InventoryTypeId { get; set; }
        public virtual InventoryType? InventoryType { get; set; }
    }
}
