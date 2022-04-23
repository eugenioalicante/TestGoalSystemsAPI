using TestGoalSystems.Domain.Common;

namespace TestGoalSystems.Domain
{
    public class InventoryType : BaseDomainModel
    {
        public InventoryType()
        {
            Inventories = new List<Inventory>();
        }

        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
