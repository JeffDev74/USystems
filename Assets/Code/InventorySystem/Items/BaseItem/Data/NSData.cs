using FPS.InventorySystem.ItemSystem;
using FPS.InventorySystem.UI;
using UnityEngine;

namespace FPS.InventorySystem
{
    // This class is used to hold Non-Serializable data;
    [System.Serializable]
    public class NSData : INSData
	{
        public Sprite Icon { get; set; }
        public UISlot Slot { get; set; }
	}
}