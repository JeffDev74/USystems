using FPS.InventorySystem.UI;
using UnityEngine.UI;

namespace FPS.InventorySystem.ItemSystem
{
	public interface INSData
	{
        Image Icon { get; set; }
        UISlot Slot { get; set; }
    }
}