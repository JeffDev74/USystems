using FPS.InventorySystem.UI;
using UnityEngine;
using UnityEngine.UI;

namespace FPS.InventorySystem.ItemSystem
{
	public interface INSData
	{
        Sprite Icon { get; set; }
        UISlot Slot { get; set; }
    }
}