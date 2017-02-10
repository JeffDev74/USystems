using FPS.InventorySystem.ItemSystem;

namespace FPS
{
    public interface IItem
	{
        IBaseData Data { get; set; }
        INSData NSData { get; set; }
	}
}