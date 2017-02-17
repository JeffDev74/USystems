
namespace FPS
{
	public interface IBaseData
	{
        int Id { get; set; }
        string UniqueUUID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        // Should we move thi to RTData??? maybe...
        int SlotId { get; set; } 
        // This should be part of the IStackable interface
        int Quantity { get; set; }
        string InventoryUUID { get; set; }
    }
}